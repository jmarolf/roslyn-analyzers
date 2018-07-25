// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using ProjectSystem.Analyzers;

namespace ProjectSystem.CSharp.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CSharptDoNotUseIProjectGuidService
        : AbstractDoNotUseIProjectGuidService<SyntaxKind, CSharpErrorAllUseagesOfType, MemberAccessExpressionSyntax, InvocationExpressionSyntax>
    {
        protected override CSharpErrorAllUseagesOfType CreateErrorAllUsagesOfType(ITypeSymbol illegalType, DiagnosticDescriptor descriptor)
            => new CSharpErrorAllUseagesOfType(illegalType, descriptor);
    }
}
