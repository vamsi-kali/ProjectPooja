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
    public class VendorController : ControllerBase
    {
        CarServiceContext db;
        VendorDB Venlib;
        public VendorController(CarServiceContext db)
        {
            this.db = db;
            this.Venlib = new VendorDB(this.db);
        }

        [HttpGet]
        [Route("fetchservicecenters")]
        public List<ServiceCenter> FetchServiceCenters()
        {
            return Venlib.GetAllCenters();
        }

        [HttpPost]
        [Route("approvebookings")]
        public bool ApproveBookings()
        {
            return Venlib.ServiceApproval();
        }

        [HttpPost]
        [Route("AddServiceCenter")]
        public bool AddServiceCenter(ServiceCenter sc)
        {
            return Venlib.InsertServiceCenter(sc);
        }

        [HttpPost]
        [Route("AddServices")]
        public bool AddService(Service s, long vendorid = 0)
        {
            return Venlib.InsertServicestoServiceCenter(s);

        }

    }
}
