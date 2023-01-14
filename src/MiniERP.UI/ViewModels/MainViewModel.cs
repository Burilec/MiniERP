using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Controls;

namespace MiniERP.UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> MenuCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            MenuCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string viewName)
            => _regionManager.RequestNavigate("MainRegion", viewName + "View");
    }
}