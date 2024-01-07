using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class Applications
    {
        //ktu e kemi sakte kehstuqe thjehst do bejme nje migrim te ri
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public Students Students { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsActive { get; set; }
        public int AnnouncementId { get; set; } // Foreign key to Announcement
        public Announcements Announcement { get; set; } // Navigation property
    }
}