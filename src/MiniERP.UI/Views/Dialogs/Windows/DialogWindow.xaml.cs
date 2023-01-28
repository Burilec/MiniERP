using Prism.Services.Dialogs;

namespace MiniERP.UI.Views.Dialogs.Windows
{
    internal sealed partial class DialogWindow : IDialogWindow
    {
        internal DialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; } = null!;
    }
}
