using CommunityToolkit.Mvvm.ComponentModel;
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pace.Views
{
    public partial class DailySportRepository : ObservableObject
    {
        [ObservableProperty]
        public List<DailySport> _dailySports = [];


        public void SetMargins()
        {
            for (int i = 1; i <= DailySports.Count; i++)
            {
                DailySports[i - 1].SetMargin(new Avalonia.Thickness(Math.Round(128 * Math.Sin(Math.PI / 2 / 3 * i),4), 0, 0, 32));
            }
        }
    }
}
