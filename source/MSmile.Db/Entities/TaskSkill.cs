using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class TaskSkill
    {
        public long TaskId { get; set; }
        public long SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Task Task { get; set; }
    }
}
