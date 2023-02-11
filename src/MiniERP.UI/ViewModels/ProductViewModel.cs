using MiniERP.Models;
using MiniERP.UI.ViewModels.Dialogs.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace MiniERP.UI.ViewModels
{
    public sealed class ProductViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private Product? _selectProduct;
        private ObservableCollection<Product> _items = null!;

        public ObservableCollection<Product> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Product? SelectedItem
        {
            get => _selectProduct;
            set => SetProperty(ref _selectProduct, value);
        }

        public DelegateCommand AddButtonCommand { get; }
        public DelegateCommand EditButtonCommand { get; }
        public DelegateCommand RemoveButtonCommand { get; }
        public DelegateCommand GetProductsCommand { get; }

        public ProductViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            AddButtonCommand = new DelegateCommand(HandleAddButtonCommand);
            EditButtonCommand = new DelegateCommand(HandleEditButtonCommand, () => SelectedItem != null).ObservesProperty(() => SelectedItem);
            RemoveButtonCommand = new DelegateCommand(HandleRemoveButtonCommandAsync, () => SelectedItem != null).ObservesProperty(() => SelectedItem);
            GetProductsCommand = new DelegateCommand(HandleGetUsersCommandAsync);
        }

        private void HandleGetUsersCommandAsync()
        {
            //Todo: Chama a API ou local

            Items = new ObservableCollection<Product>();
        }

        private void HandleRemoveButtonCommandAsync()
        {
            //Todo: Enviar para API ou salvar local

            ArgumentNullException.ThrowIfNull(SelectedItem);

            Items.Remove(SelectedItem);
        }

        private void HandleEditButtonCommand()
        {
            ArgumentNullException.ThrowIfNull(SelectedItem);

            _dialogService.ShowDialog(DialogNames.AddOrEditProductDialogName, new DialogParameters {{nameof(Product), SelectedItem}}, EditButtonCommandCallbackAsync);
        }

        private void EditButtonCommandCallbackAsync(IDialogResult dialogResult)
        {
            if (dialogResult.Result != ButtonResult.OK)
                return;

            var product = dialogResult.Parameters.GetValue<Product>(nameof(Product));

            //Todo: Enviar para API ou salvar local

            ArgumentNullException.ThrowIfNull(SelectedItem);

            Items.Remove(SelectedItem);
            Items.Add(product);
            SelectedItem = product;
        }

        private void HandleAddButtonCommand()
            => _dialogService.ShowDialog(DialogNames.AddOrEditProductDialogName, AddButtonCommandCallback);

        private void AddButtonCommandCallback(IDialogResult dialogResult)
        {
            if (dialogResult.Result != ButtonResult.OK)
                return;

            var product = dialogResult.Parameters.GetValue<Product>(nameof(Product));

            //Todo: Enviar para API ou salvar local

            Items.Add(product);
        }
    }
}