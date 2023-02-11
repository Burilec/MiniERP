using MiniERP.UI.ViewModels.Dialogs.AddOrEdits;
using MiniERP.UI.ViewModels.Dialogs.Constants;
using MiniERP.UI.Views.Dialogs.AddOrEdits;
using Prism.Ioc;
using DialogWindow = MiniERP.UI.Views.Dialogs.Windows.DialogWindow;

namespace MiniERP.UI.Modules
{
    internal static class UIModule
    {
        internal static void RegisterDialogs(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<DialogWindow>();

            containerRegistry.RegisterDialog<AddOrEditProductDialogView, AddOrEditProductDialogViewModel>(DialogNames.AddOrEditProductDialogName);
        }
    }
}