using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using KnightLight.Core.Services;
using KnightLight.Core.ViewModels;
using KnightLight.Core.Views;
using MvvmCross.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KnightLight.Core;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        SetupIoC();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = MainWindow.CreateWindow<MainViewModel>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            throw new Exception("Navigation on SingleView not yet Supported");
            singleViewPlatform.MainView = new MainView
            {
                DataContext = Mvx.IoCProvider.Resolve<MainViewModel>()
            };
        }
        

        base.OnFrameworkInitializationCompleted();
    }

    private void SetupIoC()
    {
        MvvmCross.IoC.MvxIoCProvider.Initialize();

        CreateableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();
        CreateableTypes()
            .EndingWith("ViewModel")
            .AsTypes()
            .RegisterAsDynamic();
    }

    private IEnumerable<Type> CreateableTypes()
    {
        return CreateableTypes(this.GetType().GetTypeInfo().Assembly);
    }
    private IEnumerable<Type> CreateableTypes(Assembly assembly)
    {
        return from t in assembly.ExceptionSafeGetTypes()
               select t.GetTypeInfo() into t
               where !t.IsAbstract
               where t.DeclaredConstructors.Any((ConstructorInfo c) => !c.IsStatic && c.IsPublic)
               select t.AsType();
    }
}
