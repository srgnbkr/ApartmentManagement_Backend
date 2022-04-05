using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {


        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<BillType> BillTypes { get; set; } 
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<CreditCardDetail> CreditCardDetails { get; set; }
        public virtual DbSet<Home> Homes { get; set; } 
        public virtual DbSet<HomeOwnerType> HomeOwnerTypes { get; set; }
        public virtual DbSet<HomeType> HomeTypes { get; set; } 
        public virtual DbSet<OperationClaim> OperationClaims { get; set; } 
        public virtual DbSet<Payment> Payments { get; set; } 
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    }
}
