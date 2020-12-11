namespace MSmile.Mobile.ViewModels.DifficultyLevel
{
    using System;
    using System.Diagnostics;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;

    using Xamarin.Forms;

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class DifficultyLevelDetailViewModel : BaseViewModel
    {
        private long _id;
        private string _name;
        private string _itemId;

        /// <summary>
        /// ctor.
        /// </summary>
        public DifficultyLevelDetailViewModel()
        {
            SaveCommand = new Command(OnSave, Validate);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                if (!string.IsNullOrEmpty(value))
                    LoadItemId(Convert.ToInt64(_itemId));
            }
        }

        public long Id
        {
            get =>_id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public async void LoadItemId(long id)
        {
            try
            {
                var item = await DependencyService.Get<DifficultyLevelClient>().GetAsync(id);
                Id = id;
                Name = item.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private bool Validate()
        {
            return !string.IsNullOrEmpty(_name);
        }

        private async void OnSave()
        {
            var dto = new DifficultyLevelDto
            {
                Id = _id,
                Name = _name
            };

            if (_id == default)
                await DependencyService.Get<DifficultyLevelClient>().AddAsync(dto);
            else
                await DependencyService.Get<DifficultyLevelClient>().UpdateAsync(dto);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
