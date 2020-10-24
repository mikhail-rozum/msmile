namespace MSmile.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using MSmile.DataMaker.Fakers;
    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Data generation service.
    /// </summary>
    public class DataGenerationService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Parent> parentRepository;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="employeeRepository">Employee repository.</param>
        /// <param name="parentRepository">Parent repository.</param>
        public DataGenerationService(IMapper mapper, IRepository<Employee> employeeRepository, IRepository<Parent> parentRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
            this.parentRepository = parentRepository;
        }

        /// <summary>
        /// Generates Employeees and inserts them to database.
        /// </summary>
        /// <param name="count">Amount of records.</param>
        /// <returns>Records.</returns>
        public async Task<List<EmployeeDto>> GenerateEmployees(int count)
        {
            var faker = new EmployeeFaker();
            var result = faker.Generate(count);
            var entities = this.mapper.Map<List<Employee>>(result);
            await this.employeeRepository.AddAsync(entities);

            return result;
        }

        /// <summary>
        /// Generates Parents and inserts them to database.
        /// </summary>
        /// <param name="count">Amount of records.</param>
        /// <returns>Records.</returns>
        public async Task<List<ParentDto>> GenerateParents(int count)
        {
            var faker = new ParentFaker();
            var result = faker.Generate(count);
            var entities = this.mapper.Map<List<Parent>>(result);
            await this.parentRepository.AddAsync(entities);

            return result;
        }
    }
}
