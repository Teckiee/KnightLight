using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUtils.Navigation
{
    public class NavigationViewModel : ObservableRecipient
    {
        public INavigationService NavigationService { get; private set; }
        public void InjectNavigation(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public virtual Task Initalize() { return Task.CompletedTask; }
        public virtual void OnAppearing() { }
        public virtual void OnDissappearing() { }
    }
}
