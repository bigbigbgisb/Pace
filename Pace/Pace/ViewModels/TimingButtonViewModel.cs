using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Pace.ViewModels
{
    public partial class TimingButtonViewModel : ObservableObject
    {
        public bool IsClickedTimingButton { get; set; } = false;
        public int TotalPassedTime { get; set; }
        private int _passedTime = 0;
        private readonly System.Timers.Timer _timer;
        [ObservableProperty]
        string? _timingButtonText = "开始任务!";

        public TimingButtonViewModel()
        {
            _timer = new() { Interval = 1000, AutoReset = true };
            _timer.Elapsed += (s, e) =>
            {
                _passedTime++;
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    TimingButtonText = TimeSpan.FromSeconds(_passedTime).ToString(@"hh\:mm\:ss");
                });
                
            };
        }
        public async Task ToggleTiming()
        {
            if (IsClickedTimingButton)
            {
                _timer.Stop();
                IsClickedTimingButton = false;
                TotalPassedTime += _passedTime;
                _passedTime = 0;
                TimingButtonText = "开始任务!";

            }
            else
            {

                IsClickedTimingButton = true;
                _timer.Start();
            }

        }
    }
}
