namespace MSmile.Mobile.Views.Parent
{
    using MSmile.Mobile.ViewModels.Parent;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParentDetailPage : ContentPage
    {
        public ParentDetailPage()
        {
            InitializeComponent();
            BindingContext = new ParentDetailViewModel();
        }
    }
}