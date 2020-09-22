namespace MSmile.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.Exceptions;

    /// <summary>
    /// Employee service.
    /// </summary>
    public class EmployeeService : BaseService
    {
        /// <inheritdoc />
        public EmployeeService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>Employees.</returns>
        public List<EmployeeDto> GetAll()
        {
            return this.ExecuteInDb(
                uow => uow.EmployeeRepository
                    .Get()
                    .ProjectTo<EmployeeDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets employee.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Employee.</returns>
        public EmployeeDto Get(long id)
        {
            return this.ExecuteInDb(uow =>
                uow.EmployeeRepository
                   .Get()
                   .Where(x => x.Id == id)
                   .ProjectTo<EmployeeDto>(this.Mapper.ConfigurationProvider)
                   .FirstOrDefault());
        }

        /// <summary>
        /// Adds Employee.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public EmployeeDto Add(EmployeeDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<Employee>(dto);
            return this.ExecuteInDb(
                uow =>
                {
                    uow.EmployeeRepository.Add(entity);
                    uow.Save();

                    return this.Mapper.Map<EmployeeDto>(entity);
                });
        }

        /// <summary>
        /// Updates employee.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public EmployeeDto Update(EmployeeDto dto)
        {
            return this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.EmployeeRepository
                        .Get()
                        .SingleOrDefault(x => x.Id == dto.Id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    this.Mapper.Map(dto, entity);
                    uow.EmployeeRepository.Update(entity);
                    uow.Save();

                    return this.Mapper.Map<EmployeeDto>(entity);
                });
        }

        /// <summary>
        /// Deletes employee.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Delete(long id)
        {
            this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.EmployeeRepository
                        .Get()
                        .FirstOrDefault(x => x.Id == id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    uow.EmployeeRepository.Delete(entity);

                    uow.Save();
                });
        }
    }
}
