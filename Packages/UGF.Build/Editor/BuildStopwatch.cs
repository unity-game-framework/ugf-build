using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace UGF.Build.Editor
{
    public readonly struct BuildStopwatch : IDisposable
    {
        public object Target { get; }
        public bool Log { get; }
        public string StartMessage { get; }
        public string EndMessage { get; }
        public Stopwatch Stopwatch { get; }

        public BuildStopwatch(object target, bool log = true, string startMessage = "Start: '{0}'.", string endMessage = "End: '{0}', time: '{1}ms'.")
        {
            if (string.IsNullOrEmpty(startMessage)) throw new ArgumentException("Value cannot be null or empty.", nameof(startMessage));
            if (string.IsNullOrEmpty(endMessage)) throw new ArgumentException("Value cannot be null or empty.", nameof(endMessage));

            Target = target ?? throw new ArgumentNullException(nameof(target));
            Log = log;
            StartMessage = startMessage;
            EndMessage = endMessage;
            Stopwatch = Stopwatch.StartNew();

            if (Log)
            {
                Debug.Log(string.Format(StartMessage, Target));
            }
        }

        public void Dispose()
        {
            Stopwatch.Stop();

            if (Log)
            {
                Debug.Log(string.Format(EndMessage, Target, Stopwatch.Elapsed.TotalMilliseconds));
            }
        }
    }
}
