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
    public class SkillServiceTests : TestBase<SkillService>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="diFixture">DI fixture.</param>
        public SkillServiceTests(DiFixture diFixture)
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
                    var dto = new SkillDto
                    {
                        Name = "Name",
                        Description = "Description"
                    };

                    var result = await service.Add(dto);

                    var entity = await context.Skills
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    entity.Should().NotBeNull();

                    dto.Name.Should().Be(entity.Name);
                    dto.Description.Should().Be(entity.Description);
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
                    var skill = new Skill
                    {
                        Name = "Test",
                        Description = "Test description"
                    };

                    await context.Skills.AddAsync(skill);
                    await context.SaveChangesAsync();

                    var dto = new SkillDto
                    {
                        Id = skill.Id,
                        Name = "New name",
                        Description = "New description"
                    };

                    var result = await service.Update(dto);

                    var entity = await context.Skills.FirstOrDefaultAsync(x => x.Id == skill.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.Id.Should().Be(result.Id);
                    dto.Id.Should().Be(entity.Id);

                    dto.Name.Should().Be(result.Name);
                    dto.Name.Should().Be(entity.Name);

                    dto.Description.Should().Be(result.Description);
                    dto.Description.Should().Be(entity.Description);
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
                    var skill = new Skill
                    {
                        Name = "Name",
                        Description = "Description"
                    };

                    await context.Skills.AddAsync(skill);
                    await context.SaveChangesAsync();

                    await service.Delete(skill.Id);

                    var entity = await context.Skills.FirstOrDefaultAsync(x => x.Id == skill.Id);
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
                    var skill = new Skill
                    {
                        Name = "Test name",
                        Description = "Test description"
                    };

                    await context.Skills.AddAsync(skill);
                    await context.SaveChangesAsync();

                    var result = await service.Get(skill.Id);
                    result.Should().NotBeNull();
                });
        }
    }
}
