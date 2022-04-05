using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class OperationClaim : Entity
    {
        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
