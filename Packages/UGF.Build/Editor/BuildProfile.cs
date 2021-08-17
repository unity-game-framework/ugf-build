using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Build.Editor
{
    public class BuildProfile : IBuildProfile
    {
        public string Name { get; }
        public IProvider<string, IBuildStep> Steps { get; }
        public IList<string> StepsOrder { get; }

        public BuildProfile(string name) : this(name, new Provider<string, IBuildStep>(), new List<string>())
        {
        }

        public BuildProfile(string name, IProvider<string, IBuildStep> steps, IList<string> stepsOrder)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
            StepsOrder = stepsOrder ?? throw new ArgumentNullException(nameof(stepsOrder));
        }

        public void Execute(string id, IContext context)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(id, context);
        }

        protected virtual void OnExecute(string id, IContext context)
        {
            for (int i = 0; i < StepsOrder.Count; i++)
            {
                string stepId = StepsOrder[i];
                IBuildStep step = Steps.Get(stepId);

                step.Execute(stepId, this, context);
            }
        }
    }
}
