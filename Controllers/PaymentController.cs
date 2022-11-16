using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPooja.CarDAL;
using ProjectPooja.Helpers.CarDBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPooja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        CarServiceContext db;
        PaymentDB paylib;
        public PaymentController(CarServiceContext db)
        {
            this.db = db;
            this.paylib = new PaymentDB(this.db);
        }

        [HttpPost]
        [Route("QueuePayments")]
        public bool QueuePayments()
        {
            return paylib.QueuePayments();
        }
        [HttpPost]
        [Route("Makepayment/{custid}/{paymenttype}")]
        public bool MakePayment(string custid, string paymenttype)
        {
            return paylib.Makepayment(Convert.ToInt64(custid), paymenttype);
        }

    }
}
