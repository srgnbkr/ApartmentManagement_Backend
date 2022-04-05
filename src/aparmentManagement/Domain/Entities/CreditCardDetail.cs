using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class CreditCardDetail : Entity
    {
        public CreditCardDetail()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? Cvv { get; set; }
        public string? ExpiryDate { get; set; }
        public decimal? Amount { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
