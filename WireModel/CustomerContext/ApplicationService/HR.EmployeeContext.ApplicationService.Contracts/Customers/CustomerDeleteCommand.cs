using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ApplicationService.Contracts.Customers
{
   public class CustomerDeleteCommand : Command
    {
        public long Id { get; set; }
        
    }
}
