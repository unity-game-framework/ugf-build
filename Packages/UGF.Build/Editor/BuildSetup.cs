using System;
using System.Collections.Generic;
using System.Diagnostics;
using UGF.RuntimeTools.Runtime.Contexts;
using Debug = UnityEngine.Debug;

namespace UGF.Build.Editor
{
    public class BuildSetup : IBuildSetup
    {
        public string Name { get; }
        public List<IBuildStep> Steps { get; } = new List<IBuildStep>();

        IReadOnlyList<IBuildStep> IBuildSetup.Steps { get { return Steps; } }

        public BuildSetup(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
        }

        public void Execute(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(context);
        }

        protected virtual void OnExecute(IContext context)
        {
            Debug.Log($"Build Setup Start: '{Name}'.");

            for (int i = 0; i < Steps.Count; i++)
            {
                IBuildStep step = Steps[i];

                Debug.Log($"Build Step Start: '{step}'.");

                var watch = Stopwatch.StartNew();

                step.Execute(this, context);

                watch.Stop();

                Debug.Log($"Build Step End: '{step}', time: '{watch.Elapsed.TotalMilliseconds}ms'.");
            }

            Debug.Log($"Build Setup End: '{Name}'.");
        }
    }
}
