using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pace.ViewModels
{
    public partial class ThemeViewModel : ObservableObject
    {
        [ObservableProperty]
        string _darkColor = "#27292B";

        [ObservableProperty]
        string _obsidianColor = "#181717";

        [ObservableProperty]
        string _vantaColor = "#0E0E10";
        [ObservableProperty]
        string _goldColor = "#FFBC50";
        [ObservableProperty]
        string _lightForeground = "#FFFFFF";
        [ObservableProperty]
        string _darkForeground = "#000000";
        [ObservableProperty]
        string _themeColor = "#D06060";
        [ObservableProperty]
        string _darkThemeColor = "#AF3E3E";
    }
}
