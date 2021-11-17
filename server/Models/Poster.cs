using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Poster
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                _name = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Imageurl cannot be empty!");
                }
                _imageUrl = value;
            }
        }
        public int? CreatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
    }
}

// Depricated version of sanitycheck
//
// public string SanityCheck(Poster p)
// {
//     if (p.Name == null || p.Name == "")
//     {
//         return "Name cannot be empty";
//     }

//     if (string.IsNullOrEmpty(p.ImageUrl) || string.IsNullOrWhiteSpace(p.ImageUrl))
//     {
//         return "Image url cannot be empty";
//     }
//     if (p.StartDate == null)
//     {
//         return "Start date cannot be empty";
//     }
//     if (p.EndDate == null)
//     {
//         return "End date cannot be empty";
//     }

//     return "";
// }