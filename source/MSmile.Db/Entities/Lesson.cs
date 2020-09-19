using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonTask = new HashSet<LessonTask>();
        }

        public long Id { get; set; }
        public long PupilId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? FactDate { get; set; }
        public string Comment { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Pupil Pupil { get; set; }
        public virtual ICollection<LessonTask> LessonTask { get; set; }
    }
}
