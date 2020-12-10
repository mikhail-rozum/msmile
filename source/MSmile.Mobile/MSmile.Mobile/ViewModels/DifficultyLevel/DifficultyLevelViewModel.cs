namespace MSmile.Mobile.ViewModels.DifficultyLevel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AutoMapper;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;
    using MSmile.Mobile.Views.DifficultyLevel;

    using Xamarin.Forms;

    public class DifficultyLevelViewModel : BaseViewModel
    {
        private DifficultyLevelItemViewModel _selectedItem;

        public DifficultyLevelClient DifficultyLevelClient => DependencyService.Get<DifficultyLevelClient>();
        public ObservableCollection<DifficultyLevelItemViewModel> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command RemoveItemCommand { get; }
        public Command<DifficultyLevelItemViewModel> ItemTapped { get; }

        public DifficultyLevelViewModel()
        {
            Title = "Уровни сложности";
            Items = new ObservableCollection<DifficultyLevelItemViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<DifficultyLevelItemViewModel>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            RemoveItemCommand = new Command(RemoveItem);
        }

        private void RemoveItem()
        {
            throw new NotImplementedException();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var mapper = DependencyService.Get<IMapper>();
                Items.Clear();
                var result = await DifficultyLevelClient.GetAllAllAsync();
                var items = mapper.Map<List<DifficultyLevelItemViewModel>>(result);
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

        public DifficultyLevelItemViewModel SelectedItem
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

        async void OnItemSelected(DifficultyLevelItemViewModel item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            var state = $"{nameof(DifficultyLevelDetailPage)}?{nameof(DifficultyLevelDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }
    }
}