namespace MSmile.Mobile.Views.Employee
{
    using MSmile.Mobile.ViewModels.Employee;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetailPage : ContentPage
    {
        public EmployeeDetailPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeDetailViewModel();
        }
    }
}