namespace MSmile.Mobile.ViewModels.DifficultyLevel
{
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

        public Command<DifficultyLevelItemViewModel> DeleteCommand => new Command<DifficultyLevelItemViewModel>(OnDelete);

        private void OnDelete(DifficultyLevelItemViewModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}
