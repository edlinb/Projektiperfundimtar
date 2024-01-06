using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace Find_me_a_roommate
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<DormitoryStudent> DormitoryStudent { get; set; } // Navigation property
        public List<Applications> Application { get; set; } // Navigation property
    }
}
