using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Abstract;
using Persistence.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Registrations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApartmentDbConnectionString"));
            });

            services.AddScoped<IBillDetailRepository, BillDetailRepository>();
            services.AddScoped<IBillTypeRepository, BillTypeRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<ICreditCardDetailRepository, CreditCardDetailRepository>();
            services.AddScoped<IHomeOwnerTypeRepository, HomeOwnerTypeRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IHomeTypeRepository, HomeTypeRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

            return services;

        }

        
    }
}
