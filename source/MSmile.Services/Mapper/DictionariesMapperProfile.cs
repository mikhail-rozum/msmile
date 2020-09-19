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
            this.CreateMap<Skill, SkillDto>().ReverseMap();
        }
    }
}
