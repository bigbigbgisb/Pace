using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pace.ViewModels
{
    public partial class ThemeViewModel : ObservableObject
    {
        [ObservableProperty]
        string _darkColor = "#1B1D1E";

        [ObservableProperty]
        string _obsidianColor = "#181717";

        [ObservableProperty]
        string _vantaColor = "#0E0E10";
        [ObservableProperty]
        string _opacityObsidianColor = "#181717F7";
        [ObservableProperty]
        string _goldColor = "#FFBC50";
        [ObservableProperty]
        string _lightForeground = "#FFFFFF";
        [ObservableProperty]
        string _darkForeground = "#000000";
        [ObservableProperty]
        string _classicBlue = "#376EA7";
        [ObservableProperty]
        string _classicGrey = "#D5D1C9";
        [ObservableProperty]
        string _themeColor = "#D06060";
        [ObservableProperty]
        string _darkThemeColor = "#AF3E3E";
    }
}
