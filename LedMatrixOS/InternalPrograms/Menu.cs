using System;
using LedMatrixCSharp.View;
using System.IO;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.Util;
using LedMatrixOSUtils;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using RaspberrySharp.IO.GeneralPurpose;

namespace LedMatrixOS.InternalPrograms
{
    public class Menu: MatrixProgram
    {
        private BDFFont font;
        private IEnumerable<MenuEntry> applications;

        public override void LoadProgramAsync()
        {
            Console.WriteLine("Load Menu");
            font = BDFFont.LoadFont5x7();

            ModuleLoader moduleLoader = new ModuleLoader();
            applications = moduleLoader.LoadModules();
        }

        public override void StartProgram()
        {
            Console.WriteLine("Start Menu");
            base.StartProgram();
            ListView listView = new ListView("MainScroller");
            listView.FixedHeight = 32;
            listView.FixedWidth = 32;

            foreach (var a in applications)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                Label l = new Label(a.Name, font, CanvasColor.WHITE);
                if (a.Stream != null)
                {
                    Image i = new Image(a.Stream);
                    i.X = 1;
                    i.Y = 1;
                    stackPanel.Add(i);
                    l.X = 2;
                }

                stackPanel.Add(l);

                listView.Add(stackPanel);
            }

            View = listView;
            
            Controls.Instance.OnButtonClick("ScrollerBtn", KnobClicked);
        }

        private void KnobClicked(object sender, PinStatusEventArgs e)
        {
            if (e.Enabled)
            {
                Controls.Instance.ButtonUnsubscribe("ScrollerBtn", KnobClicked);
                ProgramManager.StartProgram(applications.ToList()[0]);
            }
        }

        public override void UpdateProgram()
        {
            base.UpdateProgram();

        }
    }
}