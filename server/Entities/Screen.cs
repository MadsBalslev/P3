using System;
using System.Collections.Generic;

#nullable disable

namespace server.Entities
{
    public partial class Screen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Zone { get; set; }

        public virtual Zone ZoneNavigation { get; set; }
    }
}