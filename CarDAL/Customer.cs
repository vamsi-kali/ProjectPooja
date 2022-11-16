using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public long CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
