using ProjectPooja.CarDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPooja.Helpers.CarDBHelper
{
    public class PaymentDB
    {
        CarServiceContext db;
        public PaymentDB(CarServiceContext db)
        {
            this.db = db;
        }

        public bool QueuePayments()
        {
            try
            {
                var bookings = db.Bookings.Where(x => x.Active && x.VendorApproval).ToList();
                foreach (var i in bookings)
                {
                    var temp_payments = db.Payments.Add(new Payment { CreatedDate = DateTime.Now, OrderHistoryId = i.BookingId, Paid = false, PaymentType = null });
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Makepayment(long custid, string paymenttype)
        {
            var activebookings = db.Bookings.Where(x => x.CustomerId == custid && x.Active && x.VendorApproval).ToList();
            foreach(var i in activebookings)
            {
                var temp_bookings = db.Payments.FirstOrDefault(x => x.OrderHistoryId == i.BookingId);
                temp_bookings.Paid = true;
                temp_bookings.PaymentType = paymenttype;
                temp_bookings.CreatedDate = DateTime.Now;
                temp_bookings.OrderHistoryId = i.BookingId;

                var temp_data = db.Bookings.FirstOrDefault(x => x.BookingId == i.BookingId);
                temp_data.Active = false;
                db.SaveChanges();
            }
            return true;
        }

    }
}
