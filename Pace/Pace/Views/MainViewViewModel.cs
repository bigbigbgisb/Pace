using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [ObservableProperty]
        MainViewModel _mainViewModel;
        [ObservableProperty]
        bool isSetup = false;
        [ObservableProperty]
        object? _currentPage;
        [ObservableProperty]
        SetupPage _setupPage;

        [ObservableProperty]
        LearnPage _learnPage;
        [ObservableProperty]
        TaskPage? _taskPage;

        [RelayCommand]
        private void ToHome()
        {
            if (IsSetup)
            {
                CurrentPage = LearnPage;
            }
        }

        partial void OnCurrentPageChanged(object? value)
        {

            if (value is null)
            {
                _ = ShowTransitionAsync("正在分配每日个性化运动...", async () =>
                {
                    List<DailySport> dailySportList = [];

                    var service = new SportGenerateService();
                    for (int i = 1; i <= 12; i++)
                    {
                        var dailySport = await service.GenerateDailySports(MainViewModel.UserProfile.BasalMetabolicRate, MainViewModel.UserProfile.Height, MainViewModel.UserProfile.Weight);
                        dailySportList.Add(dailySport);
                    }


                    MainViewModel.DailySportRepository.DailySports = dailySportList;
                    MainViewModel.DailySportRepository.SetMargins();

                    IsSetup = true;
                }
                , LearnPage);
            }


        }
        /// <summary>
        /// 该函数为私有函数，用于ShowTransitionAsync与ShowFakeTransitionAsync，仅用于抽离函数体，提高优雅性
        /// </summary>
        /// <param name="message"></param>
        /// <param name="function"></param>
        /// <param name="targetPage"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
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
            await ShowTransitionBaseAsync(message, async () => { function(); }, targetPage, interval);
        }


        public MainViewViewModel(MainViewModel mainViewModel)
        {
            SetupPage = new(mainViewModel);
            LearnPage = new(this);
            MainViewModel = mainViewModel;
            CurrentPage = SetupPage;

        }

    }
}
