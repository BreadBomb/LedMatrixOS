using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixOS.InternalPrograms;
using LedMatrixOS.Util;
using RaspberrySharp.IO.GeneralPurpose;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        public Application() : base(false)
        {
            Controls.Instance.AddScroller("MainScroller", ProcessorPin.Gpio35, ProcessorPin.Gpio37);
            Controls.Instance.AddButton("ScrollerBtn", ProcessorPin.Gpio16);

            Menu menu = new Menu();

            ProgramManager.StartProgram(menu);

            ProgramManager.ViewChanged += () =>
            {
                Child = ProgramManager.ActiveProgram?.View;
            };

            Child = ProgramManager.ActiveProgram?.View;
        }
    }
}