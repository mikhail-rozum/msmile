namespace MSmile.Services.Integration.Tests
{
    using System;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    /// <summary>
    /// Stimulus service tests.
    /// </summary>
    public class StimulusServiceTests : TestBase<StimulusService>
    {
        /// <inheritdoc />
        public StimulusServiceTests(DiFixture diFixture)
            : base(diFixture)
        {
        }

        /// <summary>
        /// Add successful test.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AddShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.Now,
                        Comment = "Comment"
                    };

                    await context.Pupils.AddAsync(pupil);
                    await context.SaveChangesAsync();

                    var dto = new StimulusDto
                    {
                        Name = "Stimulus_1",
                        Pupil = new ListItemDto
                        {
                            Id = pupil.Id
                        }
                    };

                    var result = await service.Add(dto);

                    var entity = await context.Stimuli
                        .AsNoTracking()
                        .Include(x => x.Pupil)
                        .FirstOrDefaultAsync(x => x.Id == result.Id);

                    entity.Should().NotBeNull();

                    result.Name.Should().Be(entity.Name);
                    result.Pupil.Should().NotBeNull();
                    result.Pupil.Id.Should().Be(entity.Pupil.Id);
                    result.Pupil.Name.Should().Be($"{entity.Pupil.LastName} {entity.Pupil.FirstName} {entity.Pupil.MiddleName}");
            });
        }
    }
}
