using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    using MSmile.Db.Infrastructure;

    public partial class Stimulus
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PupilId { get; set; }

        public virtual Pupil Pupil { get; set; }
    }
}
