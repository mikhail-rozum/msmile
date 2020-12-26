using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Exercise
    {
        public Exercise()
        {
            ExerciseSkills = new HashSet<ExerciseSkill>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long DifficultyLevelId { get; set; }
        public string Description { get; set; }
        public string CustomerDescription { get; set; }

        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<ExerciseSkill> ExerciseSkills { get; set; }
    }
}
