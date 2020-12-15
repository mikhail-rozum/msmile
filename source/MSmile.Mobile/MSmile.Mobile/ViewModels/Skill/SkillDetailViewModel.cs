namespace MSmile.Mobile.ViewModels.Skill
{
    using System;
    using System.Diagnostics;

    using MSmile.Api.Client;
    using MSmile.Dto.Dto;

    using Xamarin.Forms;

    /// <summary>
    /// Skill detail view model.
    /// </summary>
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class SkillDetailViewModel : BaseViewModel
    {
        private long _id;
        private string _name;
        private string _description;
        private string _itemId;

        /// <summary>
        /// Skill client.
        /// </summary>
        private SkillClient SkillClient => DependencyService.Get<SkillClient>();

        /// <summary>
        /// Item id.
        /// </summary>
        public string ItemId
        {
            get => _itemId;
            set => _itemId = value;
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
        /// Name.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        /// <summary>
        /// Cancel command.
        /// </summary>
        public Command CancelCommand => new Command(ExecuteCancel);

        /// <summary>
        /// Save command.
        /// </summary>
        public Command SaveCommand => new Command(ExecuteSave, Validate);

        private bool Validate()
        {
            return true;
        }

        private async void ExecuteSave()
        {
            try
            {
                var dto = Mapper.Map<SkillDto>(this);
                if (_id == default)
                    await SkillClient.AddAsync(dto);
                else
                    await SkillClient.UpdateAsync(dto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void ExecuteCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void LoadItem(long id)
        {
            try
            {
                //var dto = await SkillClient.GetAllAllAsync()
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
