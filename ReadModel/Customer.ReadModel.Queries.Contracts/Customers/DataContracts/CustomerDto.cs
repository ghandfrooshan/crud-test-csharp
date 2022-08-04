using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ReadModel.Queries.Contracts.Customers.DataContracts
{
  public   class CustomerDto
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
