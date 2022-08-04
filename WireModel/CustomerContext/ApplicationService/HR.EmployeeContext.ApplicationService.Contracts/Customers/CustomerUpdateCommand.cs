using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ApplicationService.Contracts.Customers
{
   public class CustomerUpdateCommand : Command
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
