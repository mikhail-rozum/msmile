using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            TaskSkill = new HashSet<TaskSkill>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaskSkill> TaskSkill { get; set; }
    }
}
