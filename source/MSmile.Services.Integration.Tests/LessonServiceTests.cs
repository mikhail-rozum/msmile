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
    public class LessonServiceTests : TestBase<LessonService>
    {
        /// <inheritdoc />
        public LessonServiceTests(DiFixture diFixture)
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
                    var employee = new Employee
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        IsFired = false,
                        Comment = "Comment"
                    };

                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        Comment = "Comment"
                    };

                    await context.Employees.AddAsync(employee);
                    await context.Pupils.AddAsync(pupil);
                    await context.SaveChangesAsync();

                    var dto = new LessonDto
                    {
                        Comment = "Comment",
                        Date = DateTime.UtcNow,
                        EmployeeId = employee.Id,
                        FactDate = DateTime.UtcNow.AddDays(1),
                        PupilId = pupil.Id
                    };

                    var result = await service.Add(dto);

                    var entity = await context
                        .Lessons
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    dto.Comment.Should().Be(entity.Comment);
                    dto.Date.Date.Should().Be(entity.Date.Date);
                    dto.EmployeeId.Should().Be(entity.EmployeeId);
                    dto.FactDate.Value.Date.Should().Be(entity.FactDate.Value.Date);
                    dto.PupilId.Should().Be(entity.PupilId);
                });
        }

        /// <summary>
        /// Update successful test.
        /// </summary>
        /// <returns></returns>
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
                        IsFired = false,
                        Comment = "Comment"
                    };

                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        Comment = "Comment"
                    };

                    var lesson = new Lesson
                    {
                        Comment = "Comment",
                        Date = DateTime.UtcNow,
                        Employee = employee,
                        FactDate = DateTime.UtcNow.AddDays(1),
                        Pupil = pupil
                    };

                    await context.Employees.AddAsync(employee);
                    await context.Pupils.AddAsync(pupil);
                    await context.Lessons.AddAsync(lesson);
                    await context.SaveChangesAsync();

                    var dto = new LessonDto
                    {
                        Id = lesson.Id,
                        Comment = "Comment1",
                        Date = DateTime.UtcNow.AddDays(3),
                        EmployeeId = employee.Id,
                        FactDate = DateTime.UtcNow.AddDays(4),
                        PupilId = pupil.Id,
                    };

                    var result = await service.Update(dto);

                    var entity = await context.Lessons.FirstOrDefaultAsync(x => x.Id == lesson.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.Id.Should().Be(result.Id);
                    dto.Id.Should().Be(entity.Id);

                    dto.Comment.Should().Be(result.Comment);
                    dto.Comment.Should().Be(entity.Comment);

                    dto.Date.Date.Should().Be(result.Date.Date);
                    dto.Date.Date.Should().Be(entity.Date.Date);

                    dto.EmployeeId.Should().Be(result.EmployeeId);
                    dto.EmployeeId.Should().Be(entity.EmployeeId);

                    dto.FactDate.Value.Date.Should().Be(result.FactDate.Value.Date);
                    dto.FactDate.Value.Date.Should().Be(entity.FactDate.Value.Date);

                    dto.PupilId.Should().Be(result.PupilId);
                    dto.PupilId.Should().Be(entity.PupilId);
                });
        }

        /// <summary>
        /// Delete successful test.
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
                        IsFired = false,
                        Comment = "Comment"
                    };

                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        Comment = "Comment"
                    };

                    var lesson = new Lesson
                    {
                        Comment = "Comment",
                        Date = DateTime.UtcNow,
                        Employee = employee,
                        FactDate = DateTime.UtcNow.AddDays(1),
                        Pupil = pupil
                    };

                    await context.Employees.AddAsync(employee);
                    await context.Pupils.AddAsync(pupil);
                    await context.Lessons.AddAsync(lesson);
                    await context.SaveChangesAsync();

                    await service.Delete(lesson.Id);

                    var entity = await context.Lessons.FirstOrDefaultAsync(x => x.Id == lesson.Id);

                    entity.Should().BeNull();
                });
        }

        /// <summary>
        /// Get should return a record.
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
                        IsFired = false,
                        Comment = "Comment"
                    };

                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow,
                        Comment = "Comment"
                    };

                    var lesson = new Lesson
                    {
                        Comment = "Comment",
                        Date = DateTime.UtcNow,
                        Employee = employee,
                        FactDate = DateTime.UtcNow.AddDays(1),
                        Pupil = pupil
                    };

                    await context.Employees.AddAsync(employee);
                    await context.Pupils.AddAsync(pupil);
                    await context.Lessons.AddAsync(lesson);
                    await context.SaveChangesAsync();

                    var result = await service.Get(lesson.Id);

                    result.Should().NotBeNull();
                });
        }
    }
}
