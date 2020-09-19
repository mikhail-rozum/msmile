using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class DifficultyLevel
    {
        public DifficultyLevel()
        {
            Task = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
