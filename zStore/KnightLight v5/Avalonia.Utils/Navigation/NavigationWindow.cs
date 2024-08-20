using Window = Avalonia.Controls.Window;

namespace AvaloniaUtils.Navigation
{
    public partial class NavigationWindow : Window
    {
        private INavigationService _navigationService;
        public NavigationWindow()
        {
            _navigationService = NavigationService.CreateNavigation(this);
        }


        public static NavigationWindow CreateWindow<T>() where T : NavigationViewModel
        {
            var window = new NavigationWindow();
            window._navigationService.Navigate<T>();
            return window;
        }
    }
}
