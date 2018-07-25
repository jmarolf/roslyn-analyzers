' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports ProjectSystem.Analyzers

Namespace ProjectSystem.VisualBasic.Analyzers
    Public Class VisualBasicErrorAllUseagesOfType
        Inherits ErrorAllUsagesOfType(Of SyntaxKind, MemberAccessExpressionSyntax, InvocationExpressionSyntax)

        Public Sub New(illegalType As ITypeSymbol, descriptor As DiagnosticDescriptor)
            MyBase.New(illegalType, descriptor, SyntaxKind.InvocationExpression, SyntaxKind.SimpleMemberAccessExpression)
        End Sub

        Protected Overrides Function GetExpression(memberAccessSyntax As MemberAccessExpressionSyntax) As SyntaxNode
            Return memberAccessSyntax.Expression
        End Function
    End Class
End Namespace
