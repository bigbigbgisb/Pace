using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pace.ViewModel;
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Pace.Views
{
    public partial class MainViewViewModel : ObservableObject
    {

        private readonly SportGenerateService _service = new();
        [ObservableProperty]
        MainViewModel _mainViewModel;

        [ObservableProperty]
        DispatcherTimer _timer;
        [ObservableProperty]
        NavButtonViewModel _navButtonViewModel;
        [ObservableProperty]
        bool _isSetup = false;
        [ObservableProperty]
        object? _currentPage;
        [ObservableProperty]
        SetupPage _setupPage;

        [ObservableProperty]
        LearnPage _learnPage;
        [ObservableProperty]
        TaskPage? _taskPage;
        [ObservableProperty]
        ProfilePage? _profilePage;

        [RelayCommand]
        private void ToHome()
        {
            if (IsSetup)
            {
                NavButtonViewModel.SelectNavCommand.Execute("Home");
                CurrentPage = LearnPage;
            }
        }
        [RelayCommand]
        private void ToAchievement()
        {
            if (IsSetup)
            {
                NavButtonViewModel.SelectNavCommand.Execute("Achievement");
            }
        }
        [RelayCommand]
        private void ToMoments()
        {
            if (IsSetup)
            {
                NavButtonViewModel.SelectNavCommand.Execute("Moments");
            }
        }
        [RelayCommand]
        private void ToProfile()
        {
            if (IsSetup)
            {
                NavButtonViewModel.SelectNavCommand.Execute("Profile");
                CurrentPage = ProfilePage;
            }
        }
        public void CalculateDailySports()
        {
            _ = ShowTransitionAsync("正在分配每日个性化运动...", async () =>
            {
                List<DailySport> dailySportList = [];


                for (int i = 1; i <= 3; i++)
                {
                    var dailySport = await _service.GenerateDailySports(MainViewModel.UserProfile.BasalMetabolicRate, MainViewModel.UserProfile.Height, MainViewModel.UserProfile.Weight);
                    dailySportList.Add(dailySport);
                }


                MainViewModel.DailySportRepository.DailySports = dailySportList;
                MainViewModel.ApplicationDataService.WriteData(MainViewModel, MainViewModel.BaseDirectoryPath);
                ToHome();
            }
                , LearnPage);
        }

        partial void OnCurrentPageChanged(object? value)
        {

            if (value is null)
            {
                CalculateDailySports();
                IsSetup = true;
                if (ProfilePage is null) ProfilePage = new(this);
            }


        }

        //该函数为私有函数，用于ShowTransitionAsync与ShowFakeTransitionAsync，仅用于抽离函数体，提高优雅性
        private async Task ShowTransitionBaseAsync(string message, Func<Task> function, UserControl? targetPage, int interval = 2000)
        {
            ArgumentNullException.ThrowIfNull(targetPage);
            var transitionPage = new TransitionPage(message, MainViewModel);
            CurrentPage = transitionPage;
            try
            {
                await Task.Delay(interval);
                await function();
            }
            finally
            {
                CurrentPage = targetPage;
            }
        }


        public async Task ShowTransitionAsync(string message, Func<Task> function, UserControl? targetPage)
        {
            await ShowTransitionBaseAsync(message, function, targetPage, 0);
        }
        public async Task ShowFakeTransitionAsync(string message, Action function, UserControl? targetPage, int interval = 2000)
        {
            await ShowTransitionBaseAsync(message, async () => function(), targetPage, interval);
        }


        public MainViewViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            SetupPage = new(MainViewModel);
            LearnPage = new(this);
            Timer = new()
            {
                Interval = TimeSpan.FromSeconds(30)
            };

            Timer.Tick += (s, e) =>
            {
                Cache? cache = MainViewModel.ApplicationDataService.ReadCache(MainViewModel.BaseDirectoryPath);
                if (cache is not null)
                {
                    if (cache.DateTime.Date < DateTime.Now.Date)
                    {
                        MainViewModel.ApplicationDataService.ResetDailyData(this);
                    }
                }
                MainViewModel.ApplicationDataService.WriteCache(MainViewModel.BaseDirectoryPath);
            };
            Timer.Start();
            NavButtonViewModel = new(mainViewModel.ThemeViewModel.VantaColor, mainViewModel.ThemeViewModel.LightForeground);
            if (!mainViewModel.ApplicationDataService.IsApplicationSetup(MainViewModel.BaseDirectoryPath))
            {
                CurrentPage = SetupPage;
            }
            else
            {
                if (mainViewModel.ApplicationDataService.ReadData(MainViewModel.BaseDirectoryPath) is UserApplicationData userApplicationData)
                {
                    mainViewModel.ApplicationDataService.ApplyTo(userApplicationData, this); 
                }
                ProfilePage = new(this);

            }



        }

    }
}
