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
        private const string CacheDirectoryName = "PaceAppCache";
        private const string CacheFileName = "Cache.json";
        private const string BackupDataFileDirectoryName = "PaceAppBackupData";
        private const string BackupDataFileName = "BackupAppData.bak";
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
                UserData = new() { Age = mainViewModel.UserProfile.Age, BasalMetabolicRate = mainViewModel.UserProfile.BasalMetabolicRate, Height = mainViewModel.UserProfile.Height, Weight = mainViewModel.UserProfile.Weight, Gender = mainViewModel.UserProfile.Gender, BurnedCalories = mainViewModel.UserProfile.BurnedCalories,HasTodayCheckedIn = mainViewModel.UserProfile.HasTodayCheckedIn,WiningStreakDays = mainViewModel.UserProfile.WiningStreakDays },
                WarData = new(),
            };
            string json = JsonSerializer.Serialize<UserApplicationData>(userApplicationData, _jsonSerializerOptions);
            Directory.CreateDirectory(Path.Combine(targetDirectory, DataFileDirectoryName));
            Directory.CreateDirectory(Path.Combine(targetDirectory, BackupDataFileDirectoryName));
            try
            {
                File.WriteAllText(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName), json);
                File.WriteAllText(Path.Combine(targetDirectory, BackupDataFileDirectoryName, BackupDataFileName), json);
            }
            catch
            {
                //本来是要记录日志的
                //然后如果读的时候有bak，就使用bak，否则再抛出错误
            }
            

        }
        public void WriteCache(string targetDirectory)
        {
            Cache cache = new() { DateTime = DateTime.Now };
            string json = JsonSerializer.Serialize<Cache>(cache, _jsonSerializerOptions);
            Directory.CreateDirectory(Path.Combine(targetDirectory, CacheDirectoryName));
            File.WriteAllText(Path.Combine(targetDirectory, CacheDirectoryName, CacheFileName), json);

        }

        public UserApplicationData? ReadData(string targetDirectory)
        {

            if (!IsApplicationSetup(targetDirectory)) { return null; }
            try
            {
                UserApplicationData? userApplicationData = JsonSerializer.Deserialize<UserApplicationData>(File.ReadAllText(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName)));

                return userApplicationData;
            }
            catch
            {
                if (TryGetBackup(targetDirectory, out var result))
                {
                    File.Copy(Path.Combine(targetDirectory, BackupDataFileDirectoryName, BackupDataFileName), Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName),true);

                    return result;
                }
                throw new InvalidDataException("Cannot deserialize this type of data.Check the data version.");
            }
            
        }
        public Cache? ReadCache(string targetDirectory)
        {
            if (IsCacheExists(targetDirectory))
            {
                return JsonSerializer.Deserialize<Cache>(File.ReadAllText(Path.Combine(targetDirectory, CacheDirectoryName, CacheFileName)));
            }
            else
            {
                return null;
            }

        }
        public bool TryGetBackup(string targetDirectory,out UserApplicationData? result)
        {

            try
            {
               result = JsonSerializer.Deserialize<UserApplicationData>(File.ReadAllText(Path.Combine(targetDirectory, BackupDataFileDirectoryName, BackupDataFileName)));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        public bool IsApplicationSetup(string targetDirectory)
        {
            if (!Directory.Exists(targetDirectory)) return false;
            else if (!File.Exists(Path.Combine(targetDirectory, DataFileDirectoryName, DataFileName))) return false;
            return true;
        }

        public bool IsCacheExists(string targetDirectory)
        {
            if (!Directory.Exists(targetDirectory)) return false;
            else if (!File.Exists(Path.Combine(targetDirectory, CacheDirectoryName, CacheFileName))) return false;
            return true;
        }

        public void ApplyTo(UserApplicationData userApplicationData, MainViewViewModel mainViewViewModel)
        {

            mainViewViewModel.IsSetup = true;
            MainViewModel mainViewModel = mainViewViewModel.MainViewModel;
            mainViewModel.UserProfile.Age = userApplicationData.UserData.Age;
            mainViewModel.UserProfile.Weight = userApplicationData.UserData.Weight;
            mainViewModel.UserProfile.Height = userApplicationData.UserData.Height;
            mainViewModel.UserProfile.Gender = userApplicationData.UserData.Gender;
            mainViewModel.UserProfile.BasalMetabolicRate = userApplicationData.UserData.BasalMetabolicRate;
            mainViewModel.UserProfile.BurnedCalories = userApplicationData.UserData.BurnedCalories;
            mainViewModel.UserProfile.HasTodayCheckedIn = userApplicationData.UserData.HasTodayCheckedIn;
            mainViewModel.UserProfile.WiningStreakDays = userApplicationData.UserData.WiningStreakDays;
            List<DailySport> dailySports = [];
            foreach (var idDailySport in userApplicationData.SportData.IdDailySports)
            {
                dailySports.Add(idDailySport.ToDailySport());
            }
            mainViewModel.DailySportRepository.DailySports = dailySports;
            if (ReadCache(mainViewModel.BaseDirectoryPath) is Cache cache)
            {
                if (cache.DateTime.Date < DateTime.Now.Date)
                {
                    ResetDailyData(mainViewViewModel);
                }
            }
            else
            {
                mainViewViewModel.ToHomeCommand.Execute(null);
            }
            

        }
        public void ResetDailyData(MainViewViewModel mainViewViewModel)
        {
            MainViewModel mainViewModel = mainViewViewModel.MainViewModel;
            mainViewModel.UserProfile.BurnedCalories = 0;
            mainViewModel.UserProfile.HasTodayCheckedIn = false;
            mainViewViewModel.CalculateDailySports();
        }
    }

}
