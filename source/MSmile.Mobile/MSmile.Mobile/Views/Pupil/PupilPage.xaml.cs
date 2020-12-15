namespace MSmile.Mobile.Views.Pupil
{
    using MSmile.Mobile.ViewModels.Pupil;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PupilPage : ContentPage
    {
        private PupilViewModel _viewModel;

        public PupilPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PupilViewModel();
        }

        /// <inheritdoc />
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}