using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor
{
    public abstract class BuildStep : IBuildStep
    {
        public string Name { get; }

        protected BuildStep(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
        }

        public void Execute(string id, IBuildProfile profile, IContext context)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (profile == null) throw new ArgumentNullException(nameof(profile));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(id, profile, context);
        }

        protected abstract void OnExecute(string id, IBuildProfile profile, IContext context);
    }
}
