namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="ParentDto"/>
    /// </summary>
    public class ParentDtoValidator : AbstractValidator<ParentDto>
    {
        /// <inheritdoc />
        public ParentDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.FirstName).NotNull().NotEmpty();
            this.RuleFor(x => x.MiddleName).NotNull().NotEmpty();
            this.RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
