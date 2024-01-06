using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class Applications
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Students { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsActive { get; set; }
        public int AnnouncementId { get; set; } // Foreign key to Announcement
        public Announcements Announcement { get; set; } // Navigation property
    }
}