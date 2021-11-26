using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class Poster
    {
        public Poster()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? Institution { get; set; }

        public virtual Institution InstitutionNavigation { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
