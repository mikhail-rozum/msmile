namespace MSmile.Mobile.ViewModels.Parent
{
    using System;
    using System.Linq;

    using MSmile.Api.Client;

    using Xamarin.Forms;

    /// <summary>
    /// Parent item view model.
    /// </summary>
    public class ParentItemViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _comment;

        private ParentClient ParentClient => DependencyService.Get<ParentClient>();

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

        public Command<ParentViewModel> DeleteCommand => new Command<ParentViewModel>(OnDelete);

        private async void OnDelete(ParentViewModel viewModel)
        {
            try
            {
                await ParentClient.DeleteAsync(this.Id);
                var item = viewModel.Items.First(x => x.Id == this.Id);
                viewModel.Items.Remove(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Removing parent error");
                Console.WriteLine(ex);
            }
        }
    }
}
