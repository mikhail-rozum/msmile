using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Pupil
    {
        public Pupil()
        {
            CheckLists = new HashSet<CheckList>();
            ParentPupils = new HashSet<ParentPupil>();
            Stimuli = new HashSet<Stimulus>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<ParentPupil> ParentPupils { get; set; }
        public virtual ICollection<Stimulus> Stimuli { get; set; }
    }
}
