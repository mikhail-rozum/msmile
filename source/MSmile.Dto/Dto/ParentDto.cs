namespace MSmile.Dto.Dto
{
    /// <summary>
    /// Parent dto.
    /// </summary>
    public class ParentDto : BaseDto
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }
    }
}
