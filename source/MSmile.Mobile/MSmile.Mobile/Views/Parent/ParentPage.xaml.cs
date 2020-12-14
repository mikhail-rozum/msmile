namespace MSmile.Mobile.Views.Parent
{
    using MSmile.Mobile.ViewModels.Parent;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParentPage : ContentPage
    {
        private ParentViewModel _viewModel;

        /// <summary>
        /// ctor.
        /// </summary>
        public ParentPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ParentViewModel();
        }

        /// <inheritdoc />
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}