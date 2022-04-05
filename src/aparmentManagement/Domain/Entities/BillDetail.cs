using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class BillDetail : Entity
    {
        public BillDetail()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? HomeId { get; set; }
        public int? BillTypeId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public virtual BillType? BillType { get; set; }
        public virtual Home? Home { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
