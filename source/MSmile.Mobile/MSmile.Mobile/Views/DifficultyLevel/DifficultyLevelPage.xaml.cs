namespace MSmile.Mobile.Views.DifficultyLevel
{
    using Xamarin.Forms;

    using MSmile.Mobile.ViewModels.DifficultyLevel;

    public partial class DifficultyLevelPage : ContentPage
    {
        DifficultyLevelViewModel _viewModel;

        public DifficultyLevelPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DifficultyLevelViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}