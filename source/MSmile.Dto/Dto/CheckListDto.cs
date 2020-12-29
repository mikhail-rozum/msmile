namespace MSmile.Dto.Dto
{
    using System;

    /// <summary>
    /// Check list dto.
    /// </summary>
    public class CheckListDto : BaseDto
    {
        /// <summary>
        /// Employee id.
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Pupil id.
        /// </summary>
        public long PupilId { get; set; }

        /// <summary>
        /// Pupil.
        /// </summary>
        public PupilDto Pupil { get; set; }

        /// <summary>
        /// Created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Modified.
        /// </summary>
        public DateTime Modified { get; set; }
    }
}
