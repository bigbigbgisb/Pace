using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Pace.ViewModels;

namespace Pace.Views
{
    public partial class TransitionPage : UserControl

    {
        private readonly TransitionPageViewModel? _viewModel;
        private readonly string? _message;
        public TransitionPage(string message,MainViewModel mainViewModel)
        {
            _viewModel = new TransitionPageViewModel(mainViewModel);
            DataContext = _viewModel;
            _message = message;
            Loaded += TransitionPage_Loaded;
            InitializeComponent();
        }

        private void TransitionPage_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Message.Text = _message;
        }

        public TransitionPage()
        {
            InitializeComponent();
        }
    }
}