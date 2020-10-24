namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Parent service.
    /// </summary>
    public class ParentService : BaseCrudService<Parent, ParentDto>
    {
        /// <inheritdoc />
        public ParentService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Parent> parentRepository)
            : base(mapper, serviceProvider, parentRepository)
        {
        }
    }
}
