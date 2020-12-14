namespace MSmile.Mobile
{
    using System;
    using Xamarin.Forms;

    using MSmile.Mobile.Views.DifficultyLevel;
    using MSmile.Mobile.Views.Employee;
    using MSmile.Mobile.Views.Parent;

    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DifficultyLevelDetailPage), typeof(DifficultyLevelDetailPage));
            Routing.RegisterRoute(nameof(EmployeeDetailPage), typeof(EmployeeDetailPage));
            Routing.RegisterRoute(nameof(ParentDetailPage), typeof(ParentDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
