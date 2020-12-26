namespace MSmile.Services.Mapper
{
    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Mappings for dictionaries
    /// </summary>
    public class DictionariesMapperProfile : MapperProfileBase
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public DictionariesMapperProfile()
        {
            this.CreateMap<Skill, DictionaryDto>();
            this.CreateMap<Skill, SkillDto>().ReverseMap();
            this.CreateMap<DifficultyLevel, DifficultyLevelDto>().ReverseMap();
            this.CreateMap<Exercise, ExerciseDto>()
                .ForMember(dst => dst.DifficultyLevelName, opt => opt.MapFrom(src => src.DifficultyLevel.Name));
            this.CreateMap<ExerciseDto, Exercise>();
            this.CreateMap<Lesson, LessonDto>();
            this.CreateMap<LessonDto, Lesson>();
        }
    }
}
