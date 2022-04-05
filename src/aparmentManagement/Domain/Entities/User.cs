using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User : Entity
    {
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public int Id { get; set; }
        public int? HomeOwnerTypeId { get; set; }
        public long? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PlateNumber { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool? Status { get; set; }

        public virtual HomeOwnerType? HomeOwnerType { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
