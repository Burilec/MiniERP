using MiniERP.Models;
using MiniERP.Models.Exceptions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MiniERP.UI.ViewModels.Dialogs.AddOrEdits
{
    internal sealed class AddOrEditUnitDialogViewModel : BindableBase, IDialogAware
    {
        private Unit? _unit;

        private string? _name;
        private string? _description;

        public string Title
            => string.Empty;

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public DelegateCommand SaveButtonCommand { get; set; }
        public DelegateCommand CancelButtonCommand { get; set; }

        public AddOrEditUnitDialogViewModel()
        {
            SaveButtonCommand = new DelegateCommand(HandleSaveButtonCommand, CanExecuteMethod)
                               .ObservesProperty(() => Name)
                               .ObservesProperty(() => Description);

            CancelButtonCommand = new DelegateCommand(HandleCancelButtonCommand);
        }

        private bool CanExecuteMethod()
            => !string.IsNullOrWhiteSpace(Name)
            && !string.IsNullOrWhiteSpace(Description);

        private void HandleCancelButtonCommand()
            => RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));

        private void HandleSaveButtonCommand()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(Name));

            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(Description));

            if (_unit == null)
            {
                _unit = new Unit(Name, Description);
            }
            else
            {
                _unit.SetName(Name);
                _unit.SetDescription(Description);
            }

            RequestClose.Invoke(new DialogResult(ButtonResult.OK, new DialogParameters { { nameof(Unit), _unit } }));
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters);

            var unit = parameters.GetValue<Unit>(nameof(Unit));

            if (unit == null)
                return;

            _unit = unit;

            Name = _unit.Name;
            Description = _unit.Description;
        }

        public event Action<IDialogResult> RequestClose = null!;
    }
}