using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class Lesson
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? FactDate { get; set; }
        public string Comment { get; set; }
        public long CheckListId { get; set; }
        public bool Paid { get; set; }

        public virtual CheckList CheckList { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
