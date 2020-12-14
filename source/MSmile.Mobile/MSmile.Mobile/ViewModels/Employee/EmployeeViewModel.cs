namespace MSmile.Mobile.ViewModels.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AutoMapper;

    using MSmile.Api.Client;
    using MSmile.Mobile.Views.Employee;

    using Xamarin.Forms;

    /// <summary>
    /// Employee page view model.
    /// </summary>
    public class EmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeItemViewModel> _items;
        private EmployeeItemViewModel _selectedItem;

        /// <summary>
        /// Items.
        /// </summary>
        public ObservableCollection<EmployeeItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        /// <summary>
        /// Selected item.
        /// </summary>
        public EmployeeItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        /// <summary>
        /// Load item command.
        /// </summary>
        public Command LoadItemsCommand => new Command(async () => await ExecuteLoadItems());

        /// <summary>
        /// Add item command.
        /// </summary>
        public Command AddItemCommand => new Command(ExecuteAddItem);

        /// <summary>
        /// Item tapped command.
        /// </summary>
        public Command<EmployeeItemViewModel> ItemTappedCommand => new Command<EmployeeItemViewModel>(ExecuteTappedItem);

        /// <summary>
        /// ctor.
        /// </summary>
        public EmployeeViewModel()
        {
            Items = new ObservableCollection<EmployeeItemViewModel>();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        private async Task ExecuteLoadItems()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var result = await DependencyService.Get<EmployeeClient>().GetAllAllAsync();
                var items = Mapper.Map<List<EmployeeItemViewModel>>(result);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ExecuteAddItem()
        {
            await Shell.Current.GoToAsync(nameof(EmployeeDetailPage));
        }

        private async void ExecuteTappedItem(EmployeeItemViewModel item)
        {
            if (item == null)
                return;
            
            var state = $"{nameof(EmployeeDetailPage)}?{nameof(EmployeeDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }
    }
}
