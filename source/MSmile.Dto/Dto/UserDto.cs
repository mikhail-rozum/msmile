namespace MSmile.Dto.Dto
{
    /// <summary>
    /// User DTO.
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password hash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Employee id.
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public EmployeeDto Employee { get; set; }
    }
}
