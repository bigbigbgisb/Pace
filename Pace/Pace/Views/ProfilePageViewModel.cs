using Avalonia.Controls.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pace.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Pace.ViewModels
{
    public partial class ProfilePageViewModel(MainViewViewModel mainViewViewModel) : ObservableObject
    {
        [ObservableProperty]
        MainViewViewModel _mainViewViewModel = mainViewViewModel;
        [ObservableProperty]
        decimal? _heightInput = (decimal)mainViewViewModel.MainViewModel.UserProfile.Height;
        [ObservableProperty]
        decimal? _weightInput = (decimal)mainViewViewModel.MainViewModel.UserProfile.Weight;
        [ObservableProperty]
        decimal? _ageInput = (decimal)mainViewViewModel.MainViewModel.UserProfile.Age;
        [ObservableProperty]
        bool _isRecalculateButtonVisible;
        [ObservableProperty]
        double _targetCalories = Math.Round((double)(mainViewViewModel.MainViewModel.UserProfile.BasalMetabolicRate / 7),2);
        
        [ObservableProperty]
        ObservableCollection<string> _tipText = [];
        [RelayCommand]
        private void Recalculate()
        {
            MainViewViewModel.MainViewModel.UserProfile.CalculateBasalMetabolicRate();
            MainViewViewModel.CalculateDailySports();
        }

        partial void OnHeightInputChanged(decimal? value)
        {
            Confirm(value, "身高", 399, 41, (float height) => 
            {
                MainViewViewModel.MainViewModel.UserProfile.Height = height;
            });
        }
        partial void OnWeightInputChanged(decimal? value)
        {
            Confirm(value, "体重", 399, 11, (float weight) => 
            {
                MainViewViewModel.MainViewModel.UserProfile.Weight = weight;
            });
        }
        partial void OnAgeInputChanged(decimal? value)
        {
            Confirm(value, "年龄", 129, 4, (short age) =>
            {
                MainViewViewModel.MainViewModel.UserProfile.Age = age;
            });
        }
        private bool ConfirmBase(decimal? value, string valueName, decimal? maxValue, decimal? minValue,out decimal result)
        {
            result = 0;
            
            if (value is null)
            {
                if (!TipText.Contains($"{valueName}不得为空"))
                    TipText.Add($"{valueName}不得为空");
                return false;
            }
            else
            {
                TipText.Remove($"{valueName}不得为空");
            }
            if (value > maxValue || value < minValue)
            {
                if (!TipText.Contains($"{valueName}值超出范围"))
                    TipText.Add($"{valueName}值超出范围");
                return false;
            }
            else
            {
                TipText.Remove($"{valueName}值超出范围");
            }
          

            result = value.Value;
            return true;
        }

        private void Confirm(decimal? value, string valueName, decimal? maxValue, decimal? minValue, Action<short> editOperation)
        {
            if (ConfirmBase(value, valueName, maxValue, minValue, out decimal result))
            {
                editOperation((short)result);
                MainViewViewModel.MainViewModel.UserProfile.CalculateBasalMetabolicRate();
            }
            IsRecalculateButtonVisible = TipText.Count == 0;
        }
        private void Confirm(decimal? value, string valueName, decimal? maxValue, decimal? minValue, Action<float> editOperation)
        {
            if (ConfirmBase(value, valueName, maxValue, minValue, out decimal result))
            {
                editOperation((float)result);
                MainViewViewModel.MainViewModel.UserProfile.CalculateBasalMetabolicRate();
            }
            IsRecalculateButtonVisible = TipText.Count == 0;
        }

    }
}
