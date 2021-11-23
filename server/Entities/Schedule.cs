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
        // Er også udkommenteret i Models/Schedule
        // public DateTime StartDate { get; set; }
        // public DateTime EndDate { get; set; }
        public int Daily { get; set; }
        public string Weekday { get; set; }

        public virtual Poster Poster { get; set; }
    }
}
