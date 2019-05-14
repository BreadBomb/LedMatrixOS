using System;
using System.IO;
using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.InternalPrograms;
using LedMatrixOS.Util;
using Unosquare.RaspberryIO.Abstractions;
using Rectangle = LedMatrixCSharp.View.Views.Rectangle;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        public Application() : base(false)
        {
            Controls.Instance.AddScroller("MainScroller", P1.Pin35, P1.Pin37);
            Controls.Instance.AddButton("ScrollerBtn", P1.Pin36);

            Menu menu = new Menu();

            ProgramManager.StartProgram(menu);

            ProgramManager.ViewChanged += () =>
            {
                Console.WriteLine("View Changed");
                Child = ProgramManager.ActiveProgram.View;
            };

            Child = ProgramManager.ActiveProgram.View;
        }
    }
}