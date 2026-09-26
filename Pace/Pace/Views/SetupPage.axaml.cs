using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Pace.ViewModels;
using System;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Pace.Views
{
    public partial class SetupPage : UserControl
    {
        public SetupPage(MainViewModel? mainViewModel)
        {
            InitializeComponent();
            ArgumentNullException.ThrowIfNull(mainViewModel);
            DataContext = mainViewModel;

        }

        public SetupPage()
        {

        }
        private async void Confirm_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Parent is ContentControl contentControl)
            {
                bool? isDataValid = await CheckData();
                if (isDataValid is null) return;
                else if (isDataValid is bool b && b) contentControl.Content = null;
            }
        }

        private async Task<bool?> CheckData()
        {
            if (Confirm.Tag is bool b && b) return null;
            if (DataContext is not MainViewModel mainViewModel) return null;
            Confirm.Tag = true;
            (string tipText, bool isError) = mainViewModel.UserProfile.CheckProfileData(Weight.Text!, Height.Text!, Age.Text!, Gender.Text!);
            if (isError)
            {
                Confirm.Content = tipText + "错误";
                await Task.Delay(3000);
                Confirm.Content = "确认";
                Confirm.Tag = false;
                return false;
            }
            else
            {
                Confirm.Tag = false;
                return true;
            }
            
        }
    }
}