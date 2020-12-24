namespace MSmile.Mobile.Views.Pupil
{
    using System;

    using dotMorten.Xamarin.Forms;

    using MSmile.Mobile.ViewModels.Parent;
    using MSmile.Mobile.ViewModels.Pupil;

    using Rg.Plugins.Popup.Extensions;

    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseParentView
    {
        public ChooseParentViewModel ViewModel { get; }

        public bool Result { get; private set; }



        public ChooseParentView(long pupilId)
        {
            InitializeComponent();

            BindingContext = ViewModel = new ChooseParentViewModel(pupilId);
        }

        private void OnTextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var autocompleteBox = (AutoSuggestBox)sender;
                ViewModel.UpdateSuggestions(autocompleteBox.Text);
            }
        }

        private void OnQuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if (e.ChosenSuggestion is ParentItemViewModel selectedItem)
            {
                ViewModel.SelectedItem = selectedItem;
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            Result = true;
            Navigation.PopPopupAsync();
        }
    }
}