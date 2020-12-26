using System;
using System.Collections.Generic;

#nullable disable

namespace MSmile.Db.Entities
{
    public partial class ParentContact
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Tel { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
