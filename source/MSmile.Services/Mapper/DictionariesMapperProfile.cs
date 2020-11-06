namespace MSmile.Services.Mapper
{
    using System.Linq;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Mappings for dictionaries
    /// </summary>
    public class DictionariesMapperProfile : Profile
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public DictionariesMapperProfile()
        {
            this.CreateMap<Skill, DictionaryDto>();
            this.CreateMap<Skill, SkillDto>().ReverseMap();
            this.CreateMap<DifficultyLevel, DifficultyLevelDto>().ReverseMap();
            this.CreateMap<Task, TaskDto>()
                .ForMember(dst => dst.DifficultyLevelName, opt => opt.MapFrom(src => src.DifficultyLevel.Name));
            this.CreateMap<TaskDto, Task>();
            this.CreateMap<LessonTask, DictionaryDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Task.Name));
            this.CreateMap<Lesson, LessonDto>();
            this.CreateMap<LessonDto, Lesson>().ForMember(
                dst => dst.LessonTask,
                opt => opt.MapFrom(src => src.Tasks.Select(x => new LessonTask { LessonId = src.Id, TaskId = x.Id })));
        }
    }
}
