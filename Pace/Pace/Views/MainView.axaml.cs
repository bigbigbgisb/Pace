
using Avalonia;
using System;
using Avalonia.Controls;
using Pace.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Avalonia.Media;
using System.Threading.Tasks;

namespace Pace.Views;

public partial class MainView : UserControl
{
    private readonly MainViewViewModel? _viewModel;
    public MainView(MainViewModel? mainViewModel)
    {
        ArgumentNullException.ThrowIfNull(mainViewModel);
        _viewModel = new MainViewViewModel(mainViewModel);
        DataContext = _viewModel;

        InitializeComponent();
        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
    }
    public MainView()
    {

    }

    private async void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_viewModel.CurrentPage))
        {
            if (_viewModel is not null &&  _viewModel.CurrentPage is null)
            {
                HandleButtonClicked(Home);
            }    
        }
    }



    public void NavButtonClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        HandleButtonClicked(sender);
    }

    private void HandleButtonClicked(object? sender)
    {
        if (_viewModel is null) return;
        if (!_viewModel.IsSetup) return;
        
        List<Button> navButtons = [..(Navs.Children.OfType<Button>())];

        navButtons.ForEach(btn =>
        {
            if (btn.Content is not TextBlock textBlock) return;
            btn.Background = Brush.Parse(_viewModel.MainViewModel.ThemeViewModel.VantaColor);
            textBlock.Foreground = Brush.Parse(_viewModel.MainViewModel.ThemeViewModel.LightForeground);
        });
        if (sender is Button selectedButton && selectedButton.Content is TextBlock textBlock)
        {
            selectedButton.Background = Brush.Parse(_viewModel.MainViewModel.ThemeViewModel.LightForeground);
            textBlock.Foreground = Brush.Parse(_viewModel.MainViewModel.ThemeViewModel.VantaColor);
        }
    }

}