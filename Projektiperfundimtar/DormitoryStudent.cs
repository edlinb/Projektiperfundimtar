using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class DormitoryStudent
    {
        public int Id { get; set; }
        public int DormitoryId { get; set; }
        public Dormitories Dormitory { get; set; }
        public int StudentId { get; set; } // Foreign key to Student
        public Students Student { get; set; } // Navigation property
        public int Capacity { get; set; }
    }
}





