using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pace.Views
{
    public partial class LearnPage : UserControl
    {
        private readonly LearnPageViewModel? _viewModel;
        public LearnPage(MainViewViewModel mainViewViewModel)
        {
            _viewModel = new LearnPageViewModel(mainViewViewModel);
            DataContext = _viewModel;
            InitializeComponent();
        }

        public LearnPage()
        {

        }


        private void Button_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (sender is Grid grid && grid.DataContext is DailySport dailySport)
            {
                var children = grid.Children;
                children.Where(x => x is Ellipse ellipse).ToList()[0].Margin = dailySport.Margin + new Thickness(0,12,0,0);
                children.Where(x => x is TextBlock textBlock).ToList()[0].Margin = dailySport.Margin + new Thickness(0, 12, 0, 0);
            }
        }

        private async void Button_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {
            if (sender is Grid grid && grid.DataContext is DailySport dailySport)
            {
                var children = grid.Children;
                Ellipse ellipse = (children.Where(x => x is Ellipse ellipse).ToList()[0] as Ellipse)!;
                TextBlock textBlock = (children.Where(x => x is TextBlock textBlock).ToList()[0] as TextBlock)!;
                ellipse.Margin = dailySport.Margin;
                textBlock.Margin = dailySport.Margin;
                if (_viewModel is not null)
                   await  _viewModel.ShowTask(dailySport);
            }
        }
    }
}