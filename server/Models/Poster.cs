using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Poster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public string Institution { get; set; }
    }
}
