using CustomerContext.Domain.Customers.Services;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Services.Customers
{
    public class PhoneNumberIsValidChecker : IPhoneNumberIsValidChecker
    {
        public bool Isvalid(string phoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string countryCode = "IR";

        
            PhoneNumbers.PhoneNumber phoneNum = phoneUtil.Parse(phoneNumber, countryCode);

            bool isValidNumber = phoneUtil.IsValidNumber(phoneNum);
            bool IsMobile = false ;
            var numberType = phoneUtil.GetNumberType(phoneNum); // Produces Mobile , FIXED_LINE    

            string phoneNumberType = numberType.ToString();

            if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
            {
                IsMobile= true;
            }

            if (isValidNumber && IsMobile)
                return true;

            else return false;



        }
    }
};
