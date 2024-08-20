using CommunityToolkit.Mvvm.Input;
using AvaloniaUtils.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightLight.Core.ViewModels
{
    public partial class SettingsViewModel : NavigationViewModel
    {

        [RelayCommand]
        private async Task Close()
        {
            NavigationService.Close<SettingsViewModel>(this);
        }
    }
}
