namespace MSmile.Mobile
{
    using AutoMapper;

    using MSmile.Dto.Dto;
    using MSmile.Mobile.ViewModels.DifficultyLevel;
    using MSmile.Mobile.ViewModels.Employee;

    /// <summary>
    /// Automapper profile.
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public MapperProfile()
        {
            CreateMap<DifficultyLevelDto, DifficultyLevelItemViewModel>();
            CreateMap<EmployeeDto, EmployeeItemViewModel>();
        }
    }
}
