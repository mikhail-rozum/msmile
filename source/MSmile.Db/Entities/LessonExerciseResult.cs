using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class LessonExerciseResult
    {
        public long LessonId { get; set; }
        public long ExerciseId { get; set; }
        public short Percentage { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
