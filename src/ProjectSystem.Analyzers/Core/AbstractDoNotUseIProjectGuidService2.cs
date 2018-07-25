// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace ProjectSystem.Analyzers
{
    public abstract class AbstractDoNotUseIProjectGuidService2<TSyntaxKind, TErrorAllUsagesOfType, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax> : AbstractDoNotUseIProjectGuidServiceCommon<TSyntaxKind, TErrorAllUsagesOfType, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TSyntaxKind : struct
        where TErrorAllUsagesOfType : ErrorAllUsagesOfType<TSyntaxKind, TMemberAccessExpressionSyntax, TInvocationExpressionSyntax>
        where TMemberAccessExpressionSyntax : SyntaxNode
        where TInvocationExpressionSyntax : SyntaxNode
    {
        protected override ITypeSymbol GetTypeSymbolFromCompilation(Compilation compilation) => compilation.GetTypeByMetadataName(Constants.IProjectGuidService2FullName);
    }
}
