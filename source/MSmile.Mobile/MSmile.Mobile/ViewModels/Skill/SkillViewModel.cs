namespace MSmile.Mobile.ViewModels.Skill
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using MSmile.Api.Client;
    using MSmile.Mobile.Views.Skill;

    using Xamarin.Forms;

    /// <summary>
    /// Skill view model.
    /// </summary>
    public class SkillViewModel : BaseViewModel
    {
        private ObservableCollection<SkillItemViewModel> _items;

        /// <summary>
        /// ctor.
        /// </summary>
        public SkillViewModel()
        {
            Items = new ObservableCollection<SkillItemViewModel>();
            SkillClient = DependencyService.Get<SkillClient>();
        }

        /// <summary>
        /// Items.
        /// </summary>
        public ObservableCollection<SkillItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        /// <summary>
        /// Skill client.
        /// </summary>
        private SkillClient SkillClient { get; }

        /// <summary>
        /// Load items command.
        /// </summary>
        public Command LoadItemsCommand => new Command(async () => await ExecuteLoadItems());

        /// <summary>
        /// Add item command.
        /// </summary>
        public Command AddItemCommand => new Command(ExecuteAddItem);

        /// <summary>
        /// Item tapped command.
        /// </summary>
        public Command<SkillItemViewModel> ItemTappedCommand => new Command<SkillItemViewModel>(ExecuteTappedItem);

        /// <summary>
        /// On appearing handler.
        /// </summary>
        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void ExecuteTappedItem(SkillItemViewModel item)
        {
            if (item == null)
                return;

            var state = $"{nameof(SkillDetailPage)}?{nameof(SkillDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(state);
        }

        private async Task ExecuteLoadItems()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var result = await SkillClient.GetAllAllAsync();
                var items = Mapper.Map<List<SkillItemViewModel>>(result);
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
            await Shell.Current.GoToAsync(nameof(SkillDetailPage));
        }
    }
}
