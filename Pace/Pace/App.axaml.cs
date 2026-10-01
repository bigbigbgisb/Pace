using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Pace.ViewModels;
using Pace.Views;
using System;

namespace Pace;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDeveloperTools();
#endif
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(AppContext.BaseDirectory) 
            };
        }
        else if (ApplicationLifetime is IActivityApplicationLifetime singleViewFactoryApplicationLifetime)
        {
#if ANDROID
            singleViewFactoryApplicationLifetime.MainViewFactory = () => new MainView(new MainViewModel(Android.App.Application.Context.FilesDir!.AbsolutePath) );
#endif
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
#if ANDROID
            singleViewPlatform.MainView = new MainView(new MainViewModel(Android.App.Application.Context.FilesDir!.AbsolutePath));
#endif
        }

        base.OnFrameworkInitializationCompleted();
    }
}