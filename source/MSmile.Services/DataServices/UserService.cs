namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// User service.
    /// </summary>
    public class UserService : BaseCrudService<User, UserDto>
    {
        /// <inheritdoc />
        public UserService(IMapper mapper, IServiceProvider serviceProvider, IRepository<User> repository)
            : base(mapper, serviceProvider, repository)
        {
        }
    }
}
