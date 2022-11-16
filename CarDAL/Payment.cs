using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public string PaymentType { get; set; }
        public long? OrderHistoryId { get; set; }
        public bool? Paid { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
