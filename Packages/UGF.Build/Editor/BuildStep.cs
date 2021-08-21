﻿using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor
{
    public abstract class BuildStep : IBuildStep
    {
        public string Name { get; }

        protected BuildStep() : this("Untitled Step")
        {
        }

        protected BuildStep(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
        }

        public void Execute(IBuildSetup setup, IContext context)
        {
            if (setup == null) throw new ArgumentNullException(nameof(setup));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(setup, context);
        }

        protected abstract void OnExecute(IBuildSetup setup, IContext context);
    }
}
