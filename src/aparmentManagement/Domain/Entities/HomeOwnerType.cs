using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class HomeOwnerType : Entity
    {
        public HomeOwnerType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
