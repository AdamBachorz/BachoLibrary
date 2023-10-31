using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace BachorzLibrary.Common.Tools
{
    public class PerformanceChecker
    {
        private readonly Stopwatch _stopwatch;
        private Thread _thread;

        public Action Action { get; set; }

        public PerformanceChecker(Action action)
        {
            Action = action;
            _stopwatch = new Stopwatch();
        }
        public void StartPerformance()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            Action();
            _stopwatch.Stop();
        }

        public void StartPerformanceAsync()
        {
            _thread = new Thread(StartPerformance);
            _thread.Start();
        }       

        public TimeSpan TimeSpan => _stopwatch.Elapsed;
        public bool NotMeasured => TimeSpan == TimeSpan.Zero;

        public string Report
        {
            get
            {
                if (_thread?.ThreadState == System.Threading.ThreadState.Running)
                {
                    return "Performance check is running. Wait until it's done.";
                }
                if (NotMeasured)
                {
                    return "Performance check didn't start yet";
                }

                var sb = new StringBuilder();
                sb.AppendLine($"Procedure: {Action.Method.Name}");
                sb.AppendLine($"Hours: {TimeSpan.Hours}");
                sb.AppendLine($"Minutes {TimeSpan.Minutes}");
                sb.AppendLine($"Seconds {TimeSpan.Seconds}");
                sb.AppendLine($"Milliseconds {TimeSpan.Milliseconds}");

                return sb.ToString();
            }
        }
    }
}
