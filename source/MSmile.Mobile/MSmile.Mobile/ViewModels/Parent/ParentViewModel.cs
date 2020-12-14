namespace MSmile.Mobile.ViewModels.Parent
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using MSmile.Api.Client;
    using MSmile.Mobile.Views.Parent;

    using Xamarin.Forms;

    /// <summary>
    /// Parent view model.
    /// </summary>
    public class ParentViewModel : BaseViewModel
    {
        private readonly ParentClient _parentClient;
        private ObservableCollection<ParentItemViewModel> _items;
        private ParentItemViewModel _selectedItem;

        /// <summary>
        /// ctor.
        /// </summary>
        public ParentViewModel()
        {
            Items = new ObservableCollection<ParentItemViewModel>();
            _parentClient = DependencyService.Get<ParentClient>();
        }

        /// <summary>
        /// Selected item.
        /// </summary>
        public ParentItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        /// <summary>
        /// Items.
        /// </summary>
        public ObservableCollection<ParentItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        /// <summary>
        /// Load items command.
        /// </summary>
        public Command LoadItemsCommand => new Command(async () => await ExecuteLoadItems());

        /// <summary>
        /// Add item command
        /// </summary>
        public Command AddItemCommand => new Command(ExecuteAddItem);

        public Command<ParentItemViewModel> ItemTappedCommand => new Command<ParentItemViewModel>(ExecuteTappedItem);

        /// <summary>
        /// On appearing handler.
        /// </summary>
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
                var result = await _parentClient.GetAllAllAsync();
                var items = Mapper.Map<List<ParentItemViewModel>>(result);
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
            await Shell.Current.GoToAsync(nameof(ParentDetailPage));
        }

        private async void ExecuteTappedItem(ParentItemViewModel item)
        {
            if (item == null)
                return;

            var state = $"{nameof(ParentDetailPage)}?{nameof(ParentDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }
    }
}
