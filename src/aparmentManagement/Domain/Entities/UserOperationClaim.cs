﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class UserOperationClaim : Entity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? OperationClaimId { get; set; }

        public virtual OperationClaim? OperationClaim { get; set; }
        public virtual User? User { get; set; }
    }
}
