using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KnightLight.Core.Events;
using AvaloniaUtils.Navigation;
using KnightLight.Core.Views;
using System;
using System.Threading.Tasks;
using KnightLight.Core.Services;

namespace KnightLight.Core.ViewModels;

public partial class MainViewModel : NavigationViewModel
{

    [ObservableProperty]
    public string _greeting = "Welcome to Avalonia!";
    private IDummyService _dummyService;

    [RelayCommand]
    private async Task OpenChannelsWindow()
    {
        try
        {
            var channelsWindow = new ChannelsWindow() { DataContext = new ChannelsViewModel()};
            channelsWindow.Show();
        }catch (Exception ex)
        {
            Console.WriteLine("Exception: "+ ex.Message);
        }
    }
    [RelayCommand]
    private async Task ChangeView()
    {
        NavigationService.Navigate<SettingsViewModel>();
        
    }

    public MainViewModel(IDummyService dummyService)
    {
        _dummyService = dummyService;
        _dummyService.StartRandomstream();
    }
}
