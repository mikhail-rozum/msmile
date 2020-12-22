namespace MSmile.Dto.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Pupil dto.
    /// </summary>
    public class PupilDto : BaseDto
    {
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
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Parents.
        /// </summary>
        public List<ListItemDto> Parents { get; set; }
    }
}
