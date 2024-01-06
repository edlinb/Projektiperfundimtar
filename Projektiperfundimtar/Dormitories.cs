using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class Dormitories
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public List<DormitoryStudent> DormitoryStudent { get; set; } // Navigation property
        public List<Announcements> Announcement { get; set; } // Navigation property
    }
}
