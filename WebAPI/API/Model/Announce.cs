using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Announce
    {
        public int AnnounceId { get; set; }
        public DateTime? AddDate { get; set; }
        public string AnnounceContent { get; set; }
        public int? SchoolId { get; set; }
        public string Piority { get; set; }
        public string KindOf { get; set; }
        public string AnnouncingBy { get; set; }
    }
}
