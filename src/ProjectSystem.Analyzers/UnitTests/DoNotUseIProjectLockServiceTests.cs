// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.Diagnostics;
using ProjectSystem.CSharp.Analyzers;
using ProjectSystem.VisualBasic.Analyzers;
using Test.Utilities;
using Xunit;

namespace ProjectSystem.Analyzers.UnitTests
{
    public class DoNotUseIProjectLockServiceTests : DiagnosticAnalyzerTestBase
    {

        protected override DiagnosticAnalyzer GetBasicDiagnosticAnalyzer()
        {
            return new VisualBasicDoNotUseIProjectGuidService();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new CSharpDoNotUseIProjectLockService();
        }

        [Fact]
        public void DiagnosticCases()
        {
//             VerifyCSharp(@"

// " + CSharpIProjectLockServiceDefinition,
//     // Test0.cs(10,15): warning RS0006: Attribute 'ImportAttribute' comes from a different version of MEF than the export attribute on 'C'
//     GetCSharpResultAt(10, 15, "ImportAttribute", "C"),
//     // Test0.cs(20,16): warning RS0006: Attribute 'ImportAttribute' comes from a different version of MEF than the export attribute on 'C2'
//     GetCSharpResultAt(20, 16, "ImportAttribute", "C2"));

//             VerifyBasic(@"
// " + BasicIProjectLockServiceDefinition,
//     // Test0.vb(8,18): warning RS0006: Attribute 'ImportAttribute' comes from a different version of MEF than the export attribute on 'C'
//     GetBasicResultAt(8, 18, "ImportAttribute", "C"),
//     // Test0.vb(18,18): warning RS0006: Attribute 'ImportAttribute' comes from a different version of MEF than the export attribute on 'C2'
//     GetBasicResultAt(18, 18, "ImportAttribute", "C2"));
        }
    }
}
