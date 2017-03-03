﻿using JetBrains.ReSharper.Psi.FSharp.Tree;

namespace JetBrains.ReSharper.Psi.FSharp.Impl.Tree
{
  internal partial class FSharpStructDeclaration
  {
    public override string DeclaredName => Identifier.GetName();

    public override void SetName(string name)
    {
    }

    public override TreeTextRange GetNameRange()
    {
      return Identifier.GetNameRange();
    }

    public FSharpObjectModelTypeKind TypeKind => FSharpObjectModelTypeKind.Struct;
  }
}