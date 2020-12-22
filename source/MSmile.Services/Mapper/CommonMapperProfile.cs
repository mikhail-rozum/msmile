namespace MSmile.Services.Mapper
{
    using System.Collections.Generic;
    using System.Linq;

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
            this.CreateMap<ParentPupil, ListItemDto>()
                .ForMember(dst => dst.Id, 
                    opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dst => dst.Name, 
                    opt => opt.MapFrom(src => $"{src.Parent.LastName} {src.Parent.FirstName} {src.Parent.MiddleName}"));
            this.CreateMap<Pupil, PupilDto>()
                .ForMember(dst => dst.Parents, opt => opt.MapFrom(src => src.ParentPupil));
            this.CreateMap<PupilDto, Pupil>().ForMember(
                dst => dst.ParentPupil,
                opt =>
                    opt.MapFrom(
                        src => src.Parents == null
                            ? new List<ParentPupil>()
                            : src.Parents.Select(
                                x =>
                                    new ParentPupil
                                    {
                                        ParentId = x.Id, PupilId = src.Id
                                    })));
            this.CreateMap<Parent, ParentDto>().ReverseMap();
            this.CreateMap<Lesson, LessonDto>().ForMember(dst => dst.Tasks, opt => opt.MapFrom(src => src.LessonTask));
        }
    }
}
