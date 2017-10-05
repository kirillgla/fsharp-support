﻿using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Plugins.FSharp.ProjectModelBase;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Impl;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi
{
  public class FSharpPsiProperties : DefaultPsiProjectFileProperties
  {
    public FSharpPsiProperties([NotNull] IProjectFile projectFile, [NotNull] IPsiSourceFile sourceFile)
      : base(projectFile, sourceFile)
    {
    }

    public override bool ProvidesCodeModel =>
      ProjectFile.Properties.BuildAction.IsCompile() ||
      ProjectFile.LanguageType.Equals(FSharpScriptProjectFileType.Instance);

    public override bool ShouldBuildPsi => true;
  }
}