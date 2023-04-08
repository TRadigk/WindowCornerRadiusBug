// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI;
using Microsoft.UI.Xaml;
using System;
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
            var windowPresenter = (appWindow.Presenter as OverlappedPresenter);
            windowPresenter.SetBorderAndTitleBar(true, false);
            //windowPresenter.IsResizable = false;
        }

        public static AppWindow GetAppWindowFromWindow(Window windowRef)
        {
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(windowRef);
            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(myWndId);
        }
    }
}