using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Institution { get; set; }
        public int Role { get; set; }
    }
}
