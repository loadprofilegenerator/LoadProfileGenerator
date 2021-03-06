﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using MigraDoc.DocumentObjectModel;

namespace ChartCreator2.PDF {
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    internal interface IPageCreator {
        [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
        void MakePage([JetBrains.Annotations.NotNull] Document doc, [JetBrains.Annotations.NotNull] string dstdir, bool requireAll);
    }
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    internal interface IPageCreatorToc {
        void MakePage([JetBrains.Annotations.NotNull] Document doc, [JetBrains.Annotations.NotNull] string dstdir, bool requireAll, [ItemNotNull] [JetBrains.Annotations.NotNull] List<string> pngFiles, [JetBrains.Annotations.NotNull] Section tocSection);
    }
}