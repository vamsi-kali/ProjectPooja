using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class ServiceCenter
    {
        public long ServiceCenterId { get; set; }
        public string ServiceCenterName { get; set; }
        public string Address { get; set; }
        public bool Centerpickup { get; set; }
        public long? VendorId { get; set; }
    }
}
