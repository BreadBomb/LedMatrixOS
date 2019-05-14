using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Views;
using LedMatrixOSUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clock
{
    class Program : MatrixProgram
    {
        BDFFont font;
        Label l;

        public override void LoadProgramAsync()
        {
            base.LoadProgramAsync();
            font = BDFFont.LoadFont4x6();
        }

        public override void StartProgram()
        {
            base.StartProgram();
            Console.WriteLine("Start");

            l = new Label("00", font, CanvasColor.WHITE);

            View = l;
        }

        public override void UpdateProgram()
        {
            l.Text = DateTime.Now.ToString("HH:mm");

            base.UpdateProgram();
        }
    }
}
