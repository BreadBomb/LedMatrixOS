using System;
using System.IO;
using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.InternalPrograms;
using LedMatrixOS.Util;
using Unosquare.PiGpio.NativeEnums;
using Unosquare.RaspberryIO.Abstractions;
using Rectangle = LedMatrixCSharp.View.Views.Rectangle;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        public Application() : base(false)
        {
            Controls.Instance.AddScroller("MainScroller", SystemGpio.Bcm19, SystemGpio.Bcm26);
            Controls.Instance.AddButton("ScrollerBtn", SystemGpio.Bcm16);

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