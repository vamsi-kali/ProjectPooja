using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPooja.CarDAL;

namespace ProjectPooja.Helpers.CarDBHelper
{
    public class CustomerDB
    {
        CarServiceContext db;
        public CustomerDB(CarServiceContext db)
        {
            this.db = db;
        }

        public CustomerDB()
        {
        }

        public List<Customer> SearchCustomer(string email = null, string password = null)
        {
            var customers = db.Customers.Where(x =>  x.Email == (email)  && x.Password == (password)).ToList();

            return customers;
        }

        public bool InsertCustomer(Customer cust)
        {
            try
            {
                var customer = db.Customers.Add(new Customer { Email = cust.Email, Firstname = cust.Firstname, Lastname = cust.Lastname, Password = cust.Password, Phone = cust.Phone, CreatedDate = DateTime.Now });
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  bool UpdateCustomer(Customer cust)
        {
            try
            {
                var customer = db.Customers.FirstOrDefault(x=>x.CustomerId == cust.CustomerId || (x.Email == cust.Email));
                //customer = customer == null ? throw new Exception("No Customer found"): cust;
                customer.Email = cust.Email;
                customer.Password = cust.Password;
                customer.Firstname = cust.Firstname;
                customer.Lastname = cust.Lastname;
                customer.Phone = cust.Phone;

                db.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool BookService(long cust, List<Service> services)
        {
            try
            {
                foreach (var i in services)
                {
                    var temp_book = db.Bookings.Add(new Booking { Active = true, VendorApproval = false, CustomerId = cust, ServiceCenterId = i.ServiceCenterId, ServiceId = i.ServiceId });
                    db.SaveChanges();

                }
                return true;
            }

            catch (Exception e)
            {
                throw e;
            }


        }


    }
}
