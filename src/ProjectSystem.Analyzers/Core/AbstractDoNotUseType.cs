// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace ProjectSystem.Analyzers
{
    public abstract class AbstractDoNotUseType<TSyntaxKind, TErrorAllUsagesOfType, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax> : DiagnosticAnalyzer
        where TSyntaxKind : struct
        where TErrorAllUsagesOfType : ErrorAllUsagesOfType<TSyntaxKind, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TMemberAccessExpressionSyntax : SyntaxNode
        where TInvocationExpressionSyntax : SyntaxNode
    {
        protected abstract TErrorAllUsagesOfType CreateErrorAllUsagesOfType(ITypeSymbol illegalType, DiagnosticDescriptor descriptor);

        protected abstract ITypeSymbol GetTypeSymbolFromCompilation(Compilation compilation);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterCompilationStartAction(compilationContext =>
            {
                var projectLockServiceFullNameSymbol = GetTypeSymbolFromCompilation(compilationContext.Compilation);
                if (projectLockServiceFullNameSymbol != null)
                {
                    compilationContext.RegisterCodeBlockStartAction<TSyntaxKind>(CreateErrorAllUsagesOfType(projectLockServiceFullNameSymbol, SupportedDiagnostics[0]).Analyze);
                }
            });
        }
    }
}
