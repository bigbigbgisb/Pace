using Avalonia.Controls;
using Pace.ViewModels;
using System;

namespace Pace.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ContentControl.Content = new MainView(new MainViewModel(AppContext.BaseDirectory));
    }
}