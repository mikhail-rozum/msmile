namespace MSmile.Mobile.Views.Skill
{
    using MSmile.Mobile.ViewModels.Skill;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillDetailPage : ContentPage
    {
        public SkillDetailPage()
        {
            InitializeComponent();
            BindingContext = new SkillDetailViewModel();
        }
    }
}