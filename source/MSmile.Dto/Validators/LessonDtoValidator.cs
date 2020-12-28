namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="LessonDto"/>
    /// </summary>
    public class LessonDtoValidator : AbstractValidator<LessonDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public LessonDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.EmployeeId).NotNull().NotEmpty();
            this.RuleFor(x => x.Date).NotNull().NotEmpty();
        }
    }
}
