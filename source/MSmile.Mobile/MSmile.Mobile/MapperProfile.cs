namespace MSmile.Mobile
{
    using System;

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
            CreateMap<EmployeeDto, EmployeeDetailViewModel>();
            CreateMap<EmployeeDetailViewModel, EmployeeDto>()
                .ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => src.BirthDate.HasValue ? src.BirthDate.Value.ToUniversalTime() : (DateTime?)null));
        }
    }
}
