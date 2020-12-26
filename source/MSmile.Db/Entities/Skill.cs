using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            ExerciseSkills = new HashSet<ExerciseSkill>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExerciseSkill> ExerciseSkills { get; set; }
    }
}
