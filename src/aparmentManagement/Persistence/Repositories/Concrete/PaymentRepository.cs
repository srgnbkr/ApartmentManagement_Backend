using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Concrete
{
    public class PaymentRepository : EfRepositoryBase<Payment, BaseDbContext>, IPaymentRepository
    {
        public PaymentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
