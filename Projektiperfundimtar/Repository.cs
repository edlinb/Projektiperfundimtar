using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Find_me_a_roommate
{
    public class Repository
    {
        private readonly OurContext _context;
        public Repository()
        {
            _context = new OurContext();
        }
        public void AddStudent(Students student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }
        public void AddDormitory(Dormitories dormitory)
        {
            _context.Dormitory.Add(dormitory);
            _context.SaveChanges();
        }
        public void AddAnnouncement( Announcements announcements)
        {
            _context.Announcement.Add(announcements);
            _context.SaveChanges();
        }
        public void AddDormitoryStudent(DormitoryStudent dormitoryStudent)
        {
            _context.DormitoryStudent.Add(dormitoryStudent);
            _context.SaveChanges();
        }
        public void AddApplication(Applications applications)
        {
            _context.Application.Add(applications);
            _context.SaveChanges();
        }
        public List<Students> GetAllStudents()
        {
            _context.Student.Include(s => s.DormitoryStudent).ToList();
            return _context.Student.Include(s => s.Application).ToList();
        }
        public List<Dormitories> GetAllDormitories()
        {
            _context.Dormitory.Include(d => d.DormitoryStudent).ToList();
            return _context.Dormitory.Include(d => d.Announcement).ToList();
        }
        public List<DormitoryStudent> GetAllDormitoryStudents()
        {
            _context.DormitoryStudent.Include(n => n.Student).ToList();
            return _context.DormitoryStudent.Include(n => n.Dormitory).ToList();
        }
        public List<Applications> GetAllApplications()
        {
            //_context.Application.Include(a => a.Students).ToList();
            return _context.Application.Include(a => a.Announcement).ToList();
        }
        public List<Announcements> GetAllAnnouncements()
        {
            _context.Announcement.Include(c => c.Dormitory).ToList();
            return _context.Announcement.Include(c => c.Application).ToList();
        }
        public void UpdateStudent(Students student)
        {
            _context.Student.Update(student);
            _context.SaveChanges();
        }
        public void UpdateDormitories(Dormitories dormitory)
        {
            _context.Dormitory.Update(dormitory);
            _context.SaveChanges();
        }
        public void UpdateDormitoryStudent(DormitoryStudent dormitorystudent)
        {
            _context.DormitoryStudent.Update(dormitorystudent);
            _context.SaveChanges();
        }
        public void UpdateAnnouncement(Announcements anouncement)
        {
            _context.Announcement.Update(anouncement);
            _context.SaveChanges();
        }
        public void UpdateApplication(Applications application)
        {
            _context.Application.Update(application);
            _context.SaveChanges();
        }
        public void DeleteStudent(int studentId)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
        }
        public void DeleteDormitory(int dormitoryId)
        {
            var dormitory = _context.Dormitory.FirstOrDefault(p => p.Id == dormitoryId);
            if (dormitory != null)
            {
                _context.Dormitory.Remove(dormitory);
                _context.SaveChanges();
            }
        }
        public void DeleteDormitoryStudent(int dormitoryStudentId)
        {
            var dormitoryStudent = _context.DormitoryStudent.FirstOrDefault(p => p.Id == dormitoryStudentId);
            if (dormitoryStudent != null)
            {
                _context.DormitoryStudent.Remove(dormitoryStudent);
                _context.SaveChanges();
            }
        }
        public void DeleteAnnouncement(int announcementId)
        {
            var announcement = _context.Announcement.FirstOrDefault(p => p.Id == announcementId);
            if (announcement != null)
            {
                _context.Announcement.Remove(announcement);
                _context.SaveChanges();
            }
        }
        public void DeleteApplication(int applicationId)
        {
            var application = _context.Application.FirstOrDefault(p => p.Id == applicationId);
            if (application != null)
            {
                _context.Application.Remove(application);
                _context.SaveChanges();
            }
        }
        public void RegisterDormitoryToStudent(int dormitoryId, int studentId)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == studentId);
            var dormitory = _context.Dormitory.FirstOrDefault(p => p.Id == dormitoryId);
            if (student != null && dormitory != null)
            {
                var newdormitoryStudent = new DormitoryStudent();
                newdormitoryStudent.DormitoryId = dormitoryId;
                newdormitoryStudent.StudentId = studentId;
                //e njejta gje edhe ketu
                _context.DormitoryStudent.Add(newdormitoryStudent); 
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student or Dormitory not found.");
            }
        }
        public void RegisterStudentsToAnnouncements(int studentId, int anouncementId)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == studentId);
            var announcement = _context.Announcement.FirstOrDefault(d => d.Id == anouncementId);
            if (student != null && announcement != null)
            {
                var newannouncementStudent = new Applications();
                //ose application date mund ta vendosesh duke perdorur librarine system
                newannouncementStudent.ApplicationDate = DateTime.Now;
                newannouncementStudent.AnnouncementId = anouncementId;
                newannouncementStudent.StudentsId = studentId;
                //ke harruar ta besh add ktu 
                _context.Application.Add(newannouncementStudent);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Student or Dormitory not found.");
            }
        }

    }
}
