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
    public class BlockRepository : EfRepositoryBase<Block, BaseDbContext>, IBlockRepository
    {
        public BlockRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
