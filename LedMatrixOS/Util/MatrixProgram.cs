using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.InternalPrograms;
using RaspberrySharp.IO.GeneralPurpose;

namespace LedMatrixOS.Util
{
    public class MatrixProgram : IMatrixProgram
    {
        public View View { get; set; } = null;
        BackgroundWorker worker;
        ManualResetEvent onLoaded = new ManualResetEvent(false);

        BDFFont menuFont;

        bool menuIsShown = false;

        public void LoadProgram(RunWorkerCompletedEventHandler onComplete)
        {
            ImageSequence imageSequence = new ImageSequence(Path.Join(Environment.CurrentDirectory, "Animations", "Loading"));
            View = imageSequence;

            worker = new BackgroundWorker();
            worker.DoWork += (s, a) =>
            {
                menuFont = BDFFont.LoadFont5x7();
                LoadProgramAsync();
            };
            worker.RunWorkerCompleted += onComplete;
            worker.RunWorkerAsync();
        }

        public virtual void LoadProgramAsync() {}

        public virtual void StartProgram()
        {
            worker.Dispose();
            Controls.Instance.OnButtonClick("ScrollerBtn", KnobClicked);
        }

        private void KnobClicked(object sender, PinStatusEventArgs e)
        {
            if (e.Enabled)
            {
                if (!menuIsShown)
                {
                    ListView menu = new ListView("MainScroller");
                    menu.Width = 32;

                    Label l = new Label("Close", menuFont, CanvasColor.WHITE);

                    menu.Add(l);

                    View = menu;

                    menuIsShown = true;
                } else
                {
                    ProgramManager.StartProgram(new Menu());
                }
            }
        }

        public virtual void UpdateProgram()
        {
        }
    }
}
