using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pace.ViewModels
{
    public partial class TaskPageViewModel : ObservableObject
    {
        private readonly ImageLoader _imageLoader = new();
        private int _burnedCalories;

        [ObservableProperty]
        TimingButtonViewModel _timingButtonViewModel = new();
        [ObservableProperty]
        DailySport _dailySport;
        [ObservableProperty]
        MainViewViewModel mainViewViewModel;
        [ObservableProperty]
        int _index = 0;
        

        [ObservableProperty]
        Bitmap[]? _currentImages;
        [ObservableProperty]
        ISportItem _currentSportItem;

        public TaskPageViewModel(DailySport dailySport, MainViewViewModel mainViewViewModel)
        {
            DailySport = dailySport;
            MainViewViewModel = mainViewViewModel;
            CurrentSportItem = DailySport.SportItems[Index];
            _ = LoadImagesAsync();

        }
        [RelayCommand]
        private async Task NextRole()
        {
            
            if (TimingButtonViewModel.IsClickedTimingButton)
            {
                Index++;
                if (Index <= DailySport.SportItems.Length - 1)
                {
                    await MainViewViewModel.ShowTransitionAsync("下一关正在跑来...", async () =>
                    {
                        CurrentSportItem = DailySport.SportItems[Index];
                        await LoadImagesAsync();

                    }, MainViewViewModel.TaskPage);
                    MainViewViewModel.MainViewModel.UserProfile.BurnedCalories += DailySport.SportItems[Index - 1].BurnedCalories;
                    _burnedCalories += DailySport.SportItems[Index - 1].BurnedCalories;
                }
                else
                {
                    MainViewViewModel.MainViewModel.UserProfile.BurnedCalories += DailySport.SportItems[Index - 1].BurnedCalories;
                    _burnedCalories += DailySport.SportItems[Index - 1].BurnedCalories;
                    if (!MainViewViewModel.MainViewModel.UserProfile.HasTodayCheckedIn) 
                    {
                        MainViewViewModel.MainViewModel.UserProfile.WiningStreakDays++;
                        MainViewViewModel.MainViewModel.UserProfile.HasTodayCheckedIn = true;
                    }
                    //跳转至成功页
                    MainViewViewModel.CurrentPage = new TaskSuccessPage(_burnedCalories, Index + 1, TimingButtonViewModel.TotalPassedTime, MainViewViewModel);
                    MainViewViewModel.MainViewModel.ApplicationDataService.WriteData(MainViewViewModel.MainViewModel, MainViewViewModel.MainViewModel.BaseDirectoryPath);
                    
                }
    
            }
            await TimingButtonViewModel.ToggleTiming();

        }

        public async Task LoadImagesAsync()
        {
            Bitmap[]? bitmaps = await _imageLoader.GetImagesAsync(CurrentSportItem.LegendRootPath);
            CurrentImages = bitmaps ?? [];
        }

        [RelayCommand]
        private void Back()
        {
            MainViewViewModel.CurrentPage = MainViewViewModel.LearnPage;
        }
    }
}
