using MiniERP.Models;
using MiniERP.UI.ViewModels.Dialogs.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace MiniERP.UI.ViewModels
{
    public sealed class UnitViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private Unit? _selectUnit;
        private ObservableCollection<Unit> _items = null!;

        public ObservableCollection<Unit> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Unit? SelectedItem
        {
            get => _selectUnit;
            set => SetProperty(ref _selectUnit, value);
        }

        public DelegateCommand AddButtonCommand { get; }
        public DelegateCommand EditButtonCommand { get; }
        public DelegateCommand RemoveButtonCommand { get; }
        public DelegateCommand GetUnitCommand { get; }

        public UnitViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            AddButtonCommand = new DelegateCommand(HandleAddButtonCommand);
            EditButtonCommand = new DelegateCommand(HandleEditButtonCommand, () => SelectedItem != null).ObservesProperty(() => SelectedItem);
            RemoveButtonCommand = new DelegateCommand(HandleRemoveButtonCommandAsync, () => SelectedItem != null).ObservesProperty(() => SelectedItem);
            GetUnitCommand = new DelegateCommand(HandleGetUsersCommandAsync);
        }

        private void HandleGetUsersCommandAsync()
        {
            //Todo: Chama a API ou local

            Items = new ObservableCollection<Unit>();
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

            _dialogService.ShowDialog(DialogNames.AddOrEditUnitDialogName, new DialogParameters { { nameof(Unit), SelectedItem } }, EditButtonCommandCallbackAsync);
        }

        private void EditButtonCommandCallbackAsync(IDialogResult dialogResult)
        {
            if (dialogResult.Result != ButtonResult.OK)
                return;

            var unit = dialogResult.Parameters.GetValue<Unit>(nameof(Unit));

            //Todo: Enviar para API ou salvar local

            ArgumentNullException.ThrowIfNull(SelectedItem);

            Items.Remove(SelectedItem);
            Items.Add(unit);
            SelectedItem = unit;
        }

        private void HandleAddButtonCommand()
            => _dialogService.ShowDialog(DialogNames.AddOrEditUnitDialogName, AddButtonCommandCallback);

        private void AddButtonCommandCallback(IDialogResult dialogResult)
        {
            if (dialogResult.Result != ButtonResult.OK)
                return;

            var unit = dialogResult.Parameters.GetValue<Unit>(nameof(Unit));

            //Todo: Enviar para API ou salvar local

            Items.Add(unit);
        }
    }
}