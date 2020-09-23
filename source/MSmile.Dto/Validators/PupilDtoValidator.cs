namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="PupilDto"/>
    /// </summary>
    public class PupilDtoValidator : AbstractValidator<PupilDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public PupilDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.FirstName).NotNull().NotEmpty();
            this.RuleFor(x => x.MiddleName).NotNull().NotEmpty();
            this.RuleFor(x => x.LastName).NotNull().NotEmpty();
            this.RuleFor(x => x.BirthDate).NotNull().NotEmpty();
        }
    }
}
