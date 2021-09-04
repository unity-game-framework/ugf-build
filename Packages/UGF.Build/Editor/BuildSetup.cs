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

            var setupWatch = Stopwatch.StartNew();

            for (int i = 0; i < Steps.Count; i++)
            {
                IBuildStep step = Steps[i];

                Debug.Log($"Build Step Start: '{step}'.");

                var stepWatch = Stopwatch.StartNew();

                step.Execute(this, context);

                stepWatch.Stop();

                Debug.Log($"Build Step End: '{step}', time: '{stepWatch.Elapsed.TotalMilliseconds}ms'.");
            }

            setupWatch.Stop();

            Debug.Log($"Build Setup End: '{Name}', time: '{setupWatch.Elapsed.TotalMilliseconds}ms'.");
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().FullName})";
        }
    }
}
