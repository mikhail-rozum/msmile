namespace MSmile.Dto.Validators
{
    using FluentValidation;

    using MSmile.Dto.Dto;

    /// <summary>
    /// Validator for <see cref="EmployeeDto"/>
    /// </summary>
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public EmployeeDtoValidator()
        {
            this.RuleFor(x => x.Id).NotNull();
            this.RuleFor(x => x.FirstName).NotNull().NotEmpty();
            this.RuleFor(x => x.MiddleName).NotNull().NotEmpty();
            this.RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
