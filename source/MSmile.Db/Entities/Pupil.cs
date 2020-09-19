using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Pupil
    {
        public Pupil()
        {
            Lesson = new HashSet<Lesson>();
        }

        public long Id { get; set; }
        public long ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Comment { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
