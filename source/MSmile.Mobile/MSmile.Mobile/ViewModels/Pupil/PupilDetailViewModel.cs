namespace MSmile.Mobile.ViewModels.Pupil
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;
    using MSmile.Mobile.ViewModels.Parent;

    using Xamarin.Forms;

    using ChooseParentView = MSmile.Mobile.Views.Pupil.ChooseParentView;

    /// <summary>
    /// Pupil detail view model.
    /// </summary>
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PupilDetailViewModel : BaseViewModel
    {
        private long _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthDate;
        private string _comment;
        private string _itemId;

        private ObservableCollection<ListItemViewModel> _parents;

        private ParentViewModel _parent;

        /// <summary>
        /// ctor.
        /// </summary>
        public PupilDetailViewModel()
        {
            PupilClient = DependencyService.Get<PupilClient>();
        }

        /// <summary>
        /// Pupil client.
        /// </summary>
        private PupilClient PupilClient { get; }

        /// <summary>
        /// Item id.
        /// </summary>
        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                if (!string.IsNullOrEmpty(_itemId))
                    LoadItem(Convert.ToInt64(_itemId));
            }
        }

        /// <summary>
        /// Id.
        /// </summary>
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        /// <summary>
        /// Middle name.
        /// </summary>
        public string MiddleName
        {
            get => _middleName;
            set => SetProperty(ref _middleName, value);
        }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        /// <summary>
        /// Birth date.
        /// </summary>
        public DateTime BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        /// <summary>
        /// Parent.
        /// </summary>
        public ParentViewModel Parent
        {
            get => _parent;
            set => SetProperty(ref _parent, value);
        }

        /// <summary>
        /// Parents.
        /// </summary>
        public ObservableCollection<ListItemViewModel> Parents
        {
            get => _parents;
            set => SetProperty(ref _parents, value);
        }

        /// <summary>
        /// Save command.
        /// </summary>
        public Command SaveCommand => new Command(ExecuteSave, Validate);

        /// <summary>
        /// Cancel command.
        /// </summary>
        public Command CancelCommand => new Command(ExecuteCancel);

        /// <summary>
        /// Add parent command.
        /// </summary>
        public Command AddParentCommand => new Command(ExecuteAddParent);

        /// <summary>
        /// Delete parent command.
        /// </summary>
        public Command<long> DeleteParentCommand => new Command<long>(ExecuteDeleteParent);

        private async void ExecuteDeleteParent(long parentId)
        {
            try
            {
                var dto = await PupilClient.GetAsync(Id);
                dto.Parents = dto.Parents?.Where(x => x.Id != parentId).ToList();
                await PupilClient.UpdateAsync(dto);
                var removedParent = Parents.First(x => x.Id == parentId);
                Parents.Remove(removedParent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void ExecuteAddParent()
        {
            var page = new ChooseParentView(Id);
            page.Disappearing += OnChooseParentClosed;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(page);
        }

        private async void ExecuteCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private bool Validate()
        {
            // TODO: валидация с помощью FluentValidator? Или другими средствами.
            return true;
        }

        private async void ExecuteSave()
        {
            try
            {
                var dto = Mapper.Map<PupilDto>(this);
                if (_id == default)
                    await PupilClient.AddAsync(dto);
                else
                    await PupilClient.UpdateAsync(dto);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void LoadItem(long id)
        {
            try
            {
                var dto = await PupilClient.GetAsync(id);
                Mapper.Map(dto, this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void OnChooseParentClosed(object sender, EventArgs e)
        {
            try
            {
                var page = (ChooseParentView)sender;

                if (!page.Result || page.ViewModel.SelectedItem == null)
                    return;

                this.Parents.Add(
                    new ListItemViewModel
                    {
                        Id = page.ViewModel.SelectedItem.Id,
                        Name = $"{page.ViewModel.SelectedItem.LastName} {page.ViewModel.SelectedItem.FirstName} {page.ViewModel.SelectedItem.MiddleName}"
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
