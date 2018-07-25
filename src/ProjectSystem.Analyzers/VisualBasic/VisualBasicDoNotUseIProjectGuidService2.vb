' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Diagnostics
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports ProjectSystem.Analyzers

Namespace ProjectSystem.VisualBasic.Analyzers
    <DiagnosticAnalyzer(LanguageNames.VisualBasic)>
    Public Class VisualBasicDoNotUseIProjectGuidService2
        Inherits AbstractDoNotUseIProjectGuidService2(Of SyntaxKind, VisualBasicErrorAllUseagesOfType, MemberAccessExpressionSyntax, InvocationExpressionSyntax)
        Protected Overrides Function CreateErrorAllUsagesOfType(illegalType As ITypeSymbol, descriptor As DiagnosticDescriptor) As VisualBasicErrorAllUseagesOfType
            Return New VisualBasicErrorAllUseagesOfType(illegalType, descriptor)
        End Function
    End Class
End Namespace
