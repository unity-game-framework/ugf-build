using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Build.Editor
{
    public abstract class BuildStepCollectionAsset : ScriptableObject
    {
        public void GetSteps(ICollection<IBuildStep> steps)
        {
            if (steps == null) throw new ArgumentNullException(nameof(steps));

            OnGetSteps(steps);
        }

        protected abstract void OnGetSteps(ICollection<IBuildStep> steps);
    }
}
