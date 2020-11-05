namespace MSmile.Services.Integration.Tests
{
    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    using Task = System.Threading.Tasks.Task;

    /// <inheritdoc />
    public class DifficultyLevelServiceTests : TestBase<DifficultyLevelService>
    {
        /// <inheritdoc />
        public DifficultyLevelServiceTests(DiFixture diFixture)
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
                    var dto = new DifficultyLevelDto
                    {
                        Name = "Test level"
                    };

                    var result = await service.Add(dto);

                    var entity = await context.DifficultyLevel
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    entity.Should().NotBeNull();

                    dto.Name.Should().Be(entity.Name);
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
                    var level = new DifficultyLevel
                    {
                        Name = "Test level"
                    };

                    await context.DifficultyLevel.AddAsync(level);
                    await context.SaveChangesAsync();

                    var dto = new DifficultyLevelDto
                    {
                        Id = level.Id,
                        Name = "New name"
                    };

                    var result = await service.Update(dto);

                    var entity = await context.DifficultyLevel.FirstOrDefaultAsync(x => x.Id == level.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.Id.Should().Be(result.Id);
                    dto.Id.Should().Be(entity.Id);

                    dto.Name.Should().Be(result.Name);
                    dto.Name.Should().Be(entity.Name);
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
                    var level = new DifficultyLevel
                    {
                        Name = "Test name"
                    };

                    await context.AddAsync(level);
                    await context.SaveChangesAsync();

                    await service.Delete(level.Id);

                    var entity = await context
                        .DifficultyLevel
                        .FirstOrDefaultAsync(x => x.Id == level.Id);
                    entity.Should().BeNull();
                });
        }

        /// <summary>
        /// Get success
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetShouldReturn()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var level = new DifficultyLevel
                    {
                        Name = "Test name"
                    };

                    await context.AddAsync(level);
                    await context.SaveChangesAsync();

                    var result = await service.Get(level.Id);
                    result.Should().NotBeNull();
                });
        }
    }
}
