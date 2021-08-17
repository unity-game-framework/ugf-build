using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor
{
    public interface IBuildStep
    {
        void Execute(string id, IBuildProfile profile, IContext context);
    }
}
