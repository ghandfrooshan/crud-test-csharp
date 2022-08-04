using CustomerContext.Domain.Customers.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CustomerContext.Domain.Services.Customers
{
    public class EmailIsValidChecker : IEmailIsValidChecker
    {
        public bool IsValid(string email)
        {
            var trimmedEmail = email.Trim();


            try
            {
                var emailAddress = new MailAddress(trimmedEmail);
                return true;
            }
            catch
            {
                return false;
            }


           
        }
    }
}
