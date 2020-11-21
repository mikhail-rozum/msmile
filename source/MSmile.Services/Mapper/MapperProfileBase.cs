namespace MSmile.Services.Mapper
{
    using AutoMapper;

    using MSmile.Db.Infrastructure;

    /// <summary>
    /// Base mapper profile.
    /// </summary>
    public abstract class MapperProfileBase : Profile
    {
        /// <inheritdoc />
        protected MapperProfileBase()
        {
            this.ForAllPropertyMaps(x => typeof(IEntityWithId).IsAssignableFrom(x.DestinationType), (map, expression) => expression.Ignore());
        }
    }
}
