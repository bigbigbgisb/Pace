using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Pace.ViewModels;
using Ursa.Controls;

namespace Pace.Views
{
    public partial class TaskPage : UserControl
    {
        private readonly TaskPageViewModel? _viewModel;
        public TaskPage(DailySport dailySport, MainViewViewModel mainViewViewModel)
        {
            _viewModel = new TaskPageViewModel(dailySport, mainViewViewModel);
            DataContext = _viewModel;
            InitializeComponent();
        }
        public TaskPage()
        {

        }

    }
}