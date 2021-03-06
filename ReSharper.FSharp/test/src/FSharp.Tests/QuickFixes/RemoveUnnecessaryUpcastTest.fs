namespace JetBrains.ReSharper.Plugins.FSharp.Tests.Features

open JetBrains.ReSharper.FeaturesTestFramework.Intentions
open JetBrains.ReSharper.Plugins.FSharp.Psi.Features.Daemon.QuickFixes
open JetBrains.ReSharper.Plugins.FSharp.Tests.Common
open NUnit.Framework

[<FSharpTest>]
type RemoveUnnecessaryUpcastTest() =
    inherit QuickFixTestBase<RemoveUnnecessaryUpcastFix>()

    override x.RelativeTestDataPath = "features/quickFixes/removeUnnecessaryUpcast"

    [<Test>] member x.``Simple 01``() = x.DoNamedTest()
