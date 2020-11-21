namespace MSmile.Services.Integration.Tests
{
    using System;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    using Task = System.Threading.Tasks.Task;

    /// <inheritdoc />
    public class EmployeeServiceTests : TestBase<EmployeeService>
    {
        /// <inheritdoc />
        public EmployeeServiceTests(DiFixture diFixture)
            : base(diFixture)
        {
        }

        /// <summary>
        /// Add successful test.
        /// </summary>
        [Fact]
        public async Task AddShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var dto = new EmployeeDto
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        IsFired = true,
                        Comment = "Comment"
                    };

                    var result = await service.Add(dto);
                    var entity = await context
                        .Employee
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    entity.Should().NotBeNull();

                    dto.FirstName.Should().Be(entity.FirstName);
                    dto.MiddleName.Should().Be(entity.MiddleName);
                    dto.LastName.Should().Be(entity.LastName);
                    dto.BirthDate.Value.Date.Should().Be(entity.BirthDate.Value);
                    dto.IsFired.Should().Be(entity.IsFired);
                    dto.Comment.Should().Be(entity.Comment);
                });
        }

        /// <summary>
        /// Update successful test.
        /// </summary>
        [Fact]
        public async Task UpdateShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var employee = new Employee
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        IsFired = true,
                        Comment = "Comment"
                    };

                    await context.Employee.AddAsync(employee);
                    await context.SaveChangesAsync();

                    var dto = new EmployeeDto
                    {
                        Id = employee.Id,
                        FirstName = "First name1",
                        MiddleName = "Middle name1",
                        LastName = "Last name1",
                        BirthDate = DateTime.UtcNow.AddDays(1),
                        IsFired = false,
                        Comment = "Comment1"
                    };

                    var result = await service.Update(dto);
                    var entity = await context
                        .Employee
                        .FirstOrDefaultAsync(x => x.Id == employee.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.Id.Should().Be(result.Id);
                    dto.Id.Should().Be(entity.Id);

                    dto.FirstName.Should().Be(result.FirstName);
                    dto.FirstName.Should().Be(entity.FirstName);

                    dto.MiddleName.Should().Be(result.MiddleName);
                    dto.MiddleName.Should().Be(entity.MiddleName);

                    dto.LastName.Should().Be(result.LastName);
                    dto.LastName.Should().Be(entity.LastName);

                    dto.BirthDate.Value.Date.Should().Be(result.BirthDate.Value.Date);
                    dto.BirthDate.Value.Date.Should().Be(entity.BirthDate.Value.Date);

                    dto.IsFired.Should().Be(result.IsFired);
                    dto.IsFired.Should().Be(entity.IsFired);

                    dto.Comment.Should().Be(result.Comment);
                    dto.Comment.Should().Be(entity.Comment);
                });
        }

        /// <summary>
        /// Delete success test.
        /// </summary>
        [Fact]
        public async Task DeleteShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var employee = new Employee
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        IsFired = true,
                        Comment = "Comment"
                    };

                    await context.Employee.AddAsync(employee);
                    await context.SaveChangesAsync();

                    await service.Delete(employee.Id);

                    var entity = await context.Employee.FirstOrDefaultAsync(x => x.Id == employee.Id);
                    entity.Should().BeNull();
                });
        }

        /// <summary>
        /// Get success test.
        /// </summary>
        [Fact]
        public async Task GetShouldReturn()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var employee = new Employee
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        IsFired = true,
                        Comment = "Comment"
                    };

                    await context.Employee.AddAsync(employee);
                    await context.SaveChangesAsync();

                    var result = await service.Get(employee.Id);
                    result.Should().NotBeNull();
                });
        }
    }
}
