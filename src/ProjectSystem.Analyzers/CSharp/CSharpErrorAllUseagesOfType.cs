// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectSystem.Analyzers;

namespace ProjectSystem.CSharp.Analyzers
{
    public class CSharpErrorAllUseagesOfType : ErrorAllUsagesOfType<SyntaxKind, MemberAccessExpressionSyntax, InvocationExpressionSyntax>
    {
        public CSharpErrorAllUseagesOfType(ITypeSymbol illegalType, DiagnosticDescriptor descriptor)
            : base(illegalType, descriptor, SyntaxKind.InvocationExpression, SyntaxKind.SimpleMemberAccessExpression)
        {
        }

        protected override SyntaxNode GetExpression(MemberAccessExpressionSyntax memberAccessSyntax) => memberAccessSyntax.Expression;
    }
}
