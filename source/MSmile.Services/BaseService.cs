namespace MSmile.Services
{
    using AutoMapper;

    /// <summary>
    /// Base service class
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        protected BaseService(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        /// <summary>
        /// Mapper.
        /// </summary>
        protected IMapper Mapper { get; }
    }
}
