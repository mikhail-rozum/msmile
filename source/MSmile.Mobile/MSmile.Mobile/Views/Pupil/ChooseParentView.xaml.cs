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
        private readonly ChooseParentViewModel _viewModel;

        public ChooseParentView(long pupilId)
        {
            InitializeComponent();

            BindingContext = _viewModel = new ChooseParentViewModel(pupilId);
        }

        private void OnTextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var autocompleteBox = (AutoSuggestBox)sender;
                _viewModel.UpdateSuggestions(autocompleteBox.Text);
            }
        }

        private void OnQuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if (e.ChosenSuggestion is ParentItemViewModel selectedItem)
            {
                _viewModel.SelectedItem = selectedItem;
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}