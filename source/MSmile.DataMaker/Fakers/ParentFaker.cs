namespace MSmile.DataMaker.Fakers
{
    using Bogus;
    using Bogus.DataSets;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Faker for <see cref="ParentDto"/>.
    /// </summary>
    public sealed class ParentFaker : Faker<ParentDto>
    {
        /// <inheritdoc />
        public ParentFaker()
            : base("ru")
        {
            this.RuleFor(x => x.FirstName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.MiddleName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.LastName, f => f.Name.LastName(Name.Gender.Male))
                .RuleFor(x => x.Comment, (f, x) => f.Internet.Email(x.FirstName, x.LastName));
        }
    }
}
