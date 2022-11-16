using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Vendor
    {
        public long VendorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
