using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPooja.CarDAL
{
    public partial class Admin
    {
        public long AdminId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
