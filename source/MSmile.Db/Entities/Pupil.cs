using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Pupil
    {
        public Pupil()
        {
            Lessons = new HashSet<Lesson>();
            ParentPupils = new HashSet<ParentPupil>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<ParentPupil> ParentPupils { get; set; }
    }
}
