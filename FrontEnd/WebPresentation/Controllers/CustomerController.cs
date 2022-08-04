using Customer.WebPresentation.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPresentation.Models;

namespace WebPresentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IClient client;

        public CustomerController(IClient client)
        {
            this.client = client;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await client.GetCustomersAsync();
            return View(customers);
          
        }

        public async Task<IActionResult> Create()
        {
            return PartialView("_Create");

        }
        [HttpPost]

        public async Task Create(CustomerDto customer)
        {

            var command = new CustomerCreateCommand()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber
               
            };
         
            await client.CreateCustomerAsync(command);
     
        }

        public async Task<IActionResult> Update(int customerId)
        {

            var customer = await client.GetCustomerByIdAsync(customerId);
            return PartialView("_Update", customer);



        }
        [HttpPost]
        public async Task Update(CustomerUpdateCommand command)
        {

            await client.UpdateCustomerAsync(command);


        }
        [HttpPost]
        public async Task Delete(CustomerDeleteCommand command)
        {

            await client.DeleteCustomerAsync(command);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
