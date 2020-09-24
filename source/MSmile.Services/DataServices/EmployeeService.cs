namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Employee service.
    /// </summary>
    public class EmployeeService : BaseCrudService<Employee, EmployeeDto>
    {
        /// <inheritdoc />
        public EmployeeService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
    }
}
