using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Service
    {
        public long ServiceId { get; set; }
        public long ServiceCenterId { get; set; }
        public string Servicename { get; set; }
        public bool Active { get; set; }
    }
}
