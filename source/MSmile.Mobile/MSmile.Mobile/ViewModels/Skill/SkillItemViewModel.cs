namespace MSmile.Mobile.ViewModels.Skill
{
    using System;
    using System.Linq;

    using MSmile.Api.Client;

    using Xamarin.Forms;

    /// <summary>
    /// Skill view model.
    /// </summary>
    public class SkillItemViewModel : BaseViewModel
    {
        private long _id;
        private string _name;
        private string _description;

        /// <summary>
        /// Skill client.
        /// </summary>
        private SkillClient SkillClient => DependencyService.Get<SkillClient>();

        /// <summary>
        /// Id.
        /// </summary>
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        /// <summary>
        /// Delete command.
        /// </summary>
        public Command<SkillViewModel> DeleteCommand => new Command<SkillViewModel>(ExecuteDelete);

        private async void ExecuteDelete(SkillViewModel viewModel)
        {
            try
            {
                await SkillClient.DeleteAsync(this.Id);
                var item = viewModel.Items.First(x => x.Id == this.Id);
                viewModel.Items.Remove(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Removing skill error");
                Console.Write(ex);
            }
        }
    }
}
