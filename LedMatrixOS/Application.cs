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

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        public Application(): base(false)
        {
            ModuleLoader moduleLoader = new ModuleLoader();
            moduleLoader.LoadModules();
            
            Controls.AddScroller("MainScroller", "P1Pin36", "P1Pin38");
            
            Rectangle rect = new Rectangle(0, 0, 31, 16, CanvasColor.RED);
            Rectangle rect1 = new Rectangle(0, 0, 31, 16, CanvasColor.GREEN);
            Rectangle rect2 = new Rectangle(0, 0, 31, 16, CanvasColor.YELLOW);
            Rectangle rect3 = new Rectangle(0, 0, 31, 16, CanvasColor.ORANGE);
            Rectangle rect4 = new Rectangle(0, 0, 31, 16, CanvasColor.PINK);
            Rectangle rect5 = new Rectangle(0, 0, 31, 16, CanvasColor.BLUE);
            Rectangle rect6 = new Rectangle(0, 0, 31, 16, CanvasColor.WHITE);

            StackPanel stack = new StackPanel();

            stack.Add(rect);
            stack.Add(rect1);
            stack.Add(rect2);
            stack.Add(rect3);
            stack.Add(rect4);
            stack.Add(rect5);
            stack.Add(rect6);

            ScrollLayout scrollLayout = new ScrollLayout("MainScroller");

            scrollLayout.Child = stack;

            Child = scrollLayout;
        }
        
        private void UpdateTime(object sender, ElapsedEventArgs args)
        {
            
        }
    }
}