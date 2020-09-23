using System;
using System.Collections.Generic;

namespace MSmile.Db.Entities
{
    public partial class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public long EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
