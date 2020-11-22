namespace MSmile.Services.Integration.Tests
{
    using System;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    using Xunit;

    /// <inheritdoc />
    public class PupilServiceTests : TestBase<PupilService>
    {
        /// <inheritdoc />
        public PupilServiceTests(DiFixture diFixture)
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
                    var dto = new PupilDto
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow.Date,
                        Comment = "Comment"
                    };

                    var result = await service.Add(dto);
                    var entity = await context.Pupil.FirstOrDefaultAsync(x => x.Id == result.Id);

                    result.Should().NotBeNull();
                    entity.Should().NotBeNull();

                    dto.FirstName.Should().Be(entity.FirstName);
                    dto.MiddleName.Should().Be(entity.MiddleName);
                    dto.LastName.Should().Be(entity.LastName);
                    dto.BirthDate.Should().Be(entity.BirthDate);
                    dto.Comment.Should().Be(entity.Comment);
                });
        }

        /// <summary>
        /// Update successful test.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task UpdateShouldSuccess()
        {
            await this.ExecuteTest(
                async (context, service) =>
                {
                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow.Date,
                        Comment = "Comment"
                    };

                    await context.Pupil.AddAsync(pupil);
                    await context.SaveChangesAsync();

                    var dto = new PupilDto
                    {
                        Id = pupil.Id,
                        FirstName = "First name 1",
                        MiddleName = "Middle name 1",
                        LastName = "Last name 1",
                        Comment = "Comment 1",
                        BirthDate = DateTime.UtcNow.AddDays(1).Date
                    };

                    var result = await service.Update(dto);
                    var entity = await context.Pupil.FirstOrDefaultAsync(x => x.Id == pupil.Id);

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

                    dto.Comment.Should().Be(result.Comment);
                    dto.Comment.Should().Be(entity.Comment);

                    dto.BirthDate.Should().Be(result.BirthDate);
                    dto.BirthDate.Should().Be(entity.BirthDate);
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
                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow.Date,
                        Comment = "Comment"
                    };

                    await context.Pupil.AddAsync(pupil);
                    await context.SaveChangesAsync();

                    await service.Delete(pupil.Id);

                    var entity = await context.Pupil.FirstOrDefaultAsync(x => x.Id == pupil.Id);

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
                    var pupil = new Pupil
                    {
                        FirstName = "First name",
                        MiddleName = "Middle name",
                        LastName = "Last name",
                        BirthDate = DateTime.UtcNow.Date,
                        Comment = "Comment"
                    };

                    await context.Pupil.AddAsync(pupil);
                    await context.SaveChangesAsync();

                    var result = await service.Get(pupil.Id);

                    result.Should().NotBeNull();
                });
        }
    }
}
