namespace MSmile.Services.DataServices
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Pupil service.
    /// </summary>
    public class PupilService : BaseCrudService<Pupil, PupilDto>
    {
        /// <inheritdoc />
        public PupilService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Pupil> pupilRepository)
            : base(mapper, serviceProvider, pupilRepository)
        {
        }

        /// <inheritdoc />
        protected override Task<Pupil> GetEntityForUpdate(long id)
        {
            return this.Repository.Get(x => x.Id == id)
                .Include(x => x.ParentPupils)
                .SingleOrDefaultAsync();
        }
    }
}
