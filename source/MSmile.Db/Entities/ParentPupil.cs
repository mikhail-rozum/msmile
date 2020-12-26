using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class ParentPupil
    {
        public long ParentId { get; set; }
        public long PupilId { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
