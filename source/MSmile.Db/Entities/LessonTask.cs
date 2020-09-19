using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class LessonTask
    {
        public long LessonId { get; set; }
        public long TaskId { get; set; }
        public short CompletionRate { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Task Task { get; set; }
    }
}
