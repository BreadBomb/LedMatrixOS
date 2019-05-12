using System;
using LedMatrixCSharp.View;
using System.IO;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.Util;

namespace LedMatrixOS.Windows
{
    public class MenuEntry
    {
        public string Name { get; set; }
        public Stream Stream { get; set; }
    }

    public class Menu: Window
    {
        public Menu()
        {
            ModuleLoader moduleLoader = new ModuleLoader();
            var applications = moduleLoader.LoadModules();
            
            ListView listView = new ListView("MainScroller");
            listView.FixedHeight = 32;
            listView.FixedWidth = 32;

            var font = BDFFont.LoadFont5x7();

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

                View = listView;
            }
            
            Controls.Instance.OnButtonClick("ScrollerBtn", () =>
            {
                Console.WriteLine("BUTTON!!!!");
            });
        }
    }
}