namespace MSmile.DataMaker.Fakers
{
    using System;

    using Bogus;
    using Bogus.DataSets;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Fake generator for <see cref="EmployeeDto"/>
    /// </summary>
    public sealed class EmployeeFaker : Faker<EmployeeDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public EmployeeFaker()
            : base("ru")
        {
            this.RuleFor(x => x.FirstName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.MiddleName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.LastName, f => f.Name.LastName(Name.Gender.Male))
                .RuleFor(x => x.BirthDate, f => f.Date.Between(new DateTime(1980, 1, 1), new DateTime(2000, 1, 1)))
                .RuleFor(x => x.Comment, (f, x) => f.Internet.Email(x.FirstName, x.LastName));
        }
    }
}
