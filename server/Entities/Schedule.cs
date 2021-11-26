using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int? PosterId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Zone { get; set; }

        public virtual Poster Poster { get; set; }
        public virtual Zone ZoneNavigation { get; set; }
    }
}
