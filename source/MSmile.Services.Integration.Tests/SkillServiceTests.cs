namespace MSmile.Services.Integration.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

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

                    var entity = await context.Skill
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    Assert.NotNull(entity);
                    Assert.Equal(dto.Name, entity.Name);
                    Assert.Equal(dto.Description, entity.Description);
                });
        }
    }
}
