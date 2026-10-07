using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pace.ViewModels;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pace.ViewModels
{
    public partial class LearnPageViewModel(MainViewViewModel mainViewViewModel) : ObservableObject
    {
        [ObservableProperty]
        MainViewViewModel _mainViewViewModel = mainViewViewModel;
        [RelayCommand]
        private async Task ShowTask(DailySport dailySport)
        {
            MainViewViewModel.TaskPage = new TaskPage(dailySport, MainViewViewModel);
            await MainViewViewModel.ShowFakeTransitionAsync("正在加载关卡噢...", () =>
            {
            }, MainViewViewModel.TaskPage);
        }
    }
}
