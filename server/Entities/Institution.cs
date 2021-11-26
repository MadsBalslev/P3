using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class Institution
    {
        public Institution()
        {
            Posters = new HashSet<Poster>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Admin { get; set; }

        public virtual User AdminNavigation { get; set; }
        public virtual ICollection<Poster> Posters { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}