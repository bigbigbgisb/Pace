using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Pace.ViewModel
{
    public partial class NavButtonViewModel : ObservableObject
    {
        private readonly string _ordinaryColor;
        private readonly string _selectedColor;

        public partial class NavButtonData : ObservableObject
        {
            [ObservableProperty]
            string? _background;
            [ObservableProperty]
            string? _foreground;
        }


        [ObservableProperty]
        NavButtonData _homeNavButtonData;
        [ObservableProperty]
        NavButtonData _achievementNavButtonData;
        [ObservableProperty]
        NavButtonData _momentNavButtonData;
        [ObservableProperty]
        NavButtonData _profileNavButtonData;
        private readonly List<NavButtonData> _navDatas;

        public NavButtonViewModel(string ordinaryColor, string selectedColor)
        {
            _ordinaryColor = ordinaryColor;
            _selectedColor = selectedColor;
            HomeNavButtonData = new() { Background = _ordinaryColor,Foreground = _selectedColor};
            AchievementNavButtonData = new() { Background = _ordinaryColor, Foreground = _selectedColor };
            MomentNavButtonData =  new() { Background = _ordinaryColor, Foreground = _selectedColor };
            ProfileNavButtonData = new() { Background = _ordinaryColor, Foreground = _selectedColor };
            _navDatas = [
            
                HomeNavButtonData,
                AchievementNavButtonData,
                MomentNavButtonData,
                ProfileNavButtonData,
            ];
        }
            
            
        
        [RelayCommand]
        private void SelectNav(string name)
        {
            NavButtonData? navButtonData;
            if (name == "Home") navButtonData = HomeNavButtonData;
            else if (name == "Achievement") navButtonData = AchievementNavButtonData;
            else if (name == "Moments") navButtonData = MomentNavButtonData;
            else if (name == "Profile") navButtonData = ProfileNavButtonData;
            else throw new ArgumentException("Nav Buttons' name were invalid");
            foreach (var data in _navDatas)
            {
                data.Background = _ordinaryColor;
                data.Foreground = _selectedColor;
            }
                
            navButtonData.Background = _selectedColor;
            navButtonData.Foreground = _ordinaryColor;



        }
        
    }
}
