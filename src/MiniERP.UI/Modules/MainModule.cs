using MiniERP.UI.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MiniERP.UI.Modules
{
    public class MainModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion("MainRegion", typeof(ProductView));

            regionManager.RegisterViewWithRegion("MainRegion", typeof(UnitView));
        }
    }
}