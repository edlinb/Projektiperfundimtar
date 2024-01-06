using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class OurContext : DbContext
    {
        public DbSet<Students> Student { get; set; }
        public DbSet<Dormitories> Dormitory { get; set; }
        public DbSet<Announcements> Announcement { get; set; }
        public DbSet<DormitoryStudent> DormitoryStudent { get; set; }
        public DbSet<Applications> Application { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=DESKTOP-3FTPBLJ;Database=PracticalProject;Trusted_Connection=True;");
    }
}