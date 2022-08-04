using CustomerContext.ApplicationService.Contracts.Customers;
using CustomerContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using Framework.Facade;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Facade
{
    [Route("api/Customer/[action]")]
    [ApiController]
    public class CustomerCommandFacade : FacadeCommandBase, ICustomerCommandFacade
    {
        private readonly IDiContainer diContainer;
       


        public CustomerCommandFacade(ICommandBus commandBus, IDiContainer diContainer ): base(commandBus)
        {
            this.diContainer = diContainer;
            
        }

        [HttpPost]
        public void CreateCustomer(CustomerCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [HttpPost]
        public void DeleteCustomer(CustomerDeleteCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [HttpPost]
        public void UpdateCustomer(CustomerUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
