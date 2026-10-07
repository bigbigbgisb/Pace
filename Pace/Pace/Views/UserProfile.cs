using CommunityToolkit.Mvvm.ComponentModel;
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pace.Views
{
    public partial class UserProfile : ObservableObject
    {
        public enum UserGender
        {
            Man,
            Woman,
            None
        }
        public (string tipText,bool isValid) CheckProfileData(string weight,string height,string age,string gender)
        {
            string tipText = "数据 ";
            bool isError = false;
            if (!float.TryParse(weight, out float weightResult) || weightResult < 10 || weightResult > 400)      
            {
                isError = true;
                tipText += "体重, ";
            }
            if (!float.TryParse(height, out float heightResult) || heightResult > 400 || heightResult < 40)
            {
                isError = true;
                tipText += "身高, ";
            }
            if (!short.TryParse(age, out short ageResult) || ageResult > 130 || ageResult < 3)
            {
                isError = true;
                tipText += "年龄, ";
            }
            if (!new string[] { "男", "男性", "女", "女性", "不愿透露" }.Contains(gender))
            {
                isError = true;
                tipText += "性别, ";
            }


            if (!isError)
            {
                Weight = weightResult;
                Height = heightResult;
                Age = ageResult;
                Gender = gender == "男性" || gender == "男" ? UserProfile.UserGender.Man : gender == "女性" || gender == "女" ? UserProfile.UserGender.Woman : gender == "不愿透露" ? UserProfile.UserGender.None : UserProfile.UserGender.None;
                CalculateBasalMetabolicRate();
            }
            return (tipText, isError);
        }
        public void CalculateBasalMetabolicRate()
        {
            if (Age > 18)
            {
                BasalMetabolicRate = 
                    Gender == UserGender.Man 
                    ? (short)(10 * Weight + 6.25 * Height - 5 * Age + 5) 
                    : Gender == UserGender.Woman ? (short)(10 * Weight + 6.25 * Height - 5 * Age - 161) 
                    : (short)(10 * Weight + 6.25 * Height - 5 * Age - 78);
            }
            else
            {
                BasalMetabolicRate =
                    Gender == UserGender.Man 
                    ? (short)(17.686 * Weight + 658.2) 
                    : Gender == UserGender.Woman 
                    ? (short)(13.384 * Weight + 692.6) 
                    : (short)(15.535 * Weight + 675.4);
            }
        }
        [ObservableProperty]
        UserGender _gender;
        [ObservableProperty]
        float _height;
        [ObservableProperty]
        float _weight;
        [ObservableProperty]
        short _age;
        [ObservableProperty]
        short _basalMetabolicRate;
        [ObservableProperty]
        short _burnedCalories;
        [ObservableProperty]
        int _winingStreakDays = 0;
        [ObservableProperty]
        bool _hasTodayCheckedIn;

    }
}
