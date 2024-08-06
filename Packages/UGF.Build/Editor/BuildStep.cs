using System;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEditor;

namespace UGF.Build.Editor
{
    public abstract class BuildStep : IBuildStep
    {
        public string Name { get; }
        public ILog Logger { get; }

        protected BuildStep()
        {
            Name = ObjectNames.NicifyVariableName(GetType().Name);
            Logger = Log.CreateWithLabel(Name);
        }

        protected BuildStep(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
            Logger = Log.CreateWithLabel(Name);
        }

        public void Execute(IBuildSetup setup, IContext context)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(setup, context);
        }

        protected abstract void OnExecute(IBuildSetup setup, IContext context);

        public override string ToString()
        {
            return $"{Name} ({GetType().FullName})";
        }
    }
}
