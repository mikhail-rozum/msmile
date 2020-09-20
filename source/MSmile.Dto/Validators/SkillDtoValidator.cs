namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="SkillDto"/>
    /// </summary>
    public class SkillDtoValidator : AbstractValidator<SkillDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public SkillDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
            this.RuleFor(x => x.Description).MaximumLength(1000);
        }
    }
}
