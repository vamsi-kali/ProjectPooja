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
    public class AdminController : ControllerBase
    {
        CarServiceContext db;
        AdminDB adlib;
        public AdminController(CarServiceContext db)
        {
            this.db = db;
            this.adlib = new AdminDB(this.db);
        }
        [HttpPost]
        [Route("InsertVendor")]
        public bool InsertVendor(Vendor ven)
        {
            return adlib.InsertVendor(ven);
        }
    }
}
