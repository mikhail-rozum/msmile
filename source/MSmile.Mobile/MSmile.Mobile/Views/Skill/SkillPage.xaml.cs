namespace MSmile.Mobile.Views.Skill
{
    using MSmile.Mobile.ViewModels.Skill;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillPage : ContentPage
    {
        private SkillViewModel _viewModel;

        public SkillPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SkillViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}