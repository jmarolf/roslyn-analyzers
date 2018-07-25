// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace ProjectSystem.Analyzers
{
    public abstract class AbstractDoNotUseIProjectGuidServiceCommon<TSyntaxKind, TErrorAllUsagesOfType, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax> : AbstractDoNotUseType<TSyntaxKind, TErrorAllUsagesOfType, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TSyntaxKind : struct
        where TErrorAllUsagesOfType : ErrorAllUsagesOfType<TSyntaxKind, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TMemberAccessExpressionSyntax : SyntaxNode
        where TInvocationExpressionSyntax : SyntaxNode
    {
        public const string DiagnosticId = "PRGSYS002";

        private static readonly DiagnosticDescriptor DiagnosticDescriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: new LocalizableResourceString(nameof(Resources.DoNotUseIProjectGuidServiceTitle), Resources.ResourceManager, typeof(Resources)),
            messageFormat: new LocalizableResourceString(nameof(Resources.DoNotUseIProjectGuidServiceMessage), Resources.ResourceManager, typeof(Resources)),
            category: "Usage",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(DiagnosticDescriptor);
    }
}
