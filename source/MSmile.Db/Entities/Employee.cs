using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Lessons = new HashSet<Lesson>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsFired { get; set; }
        public string Comment { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
