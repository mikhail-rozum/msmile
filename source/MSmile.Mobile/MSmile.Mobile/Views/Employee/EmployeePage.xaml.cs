using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSmile.Mobile.Views.Employee
{
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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        /// <inheritdoc />
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
