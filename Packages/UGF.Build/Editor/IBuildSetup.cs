using System.Collections.Generic;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor
{
    public interface IBuildSetup
    {
        IReadOnlyList<IBuildStep> Steps { get; }

        void Execute(IContext context);
    }
}
