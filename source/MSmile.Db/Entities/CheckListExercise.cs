using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class CheckListExercise
    {
        public long CheckListId { get; set; }
        public long ExerciseId { get; set; }
        public bool Enabled { get; set; }

        public virtual CheckList CheckList { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
