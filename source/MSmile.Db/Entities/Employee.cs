using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Lesson = new HashSet<Lesson>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsFired { get; set; }
        public string Comment { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
