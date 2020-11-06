namespace MSmile.Dto.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Lesson dto.
    /// </summary>
    public class LessonDto : BaseDto
    {
        /// <summary>
        /// Pupil id.
        /// </summary>
        public long PupilId { get; set; }

        /// <summary>
        /// Pupil.
        /// </summary>
        public PupilDto Pupil { get; set; }

        /// <summary>
        /// Employee id.
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Fact date.
        /// </summary>
        public DateTime? FactDate { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Tasks.
        /// </summary>
        public List<DictionaryDto> Tasks { get; set; }
    }
}
