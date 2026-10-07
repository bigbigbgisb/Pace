using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Pace.Views;
using System;
using System.Diagnostics;

namespace Pace.ViewModels
{

    public partial class TaskSuccessPage : UserControl
    {
        private MainViewViewModel? _viewModel;
        public TaskSuccessPage(int burnedCalories, int taskCount, int time, MainViewViewModel mainViewViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewViewModel;
            DataContext = _viewModel;
            Time.Text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
            TaskCount.Text = taskCount.ToString();
            Calories.Text = burnedCalories.ToString();
        }
        public TaskSuccessPage()
        {

        }
        private void ConfirmButton_Clicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _viewModel?.CurrentPage = _viewModel.LearnPage;
        }
    }
}