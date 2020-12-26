using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class ExerciseSkill
    {
        public long TaskId { get; set; }
        public long SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Exercise Task { get; set; }
    }
}
