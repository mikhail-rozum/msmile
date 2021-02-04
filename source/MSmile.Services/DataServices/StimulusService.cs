namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Stimulus service.
    /// </summary>
    public class StimulusService : BaseCrudService<Stimulus, StimulusDto>
    {
        /// <inheritdoc />
        public StimulusService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Stimulus> repository)
            : base(mapper, serviceProvider, repository)
        {
        }
    }
}
