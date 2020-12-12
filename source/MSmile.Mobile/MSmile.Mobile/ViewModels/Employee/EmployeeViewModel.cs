namespace MSmile.Mobile.ViewModels.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AutoMapper;

    using MSmile.Api.Client;

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

        public Command LoadItemsCommand => new Command(async () => await ExecuteLoadItems());

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
                var mapper = DependencyService.Get<IMapper>();
                Items.Clear();
                var result = await DependencyService.Get<EmployeeClient>().GetAllAllAsync();
                var items = mapper.Map<List<EmployeeItemViewModel>>(result);
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
    }
}
