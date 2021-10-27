using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Institution
    {
        public Institution()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Admin { get; set; }

        public virtual User AdminNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}