using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Pace.ViewModels
{
    public partial class TransitionPageViewModel : ObservableObject
    {
        public class TransitionInfo(string message, string imagePath)
        {
            public string Message { get; init; } = $"等待的时候吃点{message}吧!";
            public string ImagePath { get; init; } = imagePath;
            public Bitmap? Image { get; set; }
            public void LoadImage()
            {
                using var stream = AssetLoader.Open(new Uri($"avares://Pace/Assets/{ImagePath}"));
                Image = new Bitmap(stream);
            }
        }
        [ObservableProperty]
        private TransitionInfo _randomTransitionInfo;
        [ObservableProperty]
        private MainViewModel _mainViewModel;
        
        private readonly TransitionInfo[] transitionInfos = [ new ("烤鸡", "TransitionImages/RoastChicken.png"), new ("戈登拉姆齐做的惠林顿牛排!", "TransitionImages/Beef.png"), new ("苹果", "TransitionImages/Apple.png"), new ("甜浆果冰淇淋", "TransitionImages/SweetBerryIceCream.png"), new ("烤肉串", "TransitionImages/Kabobs.png")];
        public TransitionPageViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            Random random = Random.Shared;
            int index = random.Next(0, transitionInfos.Length);
            TransitionInfo randomTransitionInfo = transitionInfos[index];
            randomTransitionInfo.LoadImage();
            RandomTransitionInfo = randomTransitionInfo;
        }
    }
}
    