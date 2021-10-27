using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Screens = new HashSet<Screen>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Screen> Screens { get; set; }
    }
}