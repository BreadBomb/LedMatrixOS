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

            ScrollLayout layout = new ScrollLayout("da");
            
            AnimatedChar hour1 = new AnimatedChar('0');
            AnimatedChar hour2 = new AnimatedChar('0');
            AnimatedChar dot = new AnimatedChar(':');
            AnimatedChar minute1 = new AnimatedChar('0');
            AnimatedChar minute2 = new AnimatedChar('0');
            AnimatedChar dot2 = new AnimatedChar(':');
            AnimatedChar second1 = new AnimatedChar('0');
            AnimatedChar second2 = new AnimatedChar('0');

            StackPanel stackPanel = new StackPanel();
            StackPanel stackPanel2 = new StackPanel();
            StackPanel stackPanel3 = new StackPanel();


            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel3.Orientation = Orientation.Horizontal;
            
            stackPanel.Add(hour1);
            stackPanel.Add(hour2);
            stackPanel.Add(dot);
            stackPanel.Add(minute1);
            stackPanel.Add(minute2);
            
            
            stackPanel3.Add(second1);
            stackPanel3.Add(second2);
            
            
            stackPanel2.Add(stackPanel);
            stackPanel2.Add(stackPanel3);
            
            Child = stackPanel2;

            Timer t = new Timer();
            t.Elapsed += (s, a) =>
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                
                hour1.ChangeChar(time[0]);
                hour2.ChangeChar(time[1]);
                minute1.ChangeChar(time[3]);
                minute2.ChangeChar(time[4]);
                second1.ChangeChar(time[6]);
                second2.ChangeChar(time[7]);
            };
            t.Interval = 1000;
            t.Start();
        }
    }
}