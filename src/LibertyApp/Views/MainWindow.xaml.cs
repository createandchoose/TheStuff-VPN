using LibertyApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace LibertyApp.Views;

public partial class MainWindow : Window

{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<MainWindowViewModel>();
    }

    private void OnWindowInitialized(object sender, EventArgs e)
    {
        RefreshMaximizeRestoreButton();
    }

    private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void OnMaximizeRestoreButtonClick(object sender, RoutedEventArgs e)
    {
        if (App.Current.MainWindow.WindowState == WindowState.Maximized)
        {
            App.Current.MainWindow.WindowState = WindowState.Normal;
        }
        else if (App.Current.MainWindow.WindowState == WindowState.Normal)
        {
            App.Current.MainWindow.WindowState = WindowState.Maximized;
        }
    }

    private void OnCloseButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void RefreshMaximizeRestoreButton()
    {
        if (WindowState == WindowState.Maximized)
        {
            RestoreButton.Visibility = Visibility.Visible;
        }
        else
        {
            RestoreButton.Visibility = Visibility.Collapsed;
        }
    }

    private void WindowStateChangedHandler(object sender, EventArgs e)
    {
        RefreshMaximizeRestoreButton();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        AboutWindow aboutwindow = new AboutWindow();
        aboutwindow.Show();
        double workHeight = SystemParameters.WorkArea.Height;
        double workWidth = SystemParameters.WorkArea.Width;
        aboutwindow.Top = (workHeight - this.Height) / 1.5;
        aboutwindow.Left = (workWidth - this.Width) / 2.225;
    }
}

