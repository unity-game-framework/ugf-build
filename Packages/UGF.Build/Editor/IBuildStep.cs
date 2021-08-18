using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor
{
    public interface IBuildStep
    {
        void Execute(IBuildSetup setup, IContext context);
    }
}
