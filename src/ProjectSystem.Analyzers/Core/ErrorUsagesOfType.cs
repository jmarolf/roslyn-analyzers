// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace ProjectSystem.Analyzers
{
    public abstract class ErrorAllUsagesOfType<TSyntaxKind, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TSyntaxKind : struct
        where TMemberAccessExpressionSyntax : SyntaxNode
        where TInvocationExpressionSyntax : SyntaxNode
    {
        private readonly ITypeSymbol illegalType;
        private readonly DiagnosticDescriptor descriptor;
        private readonly TSyntaxKind invocationKind;
        private readonly TSyntaxKind simpleMemberAccessExpressionKind;

        protected ErrorAllUsagesOfType(ITypeSymbol illegalType, DiagnosticDescriptor descriptor, TSyntaxKind invocationKind, TSyntaxKind simpleMemberAccessExpressionKind)
        {
            this.illegalType = illegalType;
            this.descriptor = descriptor;
            this.invocationKind = invocationKind;
            this.simpleMemberAccessExpressionKind = simpleMemberAccessExpressionKind;
        }

        abstract protected SyntaxNode GetExpression(TMemberAccessExpressionSyntax memberAccessSyntax);

        internal void Analyze(CodeBlockStartAnalysisContext<TSyntaxKind> codeBlockContext)
        {
            ISymbol owningSymbol = codeBlockContext.OwningSymbol;
            if (owningSymbol is IMethodSymbol || owningSymbol is IPropertySymbol)
            {
                codeBlockContext.RegisterSyntaxNodeAction(AnalyzeMemberAccess, simpleMemberAccessExpressionKind);
            }
        }

        private void AnalyzeMemberAccess(SyntaxNodeAnalysisContext syntaxNodeAnalysisContext)
        {
            var memberAccessSyntax = (TMemberAccessExpressionSyntax)syntaxNodeAnalysisContext.Node;
            InspectMemberAccess(syntaxNodeAnalysisContext, memberAccessSyntax);
        }

        private void InspectMemberAccess(SyntaxNodeAnalysisContext syntaxNodeAnalysisContext, TMemberAccessExpressionSyntax memberAccessSyntax)
        {
            if (memberAccessSyntax == null)
            {
                return;
            }

            SyntaxNode expression = GetExpression(memberAccessSyntax);
            CancellationToken token = syntaxNodeAnalysisContext.CancellationToken;
            ISymbol symbol = syntaxNodeAnalysisContext.SemanticModel.GetSymbolInfo(expression, token).Symbol;

            ITypeSymbol type = GetTypeFromSymbol(symbol);

            while (type != null)
            {
                if (InheritsFromIgnoringConstruction(type, illegalType))
                {
                    syntaxNodeAnalysisContext.ReportDiagnostic(Diagnostic.Create(descriptor, memberAccessSyntax.GetLocation()));
                    return;
                }

                type = type.ContainingType;
            }
        }

        private static ITypeSymbol GetTypeFromSymbol(ISymbol symbol)
        {
            ITypeSymbol type = null;

            if (symbol is IDiscardSymbol discardSymbol)
            {
                type = discardSymbol.Type;
            }

            if (symbol is IEventSymbol eventSymbol)
            {
                type = eventSymbol.Type;
            }

            if (symbol is IFieldSymbol fieldSymbol)
            {
                type = fieldSymbol.Type;
            }

            if (symbol is ILocalSymbol localSymbol)
            {
                type = localSymbol.Type;
            }

            if (symbol is IPropertySymbol propertySymbol)
            {
                type = propertySymbol.Type;
            }

            return type;
        }

        private static bool InheritsFromIgnoringConstruction(ITypeSymbol type, ITypeSymbol baseType)
        {
            var originalBaseType = baseType.OriginalDefinition;

            var currentBaseType = type;
            while (currentBaseType != null)
            {
                if (EqualityComparer<ISymbol>.Default.Equals(currentBaseType.OriginalDefinition, originalBaseType))
                {
                    return true;
                }

                currentBaseType = currentBaseType.BaseType;
            }

            return false;
        }
    }
}
