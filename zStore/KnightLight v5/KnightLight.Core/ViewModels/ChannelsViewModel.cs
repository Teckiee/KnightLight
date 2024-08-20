using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using KnightLight.Core.Events;
using KnightLight.Core.Services;
using MvvmCross.IoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightLight.Core.ViewModels;

public partial class ChannelsViewModel : ViewModelBase, IRecipient<ChannelValueEvent>, IDisposable
{
    private IDummyService _dummyService;

    [ObservableProperty]
    public ObservableCollection<string> _channelEvents = new ObservableCollection<string>();

    public ChannelsViewModel()
    {
        Messenger.RegisterAll(this);

        // Another way of getting a service
        _dummyService = Mvx.IoCProvider.Resolve<IDummyService>();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Receive(ChannelValueEvent message)
    {
        ChannelEvents.Add($"{message.Id}: {message.Value}");
    }
}
