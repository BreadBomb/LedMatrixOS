using System;
using System.Timers;

namespace LedMatrixOS.Util
{
    public class ProgramManager
    {
        public delegate void OnViewChanged();
        public static event OnViewChanged ViewChanged;

        public static IMatrixProgram ActiveProgram { get; set; }

        private static Timer timer;

        public static void StartProgram(IMatrixProgram program)
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 100;
                timer.Elapsed += (s, a) =>
                {
                    ActiveProgram.UpdateProgram();
                    ViewChanged?.Invoke();
                };
            }

            if (ActiveProgram != null)
            {
                StopActiveProgram();
            }
            program.LoadProgram((s,a) =>
            {
                program.StartProgram();
                timer.Start();
                ViewChanged?.Invoke();
            });
            ActiveProgram = program;
            ViewChanged?.Invoke();
        }

        public static void StopActiveProgram()
        {
            ActiveProgram = null;
            timer.Stop();
            ViewChanged?.Invoke();
        }
    }
}