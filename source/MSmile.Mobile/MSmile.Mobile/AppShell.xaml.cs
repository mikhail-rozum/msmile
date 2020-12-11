namespace MSmile.Mobile
{
    using MSmile.Mobile.Views;
    using System;
    using Xamarin.Forms;

    using MSmile.Mobile.Views.DifficultyLevel;

    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DifficultyLevelDetailPage), typeof(DifficultyLevelDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
