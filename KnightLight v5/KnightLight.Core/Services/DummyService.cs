using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using KnightLight.Core.Events;
using System;
using System.Threading.Tasks;

namespace KnightLight.Core.Services
{
    public class DummyService : IDummyService, IDisposable
    {

        public void StartRandomstream()
        {

            _ = Task.Run(StartRandomMessaging);
        }

        private async Task StartRandomMessaging()
        {
            while (true)
            {
                await Task.Delay(Random.Shared.Next(200));
                WeakReferenceMessenger.Default.Send(new ChannelValueEvent(Guid.NewGuid(), Math.Round(Random.Shared.NextDouble() * 100, 2)));
            }
        }

        public void Dispose()
        {
        }
    }
}
