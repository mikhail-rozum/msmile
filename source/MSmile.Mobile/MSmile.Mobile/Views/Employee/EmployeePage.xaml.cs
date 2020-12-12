namespace MSmile.Mobile.Views.Employee
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    using MSmile.Mobile.ViewModels.Employee;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        private EmployeeViewModel _viewModel;

        /// <summary>
        /// ctor.
        /// </summary>
        public EmployeePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new EmployeeViewModel();
        }

        /// <inheritdoc />
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
