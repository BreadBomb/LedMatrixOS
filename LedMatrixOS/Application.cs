using System;    
using System.ComponentModel;
using System.Net;
using System.Timers;
using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Views;
using LedMatrixCSharp.View.Layout;
using LedMatrixOS.Util;
using System.Diagnostics;
using Unosquare.RaspberryIO.Abstractions;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        Rectangle rect;

        public Application(): base(false)
        {
            ModuleLoader moduleLoader = new ModuleLoader();
            moduleLoader.LoadModules();
            
            Controls.Instance.AddScroller("MainScroller", P1.Pin35, P1.Pin37);

            ScrollLayout scrollLayout = new ScrollLayout("MainScroller");

            StackPanel stackPanel = new StackPanel();

            Rectangle rect1 = new Rectangle(0, 0, 32, 32, CanvasColor.PINK, CanvasColor.WHITE);
            Rectangle rect2 = new Rectangle(0, 0, 31, 16, CanvasColor.RED);
            Rectangle rect3 = new Rectangle(0, 0, 31, 16, CanvasColor.GREEN);
            Rectangle rect4 = new Rectangle(0, 0, 31, 16, CanvasColor.ORANGE);

            stackPanel.Add(rect1);
            stackPanel.Add(rect2);
            stackPanel.Add(rect3);
            stackPanel.Add(rect4);

            Child = stackPanel;
        }
    }
}