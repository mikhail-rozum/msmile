using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Task
    {
        public Task()
        {
            LessonTask = new HashSet<LessonTask>();
            TaskSkill = new HashSet<TaskSkill>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long DifficultyLevelId { get; set; }
        public string Description { get; set; }
        public string CustomerDescription { get; set; }

        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<LessonTask> LessonTask { get; set; }
        public virtual ICollection<TaskSkill> TaskSkill { get; set; }
    }
}
