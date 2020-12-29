namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Service for Check list.
    /// </summary>
    public class CheckListService : BaseCrudService<CheckList, CheckListDto>
    {
        /// <inheritdoc />
        public CheckListService(IMapper mapper, IServiceProvider serviceProvider, IRepository<CheckList> repository)
            : base(mapper, serviceProvider, repository)
        {
        }
    }
}
