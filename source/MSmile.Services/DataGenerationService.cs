namespace MSmile.Services
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using MSmile.DataMaker.Fakers;
    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Data generation service.
    /// </summary>
    public class DataGenerationService : BaseService
    {
        /// <inheritdoc />
        public DataGenerationService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        /// <summary>
        /// Generates Employeees and inserts them to database.
        /// </summary>
        /// <param name="count">Amount of records.</param>
        /// <returns>Records.</returns>
        public List<EmployeeDto> GenerateEmployees(int count)
        {
            return this.ExecuteInDb(
                uow =>
                {
                    var faker = new EmployeeFaker();
                    var result = faker.Generate(count);
                    var entities = this.Mapper.Map<List<Employee>>(result);
                    uow.EmployeeRepository.Add(entities);

                    return result;
                });
        }
    }
}
