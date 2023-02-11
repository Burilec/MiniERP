using MiniERP.Models;
using MiniERP.Models.Exceptions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MiniERP.UI.ViewModels.Dialogs.AddOrEdits
{
    internal sealed class AddOrEditProductDialogViewModel : BindableBase, IDialogAware
    {
        private Product? _product;

        private string? _name;
        private string? _description;
        private Unit? _unit;

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

        public Unit? Unit
        {
            get => _unit;
            set => SetProperty(ref _unit, value);
        }

        public DelegateCommand SaveButtonCommand { get; set; }
        public DelegateCommand CancelButtonCommand { get; set; }

        public AddOrEditProductDialogViewModel()
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

            if (_product == null)
            {
                _product = new Product(Name, Description);
            }
            else
            {
                _product.SetName(Name);
                _product.SetDescription(Description);
            }

            RequestClose.Invoke(new DialogResult(ButtonResult.OK, new DialogParameters { { nameof(Product), _product } }));
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters);

            var product = parameters.GetValue<Product>(nameof(Product));

            if (product == null)
                return;

            _product = product;

            Name = _product.Name;
            Description = _product.Description;
            Unit = _product.Unit;
        }

        public event Action<IDialogResult> RequestClose = null!;
    }
}