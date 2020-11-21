namespace MSmile.Services.Integration.Tests
{
    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    /// <inheritdoc />
    public class TaskServiceTests : TestBase<TaskService>
    {
        /// <inheritdoc />
        public TaskServiceTests(DiFixture diFixture)
            : base(diFixture)
        {
        }

        /// <summary>
        /// Add successful test.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task AddShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    await context.DifficultyLevel.AddAsync(level);
                    await context.SaveChangesAsync();

                    var dto = new TaskDto
                    {
                        Name = "Name",
                        CustomerDescription = "Customer description",
                        DifficultyLevelId = level.Id,
                        Description = "Description"
                    };

                    var result = await service.Add(dto);
                    var entity = await context.Task.FirstOrDefaultAsync(x => x.Id == result.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.Name.Should().Be(entity.Name);
                    dto.Description.Should().Be(entity.Description);
                    dto.CustomerDescription.Should().Be(entity.CustomerDescription);
                    dto.DifficultyLevelId.Should().Be(entity.DifficultyLevelId);

                });
        }

        /// <summary>
        /// Update success test.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task UpdateShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    var level2 = new DifficultyLevel
                    {
                        Name = "Name new"
                    };

                    var task = new Task
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevel.AddAsync(level);
                    await context.DifficultyLevel.AddAsync(level2);
                    await context.Task.AddAsync(task);
                    await context.SaveChangesAsync();

                    var dto = new TaskDto
                    {
                        Id = task.Id,
                        Name = "Name1",
                        Description = "Desc1",
                        DifficultyLevelId = level2.Id
                    };

                    var result = await service.Update(dto);
                    var entity = await context.Task.FirstOrDefaultAsync(x => x.Id == task.Id);

                    dto.Id.Should().Be(result.Id);
                    dto.Id.Should().Be(entity.Id);

                    dto.DifficultyLevelId.Should().Be(result.DifficultyLevelId);
                    dto.DifficultyLevelId.Should().Be(entity.DifficultyLevelId);

                    dto.Description.Should().Be(result.Description);
                    dto.Description.Should().Be(entity.Description);
                });
        }

        /// <summary>
        /// Delete successful test.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task DeleteShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    var level2 = new DifficultyLevel
                    {
                        Name = "Name new"
                    };

                    var task = new Task
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevel.AddAsync(level);
                    await context.DifficultyLevel.AddAsync(level2);
                    await context.Task.AddAsync(task);
                    await context.SaveChangesAsync();

                    await service.Delete(task.Id);
                    var entity = await context.Task.FirstOrDefaultAsync(x => x.Id == task.Id);

                    entity.Should().BeNull();
                });
        }

        /// <summary>
        /// Get should return a record.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task GetShouldReturn()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    var level2 = new DifficultyLevel
                    {
                        Name = "Name new"
                    };

                    var task = new Task
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevel.AddAsync(level);
                    await context.DifficultyLevel.AddAsync(level2);
                    await context.Task.AddAsync(task);
                    await context.SaveChangesAsync();

                    var result = await service.Get(task.Id);

                    result.Should().NotBeNull();
                });
        }
    }
}
