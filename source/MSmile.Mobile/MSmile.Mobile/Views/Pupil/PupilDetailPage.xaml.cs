namespace MSmile.Mobile.Views.Pupil
{
    using System;

    using MSmile.Mobile.ViewModels.Pupil;

    using Rg.Plugins.Popup.Pages;

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

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopupPage());
        }
    }
}