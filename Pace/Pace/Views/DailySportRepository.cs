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
    }
}
