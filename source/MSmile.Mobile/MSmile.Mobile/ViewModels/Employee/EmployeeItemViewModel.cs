namespace MSmile.Mobile.ViewModels.Employee
{
    using System;
    using System.Linq;

    using MSmile.Api.Client;

    using Xamarin.Forms;

    /// <summary>
    /// Employee item view model.
    /// </summary>
    public class EmployeeItemViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthDate;
        private bool _isFired;
        private string _comment;

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
        public DateTime BirthDate
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
        /// Delete command.
        /// </summary>
        public Command<EmployeeViewModel> DeleteCommand => new Command<EmployeeViewModel>(OnDelete);

        /// <summary>
        /// Delete handler.
        /// </summary>
        /// <param name="viewModel">Page view model.</param>
        private async void OnDelete(EmployeeViewModel viewModel)
        {
            try
            {
                await DependencyService.Get<EmployeeClient>().DeleteAsync(this.Id);
                var item = viewModel.Items.First(x => x.Id == this.Id);
                viewModel.Items.Remove(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Removing employee error");
                Console.WriteLine(ex);
            }
        }
    }
}
