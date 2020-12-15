namespace MSmile.Mobile.Views.Pupil
{
    using MSmile.Mobile.ViewModels.Pupil;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PupilDetailPage : ContentPage
    {
        public PupilDetailPage()
        {
            InitializeComponent();
            BindingContext = new PupilDetailViewModel();
        }
    }
}