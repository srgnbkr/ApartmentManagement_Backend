using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Payment : Entity
    {
        public int Id { get; set; }
        public int? BillDetailId { get; set; }
        public int? CreditCardDetailId { get; set; }

        public virtual BillDetail? BillDetail { get; set; }
        public virtual CreditCardDetail? CreditCardDetail { get; set; }
    }
}
