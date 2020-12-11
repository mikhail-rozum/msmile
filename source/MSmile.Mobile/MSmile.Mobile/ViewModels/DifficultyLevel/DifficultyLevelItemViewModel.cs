namespace MSmile.Mobile.ViewModels.DifficultyLevel
{
    using System;
    using System.Linq;

    using MSmile.Api.Client;

    using Xamarin.Forms;

    /// <summary>
    /// Difficulty level item view model.
    /// </summary>
    public class DifficultyLevelItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        public Command<DifficultyLevelViewModel> DeleteCommand => new Command<DifficultyLevelViewModel>(OnDelete);

        private async void OnDelete(DifficultyLevelViewModel viewModel)
        {
            try
            {
                await DependencyService.Get<DifficultyLevelClient>().DeleteAsync(this.Id);
                var item = viewModel.Items.First(x => x.Id == this.Id);
                viewModel.Items.Remove(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Removing difficulty level error: {ex.Message}");
            }
        }
    }
}
