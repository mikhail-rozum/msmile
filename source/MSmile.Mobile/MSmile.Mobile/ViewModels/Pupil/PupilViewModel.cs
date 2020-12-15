namespace MSmile.Mobile.ViewModels.Pupil
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using MSmile.Api.Client;
    using MSmile.Mobile.Views.Pupil;

    using Xamarin.Forms;

    /// <summary>
    /// Pupil view model.
    /// </summary>
    public class PupilViewModel : BaseViewModel
    {
        private ObservableCollection<PupilItemViewModel> _items;

        /// <summary>
        /// ctor.
        /// </summary>
        public PupilViewModel()
        {
            Items = new ObservableCollection<PupilItemViewModel>();
            PupilClient = DependencyService.Get<PupilClient>();
        }

        /// <summary>
        /// Pupil client.
        /// </summary>
        private PupilClient PupilClient { get; }

        /// <summary>
        /// Items.
        /// </summary>
        public ObservableCollection<PupilItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
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
        public Command<PupilItemViewModel> ItemTappedCommand => new Command<PupilItemViewModel>(ExecuteTappedItem);

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async Task ExecuteLoadItems()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var result = await PupilClient.GetAllAllAsync();
                var items = Mapper.Map<List<PupilItemViewModel>>(result);
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
            await Shell.Current.GoToAsync(nameof(PupilDetailPage));
        }

        private async void ExecuteTappedItem(PupilItemViewModel item)
        {
            if (item == null)
                return;

            var state = $"{nameof(PupilDetailPage)}?{nameof(PupilDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }
    }
}
