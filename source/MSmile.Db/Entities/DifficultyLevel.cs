using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class DifficultyLevel
    {
        public DifficultyLevel()
        {
            Exercises = new HashSet<Exercise>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
