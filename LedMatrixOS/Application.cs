using System;
using LedMatrixCSharp;
using LedMatrixCSharp.Utils;
using LedMatrixCSharp.View;
using LedMatrixCSharp.View.Layout;
using LedMatrixCSharp.View.Views;
using LedMatrixOS.Util;
using LedMatrixOS.Windows;
using Unosquare.RaspberryIO.Abstractions;
using Rectangle = LedMatrixCSharp.View.Views.Rectangle;

namespace LedMatrixOS
{
    public class Application: MatrixApplication
    {
        Rectangle rect;

        public Application(): base(false)
        {
            Controls.Instance.AddScroller("MainScroller", P1.Pin35, P1.Pin37);
            Controls.Instance.AddButton("ScrollerBtn", P1.Pin36);
            
            Child = new Menu().View;
        }
    }
}