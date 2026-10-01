
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
    }
    public MainView()
    {

    }


}