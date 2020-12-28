using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class LessonStimulus
    {
        public long LessonId { get; set; }
        public long StimulusId { get; set; }
        public short Count { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Stimulus Stimulus { get; set; }
    }
}
