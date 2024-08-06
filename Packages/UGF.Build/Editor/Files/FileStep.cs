using System;
using System.Collections.Generic;
using System.IO;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Build.Editor.Files
{
    public class FileStep : BuildStep
    {
        public IReadOnlyList<CopyData> Copy { get; }

        public readonly struct CopyData
        {
            public string From { get; }
            public string To { get; }

            public CopyData(string from, string to)
            {
                if (string.IsNullOrEmpty(from)) throw new ArgumentException("Value cannot be null or empty.", nameof(from));
                if (string.IsNullOrEmpty(to)) throw new ArgumentException("Value cannot be null or empty.", nameof(to));

                From = from;
                To = to;
            }
        }

        public FileStep(IReadOnlyList<CopyData> copy)
        {
            Copy = copy ?? throw new ArgumentNullException(nameof(copy));
        }

        protected override void OnExecute(IBuildSetup setup, IContext context)
        {
            for (int i = 0; i < Copy.Count; i++)
            {
                CopyData copy = Copy[i];

                File.Copy(copy.From, copy.To, true);

                Logger.Info("Copy", new
                {
                    copy.From,
                    copy.To
                });
            }
        }
    }
}
