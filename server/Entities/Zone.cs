using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class Zone
    {
        public Zone()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
