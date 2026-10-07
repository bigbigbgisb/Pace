using CommunityToolkit.Mvvm.ComponentModel;
using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static Pace.Views.UserProfile;

namespace Pace.Views
{
    public class SportData
    {
        public required List<IdDailySport> IdDailySports { get; set; }
    }
    public class UserData
    {

        public UserGender Gender { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public short Age { get; set; }

        public short BasalMetabolicRate { get; set; }
        public short BurnedCalories { get; set; }
        public bool HasTodayCheckedIn { get; set; }
        public int WiningStreakDays { get; set; }
    }
    public class WarData
    {
        //反正还没融入软件，放着吧，嘿嘿
    }
    public class UserApplicationData
    {   
        public required SportData SportData { get; set; }
        public required UserData UserData { get; set; }
        public required WarData WarData { get; set; }
    }
    public class Cache
    {
        public required DateTime DateTime { get; set; }
    }
}
