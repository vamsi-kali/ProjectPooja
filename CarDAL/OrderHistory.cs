using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class OrderHistory
    {
        public long OrderHistoryId { get; set; }
        public DateTime OrderDate { get; set; }
        public long? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
