using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.Util;
using System;
using System.Timers;

namespace Clock
{
    class Program : MatrixProgram
    {
        BDFFont font;
        Label hours;
        Label minutes;
        Label dots;

        bool an = true;

        Timer t;

        public override void LoadProgramAsync()
        {
            Console.WriteLine("Load Clock");
            base.LoadProgramAsync();
            font = BDFFont.LoadFont8x13B();
        }

        public override void StartProgram()
        {
            base.StartProgram();
            Console.WriteLine("Start Clock");

            StackPanel time = new StackPanel();
            time.X = 4;
            time.Y = 3;
            
            hours = new Label(" 00", font, CanvasColor.WHITE);
            
            time.Add(hours);
            
            StackPanel dotsMinutes = new StackPanel();
            dotsMinutes.Orientation = Orientation.Horizontal;

            dots = new Label(":", font, CanvasColor.WHITE);
            minutes = new Label("00", font, CanvasColor.WHITE);

            dotsMinutes.Add(dots);
            dotsMinutes.Add(minutes);
            
            time.Add(dotsMinutes);
            
            t = new Timer();
            t.Interval = 500;
            t.Elapsed += (s, a) =>
            {                
                Console.WriteLine(dots.Text);
                if (an)
                {
                    dots.Text = " ";
                    an = false;
                }
                else
                {
                    dots.Text = ":";
                    an = true;
                }
            };
            t.Start();

            View = time;
        }

        public override void UpdateProgram()
        {
            hours.Text = DateTime.Now.ToString(" HH");
            minutes.Text = DateTime.Now.ToString("mm");

            base.UpdateProgram();
        }
    }
}
