using MSmile.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MSmile.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}