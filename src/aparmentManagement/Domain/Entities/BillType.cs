using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class BillType : Entity
    {
        public BillType()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
