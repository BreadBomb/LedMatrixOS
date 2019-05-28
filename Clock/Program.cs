using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Views;
using LedMatrixOSUtils;
using System;
using System.Collections.Generic;
using System.Text;
using LedMatrixCSharp.View.Layout;

namespace Clock
{
    class Program : MatrixProgram
    {
        BDFFont font;
        Label hours;
        Label minutes;
        Label dots;

        public override void LoadProgramAsync()
        {
            Console.WriteLine("Load Clock");
            base.LoadProgramAsync();
            font = BDFFont.LoadFont9x15();
        }

        public override void StartProgram()
        {
            base.StartProgram();
            Console.WriteLine("Start Clock");

            StackPanel time = new StackPanel();
            
            hours = new Label("00", font, CanvasColor.WHITE);
            
            time.Add(hours);
            
            StackPanel dotsMinutes = new StackPanel();
            dotsMinutes.Orientation = Orientation.Horizontal;

            dots = new Label(":", font, CanvasColor.WHITE);
            minutes = new Label("00", font, CanvasColor.WHITE);

            dotsMinutes.Add(dots);
            dotsMinutes.Add(minutes);
            
            time.Add(dotsMinutes);
            
            Console.WriteLine($"{time.Width} {time.Height}");
            
            View = dots;
        }

        public override void UpdateProgram()
        {
            hours.Text = DateTime.Now.ToString("HH");
            minutes.Text = DateTime.Now.ToString("mm");

            base.UpdateProgram();
        }
    }
}
