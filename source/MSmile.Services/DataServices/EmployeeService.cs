namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Employee service.
    /// </summary>
    public class EmployeeService : BaseCrudService<Employee, EmployeeDto>
    {
        /// <inheritdoc />
        public EmployeeService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Employee> employeeRepository)
            : base(mapper, serviceProvider, employeeRepository)
        {
        }
    }
}
