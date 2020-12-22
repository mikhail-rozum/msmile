namespace MSmile.Mobile.ViewModels.Pupil
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;
    using MSmile.Mobile.ViewModels.Parent;

    using Xamarin.Forms;

    /// <summary>
    /// Choose parent for pupil view model.
    /// </summary>
    public class ChooseParentViewModel : BaseViewModel
    {
        private readonly long _pupilId;
        private readonly ParentClient _parentClient;
        private readonly PupilClient _pupilClient;
        private readonly Lazy<List<ParentItemViewModel>> _allParents;
        private string _parentName;
        private List<ParentItemViewModel> _parents;
        private ParentItemViewModel _selectedItem;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="pupilId">Pupil id.</param>
        public ChooseParentViewModel(long pupilId)
        {
            _pupilId = pupilId;
            _parentClient = DependencyService.Get<ParentClient>();
            _pupilClient = DependencyService.Get<PupilClient>();
            _allParents = new Lazy<List<ParentItemViewModel>>(LoadAllParents);
        }

        /// <summary>
        /// Parent name.
        /// </summary>
        public string ParentName
        {
            get => _parentName;
            set
            {
                SetProperty(ref _parentName, value);
            }
        }

        /// <summary>
        /// Selected item.
        /// </summary>
        public ParentItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }

        /// <summary>
        /// Parents.
        /// </summary>
        public List<ParentItemViewModel> Parents
        {
            get => _parents;
            set
            {
                SetProperty(ref _parents, value);
            }
        }

        /// <summary>
        /// Add item command.
        /// </summary>
        public Command AddItemCommand => new Command(ExecuteAddItem);

        /// <summary>
        /// Updates suggestion items source.
        /// </summary>
        /// <param name="query">Query string.</param>
        public void UpdateSuggestions(string query)
        {
            try
            {
                Parents = _allParents.Value
                    .Where(x => 
                        x.FirstName.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                        || x.MiddleName.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                        || x.LastName.Contains(query))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private List<ParentItemViewModel> LoadAllParents()
        {
            try
            {
                var result = _parentClient.GetAllAllAsync().Result;
                return Mapper.Map<List<ParentItemViewModel>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new List<ParentItemViewModel>();
        }

        private async void ExecuteAddItem()
        {
            try
            {
                if (SelectedItem == null)
                    return;

                var dto = await _pupilClient.GetAsync(_pupilId);
                await _pupilClient.AddAsync(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}
