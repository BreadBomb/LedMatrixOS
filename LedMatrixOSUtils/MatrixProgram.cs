using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Views;

namespace LedMatrixOSUtils
{
    public class MatrixProgram : IMatrixProgram
    {
        public View View { get; set; } = null;
        BackgroundWorker worker;
        ManualResetEvent onLoaded = new ManualResetEvent(false);

        public void LoadProgram(RunWorkerCompletedEventHandler onComplete)
        {
            ImageSequence imageSequence = new ImageSequence(Path.Join(Environment.CurrentDirectory, "Animations", "Loading"));
            View = imageSequence;

            worker = new BackgroundWorker();
            worker.DoWork += (s, a) =>
            {
                LoadProgramAsync();
            };
            worker.RunWorkerCompleted += onComplete;
            worker.RunWorkerAsync();
        }

        public virtual void LoadProgramAsync() {}

        public virtual void StartProgram()
        {
            worker.Dispose();
        }

        public virtual void UpdateProgram()
        {
        }
    }
}
