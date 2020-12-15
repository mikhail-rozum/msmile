namespace MSmile.Mobile.ViewModels.Pupil
{
    using System;
    using System.Linq;

    using MSmile.Api.Client;

    using Xamarin.Forms;

    /// <summary>
    /// Pupil item view model.
    /// </summary>
    public class PupilItemViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthDate;
        private string _comment;

        /// <summary>
        /// ctor.
        /// </summary>
        public PupilItemViewModel()
        {
            PupilClient = DependencyService.Get<PupilClient>();
        }

        /// <summary>
        /// Pupil client.
        /// </summary>
        private PupilClient PupilClient { get; }

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
        public Command<PupilViewModel> DeleteCommand => new Command<PupilViewModel>(ExecuteDelete);

        private async void ExecuteDelete(PupilViewModel viewModel)
        {
            try
            {
                await PupilClient.DeleteAsync(this.Id);
                var item = viewModel.Items.First(x => x.Id == this.Id);
                viewModel.Items.Remove(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Removing pupil error");
                Console.WriteLine(ex);
            }
        }
    }
}
