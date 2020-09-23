using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Parent
    {
        public Parent()
        {
            ParentContact = new HashSet<ParentContact>();
            ParentPupil = new HashSet<ParentPupil>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ParentContact> ParentContact { get; set; }
        public virtual ICollection<ParentPupil> ParentPupil { get; set; }
    }
}
