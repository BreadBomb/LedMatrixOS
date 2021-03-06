﻿using LedMatrixCSharp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LedMatrixOS.Util
{
    public interface IMatrixProgram
    {
        View View { get; }

        void LoadProgram(RunWorkerCompletedEventHandler onComplete);
        void StartProgram();
        void UpdateProgram();
    }
}
