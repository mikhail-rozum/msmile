namespace MSmile.Services.Integration.Tests
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    using Task = System.Threading.Tasks.Task;

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

                    var entity = await context.Skill
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    Assert.NotNull(entity);
                    Assert.Equal(dto.Name, entity.Name);
                    Assert.Equal(dto.Description, entity.Description);
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
                    var skill = new Skill
                    {
                        Name = "Test",
                        Description = "Test description"
                    };

                    await context.Skill.AddAsync(skill);
                    await context.SaveChangesAsync();

                    var dto = new SkillDto
                    {
                        Id = skill.Id,
                        Name = "New name",
                        Description = "New description"
                    };

                    var result = await service.Update(dto);

                    var entity = await context.Skill.FirstOrDefaultAsync(x => x.Id == skill.Id);

                    Assert.NotNull(result);
                    Assert.NotNull(entity);

                    Assert.Equal(dto.Id, result.Id);
                    Assert.Equal(dto.Id, entity.Id);

                    Assert.Equal(dto.Name, result.Name);
                    Assert.Equal(dto.Name, entity.Name);

                    Assert.Equal(dto.Description, result.Description);
                    Assert.Equal(dto.Description, entity.Description);
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

                    await context.Skill.AddAsync(skill);
                    await context.SaveChangesAsync();

                    await service.Delete(skill.Id);

                    var entity = await context.Skill.FirstOrDefaultAsync(x => x.Id == skill.Id);
                    Assert.Null(entity);
                });
        }
    }
}
