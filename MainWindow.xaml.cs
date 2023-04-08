// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Windowing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WindowCornerRadiusBug
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var appWindow = GetAppWindowFromWindow(this);
            appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            (appWindow.Presenter as OverlappedPresenter).SetBorderAndTitleBar(false, false);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }

        public static AppWindow GetAppWindowFromWindow(Window windowRef)
        {
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(windowRef);
            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(myWndId);
        }
    }
}
