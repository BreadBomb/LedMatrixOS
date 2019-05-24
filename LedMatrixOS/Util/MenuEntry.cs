using LedMatrixCSharp.View;
using LedMatrixOSUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace LedMatrixOS.Util
{
    public class MenuEntry : IMatrixProgram
    {
        public View View {
            get
            {
                return _View.GetValue(ProgramInstance) as View;  
            }
        }

        public string Name { get; set; }
        public Stream Stream { get; set; }
        public MethodInfo _LoadProgram { get; set; }
        public MethodInfo _StartProgram { get; set; }
        public MethodInfo _UpdateProgram { get; set; }
        public PropertyInfo _View { get; set; }
        public object ProgramInstance { get; set; }

        public void LoadProgram(RunWorkerCompletedEventHandler onComplete)
        {
            _LoadProgram.Invoke(ProgramInstance, new object[] { onComplete });
        }

        public void StartProgram()
        {
            _StartProgram.Invoke(ProgramInstance, null);
        }

        public void UpdateProgram()
        {
            _UpdateProgram.Invoke(ProgramInstance, null);
        }
    }
}
