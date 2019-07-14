namespace JetBrains.ReSharper.Plugins.FSharp.Tests.Features

open System.Linq
open JetBrains.ProjectModel
open JetBrains.ReSharper.Psi.Modules
open JetBrains.ReSharper.Psi.Tree
open JetBrains.ReSharper.Plugins.FSharp.Psi
open JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Tree
open JetBrains.ReSharper.Plugins.FSharp.Psi.Util
open JetBrains.ReSharper.Plugins.FSharp.Psi.Parsing
open JetBrains.ReSharper.Plugins.FSharp.Tests.Common
open JetBrains.ReSharper.TestFramework
open JetBrains.ReSharper.Resources.Shell
open NUnit.Framework

[<FSharpTest>]
type FSharpElementFactoryTest() =
    inherit BaseTestWithSingleProject()

    let mutable testAction = Unchecked.defaultof<_>
    let languageService = FSharpLanguage.Instance.FSharpLanguageService

    member x.DoTest(action: IFSharpElementFactory -> unit) =
        testAction <- action
        x.DoTestSolution()

    override x.DoTest(_, project: IProject) =
        let psiModule = project.GetPsiModules().Single()
        let elementFactory = languageService.CreateElementFactory(psiModule)
        testAction elementFactory

    [<Test>]
    member x.``Open statement 01``() =
        x.DoTest(fun elementFactory ->
            let ns = "System.Linq"
            let openStatement = elementFactory.CreateOpenStatement(ns)
            Assert.AreEqual("open " + ns, openStatement.GetText()))
