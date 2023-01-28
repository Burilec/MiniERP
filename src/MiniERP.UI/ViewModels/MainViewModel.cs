using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MiniERP.UI.ViewModels
{
    public sealed class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> MenuCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            MenuCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string viewName)
            => _regionManager.RequestNavigate("MainRegion", viewName + "View", NavigationCallback);

        private void NavigationCallback(NavigationResult navigationResult)
        {
            if (!navigationResult.Result.HasValue || navigationResult.Result.Value)
                return;

            throw navigationResult.Error;
        }
    }
}