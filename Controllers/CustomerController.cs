using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPooja.CarDAL;
using ProjectPooja.Helpers.CarDBHelper;
namespace ProjectPooja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CarServiceContext db;
        CustomerDB custlib;
        public CustomerController(CarServiceContext db)
        {
            this.db = db;
            this.custlib = new CustomerDB(this.db);
        }
        [HttpGet]
        [Route("searchcustomers")]
        public List<Customer> Customerlogin(Customer customer)
        {
            var customers = custlib.SearchCustomer(customer.Email, customer.Password); //db.Customers.Where(x => x.Email == (customer.Email) && x.Password == (customer.Password)).ToList();
            if (customers == null)
                throw new Exception("Customer creds are not found, Please Sign up");
            return customers;
        }

        [HttpPost]
        [Route("customersignup")]
        public bool CustomerSignup(Customer customer)
        {
            return custlib.InsertCustomer(customer);
        }

        [HttpPut]
        [Route("custinfoupdate")]
        public bool UpdateCustInfo(Customer customer)
        {
            return custlib.UpdateCustomer(customer);
        }

        [HttpPost]
        [Route("book/{cust}")]
        public bool Bookservice(long cust, List<Service> service)
        {
            return custlib.BookService(cust, service);
        }

    }
}
