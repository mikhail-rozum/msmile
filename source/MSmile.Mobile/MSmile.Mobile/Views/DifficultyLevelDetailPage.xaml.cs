using MSmile.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MSmile.Mobile.Views
{
    public partial class DifficultyLevelDetailPage : ContentPage
    {
        public DifficultyLevelDetailPage()
        {
            InitializeComponent();
            BindingContext = new DifficultyLevelDetailViewModel();
        }
    }
}