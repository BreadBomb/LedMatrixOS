using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.Util;
using Unosquare.RaspberryIO.Abstractions;
using Rectangle = LedMatrixCSharp.View.Views.Rectangle;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        Rectangle rect;

        public Application(): base(false)
        {
            ModuleLoader moduleLoader = new ModuleLoader();
            var applications = moduleLoader.LoadModules();
            
            Controls.Instance.AddScroller("MainScroller", P1.Pin35, P1.Pin37);


            ListView listView = new ListView("MainScroller");
            listView.FixedHeight = 32;
            listView.FixedWidth = 32;

            var font = BDFFont.LoadFont5x7();

            foreach (var a in applications)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                Label l = new Label(a.Name, font, CanvasColor.WHITE);
                if (a.Stream == null)
                {
                } else
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
            
            Child = listView;
        }
    }
}