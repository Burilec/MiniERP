using MiniERP.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MiniERP.UI.ViewModels
{
    public class ProductViewModel : BindableBase
    {
        private Product _selectProduct;
        public ObservableCollection<Product> Products { get; set; }

        public Product SelectProduct
        {
            get => _selectProduct;
            set => SetProperty(ref _selectProduct, value);
        }

        public DelegateCommand AddButtonCommand { get; set; }
        public DelegateCommand EditButtonCommand { get; set; }
        public DelegateCommand RemoveButtonCommand { get; set; }
        public DelegateCommand GetProductsCommand { get; set; }

        public ProductViewModel()
        {
            AddButtonCommand = new DelegateCommand(HandleAddButtonCommand);
            EditButtonCommand = new DelegateCommand(HandleEditButtonCommand, () => SelectProduct != null).ObservesProperty(() => SelectProduct);
            RemoveButtonCommand = new DelegateCommand(async () => await HandleRemoveButtonCommandAsync(), () => SelectProduct != null).ObservesProperty(() => SelectProduct);
            GetProductsCommand = new DelegateCommand(async () => await HandleGetUsersCommandAsync());
        }

        private async Task HandleGetUsersCommandAsync()
        {
            //Chama uma api

            //Products = new ObservableCollection<Product>()

            //throw new NotImplementedException();
        }

        private async Task HandleRemoveButtonCommandAsync()
        {
            //Chama a API para remove

            Products.Remove(SelectProduct);
        }

        private void HandleEditButtonCommand()
        {
            throw new System.NotImplementedException();
        }

        private void HandleAddButtonCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}