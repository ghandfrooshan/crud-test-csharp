using CustomerContext.ReadModel.Queries.Contracts.Customers;
using CustomerContext.ReadModel.Queries.Facade.Customers;
using Framework.Core.Mapper;
using Framework.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerContext.ReadModel.Configuration
{
    public class Registrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ICustomerQueryFacade, CustomerQueryFacade>();
            
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
