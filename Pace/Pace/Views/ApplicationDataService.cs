using Pace.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Pace.Views
{
    public class ApplicationDataService
    {
        public const string DataFileDirectoryName = "PaceAppData";
        private const string DataFileName = "AppData.json";
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
        public void WriteData(MainViewModel mainViewModel, string targetDirectory)
        {
            List<IdDailySport> idDailySports = [];
            foreach (var dailySport in mainViewModel.DailySportRepository.DailySports)
            {
                idDailySports.Add(dailySport.ToIdDailySport());
            }
            UserApplicationData userApplicationData = new()
            {
                SportData = new() { IdDailySports = idDailySports },
                UserData = new() { Age = mainViewModel.UserProfile.Age, BasalMetabolicRate = mainViewModel.UserProfile.BasalMetabolicRate, Height = mainViewModel.UserProfile.Height, Weight = mainViewModel.UserProfile.Weight, Gender = mainViewModel.UserProfile.Gender },
                WarData = new(),
            };
            string json = JsonSerializer.Serialize<UserApplicationData>(userApplicationData, _jsonSerializerOptions);
            Directory.CreateDirectory(Path.Combine(targetDirectory, DataFileDirectoryName));
            File.WriteAllText(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName), json);
        }
        public UserApplicationData? ReadData(string targetDirectory)
        {
            if (!IsApplicationSetup(targetDirectory)) { return null; }
            UserApplicationData? userApplicationData = JsonSerializer.Deserialize<UserApplicationData>(File.ReadAllText(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName)));
            return userApplicationData;
        }

        public bool IsApplicationSetup(string targetDirectory)
        {
            if (!Directory.Exists(targetDirectory)) return false;
            else if (!File.Exists(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName))) return false;
            return true;
        }

        public void ApplyTo(UserApplicationData userApplicationData, MainViewViewModel mainViewViewModel)
        {
            mainViewViewModel.IsSetup = true;
            mainViewViewModel.MainViewModel.UserProfile.Age = userApplicationData.UserData.Age;
            mainViewViewModel.MainViewModel.UserProfile.Weight = userApplicationData.UserData.Weight;
            mainViewViewModel.MainViewModel.UserProfile.Height = userApplicationData.UserData.Height;
            mainViewViewModel.MainViewModel.UserProfile.Gender = userApplicationData.UserData.Gender;
            mainViewViewModel.MainViewModel.UserProfile.BasalMetabolicRate = userApplicationData.UserData.BasalMetabolicRate;
            List<DailySport> dailySports = [];
            foreach(var idDailySport in userApplicationData.SportData.IdDailySports)
            {
                dailySports.Add(idDailySport.ToDailySport());
            }
            mainViewViewModel.MainViewModel.DailySportRepository.DailySports = dailySports;

        }
    }
}
