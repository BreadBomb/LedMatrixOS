using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
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
                Label l = new Label(a, font, CanvasColor.WHITE);
                listView.Add(l);
            }
            
            Child = listView;
        }
    }
}