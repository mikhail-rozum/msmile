namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Parent service.
    /// </summary>
    public class ParentService : BaseCrudService<Parent, ParentDto>
    {
        /// <inheritdoc />
        public ParentService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
    }
}
