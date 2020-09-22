namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="DifficultyLevelDto"/>.
    /// </summary>
    public class DifficultyLevelDtoValidator : AbstractValidator<DifficultyLevelDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public DifficultyLevelDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
