

using CustomerContext.ReadModel.Queries.Contracts.Customers;
using CustomerContext.ReadModel.Queries.Contracts.Customers.DataContracts;
using Framework.Core.Mapper;
using Framework.Facade;
using Framework.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerContext.ReadModel.Queries.Facade.Customers
{
    [Route("api/Customer/[action]")]
    [ApiController]
    public class CustomerQueryFacade : FacadeQueryBase, ICustomerQueryFacade
    {
        
        private readonly Context.Models.CustomerContext dbContext;
        private readonly IMapper mapper;

        public CustomerQueryFacade(Context.Models.CustomerContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public CustomerDto GetCustomerById(long id)
        {
            var customer = dbContext.Customers.AsNoTracking().Where(x => x.Id == id).SingleOrDefault();
               

            return mapper.Map < CustomerDto, Context.Models.Customer>(customer);
           
        }
        [HttpGet]
        public IList<CustomerDto> GetCustomers()
        {
            var customers = dbContext.Customers.AsNoTracking().ToList();
            return mapper.Map<CustomerDto, Context.Models.Customer>(customers);
        }
    }
}
