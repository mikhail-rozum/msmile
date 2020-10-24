namespace MSmile.Services.Mapper
{
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
        }
    }
}
