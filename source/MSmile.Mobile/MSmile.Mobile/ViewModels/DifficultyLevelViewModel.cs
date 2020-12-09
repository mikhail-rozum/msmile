namespace MSmile.Mobile.ViewModels
{
    using MSmile.Mobile.Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;

    public class DifficultyLevelViewModel : BaseViewModel
    {
        private DifficultyLevelDto _selectedItem;

        public DifficultyLevelClient DifficultyLevelClient => DependencyService.Get<DifficultyLevelClient>();
        public ObservableCollection<DifficultyLevelDto> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<DifficultyLevelDto> ItemTapped { get; }

        public DifficultyLevelViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<DifficultyLevelDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<DifficultyLevelDto>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DifficultyLevelClient.GetAllAllAsync();
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public DifficultyLevelDto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(DifficultyLevelDetailPage));
        }

        async void OnItemSelected(DifficultyLevelDto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            var state = $"{nameof(DifficultyLevelDetailPage)}?{nameof(DifficultyLevelDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }
    }
}