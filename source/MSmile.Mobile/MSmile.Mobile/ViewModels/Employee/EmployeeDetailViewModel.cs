namespace MSmile.Mobile.ViewModels.Employee
{
    using System;
    using System.Diagnostics;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;

    using Xamarin.Forms;

    /// <summary>
    /// Employee detail view model.
    /// </summary>
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EmployeeDetailViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime? _birthDate;
        private bool _isFired;
        private string _comment;
        private string _itemId;

        /// <summary>
        /// ctor.
        /// </summary>
        public EmployeeDetailViewModel()
        {
            EmployeeClient = DependencyService.Get<EmployeeClient>();
        }

        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                if (!string.IsNullOrEmpty(value))
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
        /// Birth date.
        /// </summary>
        public DateTime? BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        /// <summary>
        /// Is fired.
        /// </summary>
        public bool IsFired
        {
            get => _isFired;
            set => SetProperty(ref _isFired, value);
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
        /// Employee client.
        /// </summary>
        public EmployeeClient EmployeeClient { get; }

        /// <summary>
        /// Save command.
        /// </summary>
        public Command SaveCommand => new Command(ExecuteSave, Validate);

        /// <summary>
        /// Cancel command.
        /// </summary>
        public Command CancelCommand => new Command(ExecuteCancel);

        private async void ExecuteCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private bool Validate()
        {
            // TODO: валидация с помощью FluentValidator? Или другими средствами.
            return true;
        }

        private async void ExecuteSave()
        {
            try
            {
                var dto = Mapper.Map<EmployeeDto>(this);
                if (_id == default)
                    await EmployeeClient.AddAsync(dto);
                else
                    await EmployeeClient.UpdateAsync(dto);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void LoadItem(long id)
        {
            try
            {
                var dto = await EmployeeClient.GetAsync(id);
                Mapper.Map(dto, this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
