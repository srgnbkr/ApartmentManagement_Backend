using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Block : Entity
    {
        public Block()
        {
            Homes = new HashSet<Home>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
