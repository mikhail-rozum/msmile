namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Pupil service.
    /// </summary>
    public class PupilService : BaseCrudService<Pupil, PupilDto>
    {
        /// <inheritdoc />
        public PupilService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
    }
}
