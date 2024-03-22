using Avalonia.Controls;
using MvvmCross.IoC;
using Window = Avalonia.Controls.Window;

namespace AvaloniaUtils.Navigation
{
    public interface INavigationService
    {
        public void Navigate<T>() where T : NavigationViewModel;
        public void Close<T>(T viewModel) where T : NavigationViewModel;
    }
    public class NavigationService : INavigationService
    {
        private Stack<NavigationViewModel> _navigationStack = new Stack<NavigationViewModel>();
        private Window _window;

        private NavigationService(NavigationWindow window)
        {
            _window = window;
        }

        public static INavigationService CreateNavigation(NavigationWindow window)
        {
            return new NavigationService(window);
        }

        public void Navigate<T>() where T : NavigationViewModel
        {
            T newViewModel = null;
            if(Mvx.IoCProvider.CanResolve<T>())
                newViewModel = Mvx.IoCProvider.Resolve<T>();
            else
                Activator.CreateInstance<T>();
            newViewModel.InjectNavigation(this);

            _ = Task.Factory.StartNew(newViewModel.Initalize);


            _navigationStack.Push(newViewModel);

            var content = FindView(newViewModel);
            content.DataContext = newViewModel;
            newViewModel.OnAppearing();
            _window.Content = newViewModel;
        }

        public void Close<T>(T viewModel) where T : NavigationViewModel
        {
            Stack<NavigationViewModel> offStack = new Stack<NavigationViewModel>();
            bool found = false;
            while(!found && _navigationStack.TryPeek(out NavigationViewModel? navigationViewModel))
            {
                if(navigationViewModel is T typeViewModel && typeViewModel == viewModel)
                {
                    found = true;
                    _navigationStack.Pop();
                    viewModel.OnDissappearing();

                    if(_navigationStack.TryPeek(out NavigationViewModel? previousViewModel))
                    {
                        var content = FindView(previousViewModel);
                        content.DataContext = previousViewModel;
                        previousViewModel.OnAppearing();
                        _window.Content = previousViewModel;
                    }
                    else
                    {
                        _window.Content = new UserControl { Content = "Navigation Stack Empty" };
                    }
                }
                else
                {
                    offStack.Push(_navigationStack.Pop());
                }
            }
            while (offStack.TryPop(out NavigationViewModel? navigationViewModel))
            {
                _navigationStack.Push(navigationViewModel);
            }


        }

        private UserControl FindView<T>(T model)
        {
            foreach (var template in Avalonia.Application.Current.DataTemplates)
            {
                if (template.Match(model))
                {
                    var control = template.Build(model);
                    if (control is UserControl w)
                        return w;
                    return new UserControl { Content = "Cannot build view of type " + typeof(T).Name };

                }
            }
            return new UserControl { Content = "Cannot find view for model of type " + typeof(T).Name };
        }
    }
}
