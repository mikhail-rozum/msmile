namespace MSmile.Mobile.ViewModels.Parent
{
    using System;
    using System.Diagnostics;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;

    using Xamarin.Forms;

    /// <summary>
    /// Parent detail view model.
    /// </summary>
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ParentDetailViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _comment;
        private string _itemId;

        /// <summary>
        /// ctor.
        /// </summary>
        public ParentDetailViewModel()
        {
            ParentClient = DependencyService.Get<ParentClient>();
        }

        /// <summary>
        /// Parent client.
        /// </summary>
        private ParentClient ParentClient { get; }

        /// <summary>
        /// Item id.
        /// </summary>
        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                if (!string.IsNullOrEmpty(_itemId))
                    LoadItem(Convert.ToInt64(_itemId));
            }
        }

        /// <summary>
        /// Id.
        /// </summary>
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        /// <summary>
        /// Middle name.
        /// </summary>
        public string MiddleName
        {
            get => _middleName;
            set => SetProperty(ref _middleName, value);
        }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        /// <summary>
        /// Cancel command.
        /// </summary>
        public Command CancelCommand => new Command(ExecuteCancel);

        /// <summary>
        /// Save command.
        /// </summary>
        public Command SaveCommand => new Command(ExecuteSave, Validate);

        private bool Validate()
        {
            return true;
        }

        private async void ExecuteSave()
        {
            try
            {
                var dto = Mapper.Map<ParentDto>(this);
                if (_id == default)
                    await ParentClient.AddAsync(dto);
                else
                    await ParentClient.UpdateAsync(dto);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void ExecuteCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void LoadItem(long id)
        {
            try
            {
                var dto = await ParentClient.GetAsync(id);
                Mapper.Map(dto, this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
