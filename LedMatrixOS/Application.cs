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

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        Rectangle rect;

        public Application(): base(false)
        {
            ModuleLoader moduleLoader = new ModuleLoader();
            moduleLoader.LoadModules();
            
            Controls.AddScroller("MainScroller", "P1Pin36", "P1Pin38");
            
            rect = new Rectangle(0, 0, 31, 16, CanvasColor.YELLOW);
            Rectangle rect1 = new Rectangle(0, 0, 16, 16, CanvasColor.GREEN);

            StackPanel stack = new StackPanel();

            stack.Children.Add(rect1);
            stack.Children.Add(rect);

            //ScrollLayout scrollLayout = new ScrollLayout("MainScroller");

            //scrollLayout.Child = stack;

            Child = stack;

        }
    }
}