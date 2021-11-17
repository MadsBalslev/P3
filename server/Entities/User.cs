using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class User
    {
        public User()
        {
            Institutions = new HashSet<Institution>();
            Posters = new HashSet<Poster>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int? Institution { get; set; }
        public int Role { get; set; }

        public virtual Institution InstitutionNavigation { get; set; }
        public virtual ICollection<Institution> Institutions { get; set; }
        public virtual ICollection<Poster> Posters { get; set; }
    }
}
