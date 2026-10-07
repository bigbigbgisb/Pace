using Avalonia;
using Avalonia.Controls;
using Pace.ViewModels;
using Avalonia.Markup.Xaml;

namespace Pace.Views
{
    public partial class ProfilePage : UserControl
    {
        private readonly ProfilePageViewModel _viewModel;
        public ProfilePage(MainViewViewModel mainViewViewModel)
        {
            _viewModel = new ProfilePageViewModel(mainViewViewModel);
            DataContext = _viewModel;
            InitializeComponent();
        }
        public ProfilePage()
        {
            _viewModel = null!;
        }
    }
}