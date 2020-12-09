namespace MSmile.Mobile.Views.DifficultyLevel
{
    using Xamarin.Forms;

    using MSmile.Mobile.ViewModels.DifficultyLevel;

    public partial class DifficultyLevelDetailPage : ContentPage
    {
        public DifficultyLevelDetailPage()
        {
            InitializeComponent();
            BindingContext = new DifficultyLevelDetailViewModel();
        }
    }
}