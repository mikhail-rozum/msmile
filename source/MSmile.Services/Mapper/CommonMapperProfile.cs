namespace MSmile.Services.Mapper
{
    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Common mappings profile.
    /// </summary>
    public class CommonMapperProfile : MapperProfileBase
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public CommonMapperProfile()
        {
            this.CreateMap<Employee, EmployeeDto>().ReverseMap();
            this.CreateMap<Pupil, PupilDto>().ReverseMap();
            this.CreateMap<Parent, ParentDto>().ReverseMap();
            this.CreateMap<Lesson, LessonDto>().ForMember(dst => dst.Tasks, opt => opt.MapFrom(src => src.LessonTask));
        }
    }
}
