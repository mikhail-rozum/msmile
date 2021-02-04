namespace MSmile.Services.Mapper
{
    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Automapper profile with mappring to/from ListItemDto
    /// </summary>
    public class ListItemProfile : MapperProfileBase
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public ListItemProfile()
        {
            this.CreateMap<ParentPupil, ListItemDto>()
                .ForMember(dst => dst.Id,
                    opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dst => dst.Name,
                    opt => opt.MapFrom(src => $"{src.Parent.LastName} {src.Parent.FirstName} {src.Parent.MiddleName}"));
            this.CreateMap<Pupil, ListItemDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}"));
            this.CreateMap<ListItemDto, Pupil>();
        }
    }
}
