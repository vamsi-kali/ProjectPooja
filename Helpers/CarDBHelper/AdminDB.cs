using ProjectPooja.CarDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPooja.Helpers.CarDBHelper
{
    public class AdminDB
    {
        CarServiceContext db;
        public AdminDB(CarServiceContext db)
        {
            this.db = db;
        }

        public bool InsertVendor(Vendor v)
        {
            try
            {
                var vendor = db.Vendors.Add(new Vendor { Address = v.Address, Email = v.Email, Firstname = v.Firstname, Lastname = v.Lastname, PhoneNumber = v.PhoneNumber });
                db.SaveChanges();
                return true;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
