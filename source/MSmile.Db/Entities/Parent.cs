using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Parent
    {
        public Parent()
        {
            ParentContacts = new HashSet<ParentContact>();
            ParentPupils = new HashSet<ParentPupil>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ParentContact> ParentContacts { get; set; }
        public virtual ICollection<ParentPupil> ParentPupils { get; set; }
    }
}
