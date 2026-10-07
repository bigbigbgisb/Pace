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



    }
}