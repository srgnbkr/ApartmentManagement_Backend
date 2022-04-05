using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Home : Entity
    {
        public Home()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public int? BlockId { get; set; }
        public int? HomeTypeId { get; set; }
        public int? UserId { get; set; }
        public int? FloorNumber { get; set; }
        public int? DoorNumber { get; set; }
        public bool? Status { get; set; }

        public virtual Block? Block { get; set; }
        public virtual HomeType? HomeType { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
