using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Build.Editor
{
    public interface IBuildProfile
    {
        IProvider<string, IBuildStep> Steps { get; }

        void Execute(string id, IContext context);
    }
}
