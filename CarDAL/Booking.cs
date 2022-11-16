using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Booking
    {
        public long BookingId { get; set; }
        public long CustomerId { get; set; }
        public long ServiceCenterId { get; set; }
        public long ServiceId { get; set; }
        public bool VendorApproval { get; set; }
        public bool Active { get; set; }
    }
}
