namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="ExerciseDto"/>
    /// </summary>
    public class TaskValidator : AbstractValidator<ExerciseDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public TaskValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.Name).NotNull().NotEmpty();
            this.RuleFor(x => x.DifficultyLevelId).NotNull().NotEmpty();
        }
    }
}
