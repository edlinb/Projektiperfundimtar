using static System.Net.Mime.MediaTypeNames;
namespace Find_me_a_roommate
{
    public class Announcements
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsActive { get; set; }
        public int DormitoryId { get; set; } // Foreign key to Dormitory
        public Dormitories Dormitory { get; set; } // Navigation property
        public List<Applications> Application { get; set; } // Navigation property
    }
}