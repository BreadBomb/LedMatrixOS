using System;
using System.Threading;
using LedMatrixOSUtils;

namespace LedMatrixOS.Util
{
    public class ProgramManager
    {
        public delegate void OnViewChanged();
        public static event OnViewChanged ViewChanged;

        public static IMatrixProgram ActiveProgram { get; set; }

        public static void StartProgram(IMatrixProgram program)
        {
            program.LoadProgram((s,a) =>
            {
                Console.WriteLine("Start program");
                program.StartProgram();
                ViewChanged();
            });
            Console.WriteLine("CHange View");
            ViewChanged();
            ActiveProgram = program;
        }

        public static void StopActiveProgram()
        {
            ActiveProgram = null;
        }
    }
}