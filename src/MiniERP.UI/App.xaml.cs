using MiniERP.UI.Modules;
using MiniERP.UI.Views.Windows;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MiniERP.UI
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
            => Container.Resolve<MainWindow>();


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<MainModule>();
        }
    }
}