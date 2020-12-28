using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class CheckList
    {
        public CheckList()
        {
            CheckListExercises = new HashSet<CheckListExercise>();
            Lessons = new HashSet<Lesson>();
        }

        public long Id { get; set; }
        public long PupilId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual Pupil Pupil { get; set; }
        public virtual ICollection<CheckListExercise> CheckListExercises { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
