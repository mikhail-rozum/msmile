namespace MSmile.Dto.Dto
{
    using System;

    /// <summary>
    /// Employee dto.
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birth date.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Fired.
        /// </summary>
        public bool IsFired { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Photo.
        /// </summary>
        public byte[] Photo { get; set; }
    }
}
