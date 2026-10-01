using CommunityToolkit.Mvvm.ComponentModel;
using Pace.Views;

namespace Pace.ViewModels;

public partial class MainViewModel(string baseDirectoryPath) : ViewModelBase
{
    [ObservableProperty]
    ThemeViewModel _themeViewModel = new();
    [ObservableProperty]
    UserProfile _userProfile = new();
    [ObservableProperty]
    DailySportRepository _dailySportRepository = new();
    [ObservableProperty]
    string _baseDirectoryPath = baseDirectoryPath;
    [ObservableProperty]
    ApplicationDataService _applicationDataService = new();
}
