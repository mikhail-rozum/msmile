namespace MSmile.Services.Mapper
{
    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Common mappings profile.
    /// </summary>
    public class CommonMapperProfile : Profile
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public CommonMapperProfile()
        {
            this.CreateMap<Employee, EmployeeDto>().ReverseMap();
            this.CreateMap<Pupil, PupilDto>().ReverseMap();
            this.CreateMap<Parent, ParentDto>().ReverseMap();
        }
    }
}
