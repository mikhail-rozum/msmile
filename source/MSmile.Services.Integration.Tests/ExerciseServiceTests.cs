namespace MSmile.Services.Integration.Tests
{
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    /// <inheritdoc />
    public class ExerciseServiceTests : TestBase<ExerciseService>
    {
        /// <inheritdoc />
        public ExerciseServiceTests(DiFixture diFixture)
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
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    await context.DifficultyLevels.AddAsync(level);
                    await context.SaveChangesAsync();

                    var dto = new ExerciseDto
                    {
                        Name = "Name",
                        CustomerDescription = "Customer description",
                        DifficultyLevelId = level.Id,
                        Description = "Description"
                    };

                    var result = await service.Add(dto);
                    var entity = await context.Exercises.FirstOrDefaultAsync(x => x.Id == result.Id);

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
        public async Task UpdateShouldSuccess()
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

                    var exercise = new Exercise
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevels.AddAsync(level);
                    await context.DifficultyLevels.AddAsync(level2);
                    await context.Exercises.AddAsync(exercise);
                    await context.SaveChangesAsync();

                    var dto = new ExerciseDto
                    {
                        Id = exercise.Id,
                        Name = "Name1",
                        Description = "Desc1",
                        DifficultyLevelId = level2.Id
                    };

                    var result = await service.Update(dto);
                    var entity = await context.Exercises.FirstOrDefaultAsync(x => x.Id == exercise.Id);

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
        public async Task DeleteShouldSuccess()
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

                    var exercise = new Exercise
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevels.AddAsync(level);
                    await context.DifficultyLevels.AddAsync(level2);
                    await context.Exercises.AddAsync(exercise);
                    await context.SaveChangesAsync();

                    await service.Delete(exercise.Id);
                    var entity = await context.Exercises.FirstOrDefaultAsync(x => x.Id == exercise.Id);

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
                    var level = new DifficultyLevel
                    {
                        Name = "Name"
                    };

                    var level2 = new DifficultyLevel
                    {
                        Name = "Name new"
                    };

                    var exercise = new Exercise
                    {
                        Name = "Name",
                        DifficultyLevel = level,
                        Description = "Desc"
                    };

                    await context.DifficultyLevels.AddAsync(level);
                    await context.DifficultyLevels.AddAsync(level2);
                    await context.Exercises.AddAsync(exercise);
                    await context.SaveChangesAsync();

                    var result = await service.Get(exercise.Id);

                    result.Should().NotBeNull();
                });
        }
    }
}
