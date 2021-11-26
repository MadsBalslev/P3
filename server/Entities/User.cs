using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? Institution { get; set; }
        public int Role { get; set; }

        public virtual Institution InstitutionNavigation { get; set; }
    }
}
