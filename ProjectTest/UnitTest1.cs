using NUnit.Framework;
using NUnit.Framework.Internal;
using Find_me_a_roommate;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectTest
{
    public class UnitTest1
    {
        [Test]

        public void AddStudent()
        {
            //Arrange

            var repo = new Repository();
            var initialCount = repo.GetAllStudents().Count;

            //Act

            repo.AddStudent(new Students { Name = "Test Student", Surname= " Test Student" });

            //Assert

            var students = repo.GetAllStudents();
            Assert.AreEqual(initialCount + 1, students.Count);
            CollectionAssert.Contains(students.Select(s => s.Name).ToList(), "Test Student");


        }
        [Test]
        public void AddDormitories_ShouldAddDormitoriesToDatabase()
        {

            //Arrange

            var repo = new Repository();
            var initialCount = repo.GetAllDormitories().Count;

            //Act

            repo.AddDormitory(new Dormitories { Name = "Test Dormitories" ,Code = "edlin "});
            //Assert

            var dormitories = repo.GetAllDormitories();
            Assert.AreEqual(initialCount + 1, dormitories.Count);
            CollectionAssert.Contains(dormitories.Select(s => s.Name).ToList(), "Test Dormitories" );
        }
        [Test]
        public void AddAnnouncements_ShouldAddAnnouncementsToDatabase()
        {

            //Arrange

            var repo = new Repository();
            var initialCount = repo.GetAllAnnouncements().Count;

            //Act

            repo.AddAnnouncement(new Announcements {  DormitoryId = 1, Description="Test" , Title = "Test"});
            //Assert

            var dormitories = repo.GetAllAnnouncements();
            Assert.AreEqual(initialCount + 1, dormitories.Count);
            CollectionAssert.Contains(dormitories.Select(s => s.DormitoryId).ToList(), 1 );
        }
        [Test]
        public void AddDormitoryStudent_ShouldAddDormitoryStudentToDatabase()
        {

            //Arrange

            var repo = new Repository();
            var initialCount = repo.GetAllDormitoryStudents().Count;

            //Act

            repo.AddDormitoryStudent(new DormitoryStudent { Capacity = 10,DormitoryId= 1,StudentId= 2 });
            //Assert

            var dormitorystudents = repo.GetAllDormitoryStudents();
            Assert.AreEqual(initialCount + 1, dormitorystudents.Count);
            CollectionAssert.Contains(dormitorystudents.Select(s => s.Capacity).ToList(), 10 );
        }
        [Test]
        public void ShouldAddApplication()
        {

            //Arrange

            var repo = new Repository();
            var initialCount = repo.GetAllApplications().Count;

            //Act

            repo.AddApplication(new Applications { StudentsId = 1, AnnouncementId = 12 });
            //Assert 

            var applications = repo.GetAllApplications();
            Assert.AreEqual(initialCount + 1, applications.Count);
            CollectionAssert.Contains(applications.Select(s => s.StudentsId).ToList(), 1);
        }

        //[Test]
        //public void AddStudent_ShouldAddApplicationToDatabase()
        //{
        //    //Arrange

        //    var repo = new Repository();
        //    var initialCount = repo.GetAllApplications().Count;

        //    //Act

        //    repo.AddAnnouncement(new Announcements { Title = " lalala", DormitoryId = 4,Description = "Test " });

        //    //Assert

        //    var announcement = repo.GetAllApplications();
        //    Assert.AreEqual(initialCount + 0, announcement.Count);
        //    CollectionAssert.Contains(announcement.Select(s => s.StudentId).ToList(),1 );


        //}
        [Test]
        public void UpdateStudent_ShouldUpdateStudent()
        {
            //Arrange

            var repo = new Repository();
            var student = new Students { Name = "Qazim ",Surname = "Hasani" };
            repo.AddStudent(student);
            student.Name = "Qazim";
            student.Surname = "Hasani";

            //Act

            repo.UpdateStudent(student);
            //Assert

            var updatedStudent = repo.GetAllStudents().FirstOrDefault(s => s.Id == student.Id);
            Assert.NotNull(updatedStudent);
            Assert.AreEqual("Qazim", updatedStudent.Name);
            Assert.AreEqual("Hasani", updatedStudent.Surname);

        }
        [Test]
        public void UpdateDormitories_ShouldUpdateDormitory()
        { 
            //Arrange

            var repo = new Repository();
            var student = new Dormitories { Name = "Qazim", Code = "123123" };
            repo.AddDormitory(student);
            student.Name = "Qazim";
            student.Code = "123123";

            //Act

            repo.UpdateDormitories(student);
            //Assert

            var updatedDormitory = repo.GetAllDormitories().FirstOrDefault(s => s.Id == student.Id);
            Assert.NotNull(updatedDormitory);
            Assert.AreEqual("Qazim", updatedDormitory.Name);
            Assert.AreEqual("123123", updatedDormitory.Code);

        }
        [Test]
        public void UpdateDormitoryStudent_ShouldUpdateDormitoryStudent()
        {
            //Arrange

            var repo = new Repository();
            var student = new DormitoryStudent { DormitoryId = 4 , StudentId = 2 , Capacity = 10 };
            repo.AddDormitoryStudent(student);
            student.DormitoryId = 4;
            student.StudentId = 2;
            student.Capacity = 10;

            //Act

            repo.UpdateDormitoryStudent(student);
            //Assert

            var updatedDormitoryStudent = repo.GetAllDormitoryStudents().FirstOrDefault(s => s.Id == student.Id);
            Assert.NotNull(updatedDormitoryStudent);
            Assert.AreEqual(4, updatedDormitoryStudent.DormitoryId);
            Assert.AreEqual( 2, updatedDormitoryStudent.StudentId);
            Assert.AreEqual(10, updatedDormitoryStudent.Capacity);

        }
        [Test]
        public void UpdateAnnouncement_ShouldUpdateAnnouncement()
        {
            //Arrange

            var repo = new Repository();
            var announcement = new Announcements { DormitoryId = 4,Title = "Test", Description = "Test"};
            repo.AddAnnouncement(announcement);
            announcement.DormitoryId = 4;
            announcement.Title = "Test";
            announcement.Description = "Test";

            //Act

            repo.UpdateAnnouncement(announcement);
            //Assert

            var updatedAnnouncement = repo.GetAllAnnouncements().FirstOrDefault(s => s.Id == announcement.Id);
            Assert.NotNull(updatedAnnouncement);
            Assert.AreEqual(4, updatedAnnouncement.DormitoryId);
            Assert.AreEqual("Test", updatedAnnouncement.Title);
            Assert.AreEqual("Test", updatedAnnouncement.Description);

        }
        //[Test]
        //public void UpdateApplication_ShouldUpdateApplicaton()
        //{
        //    //Arrange

        //    var repo = new Repository();
        //    var announcement = new Announcements { DormitoryId = 4, Title = "Test", Description = "Test" };
        //    repo.AddApplication(announcement);
        //    announcement.DormitoryId = 4;
        //    announcement.Title = "Test";
        //    announcement.Description = "Test";

        //    //Act

        //    repo.UpdateAnnouncement(announcement);
        //    //Assert

        //    var updatedAnnouncement = repo.GetAllAnnouncements().FirstOrDefault(s => s.Id == announcement.Id);
        //    Assert.NotNull(updatedAnnouncement);
        //    Assert.AreEqual(4, updatedAnnouncement.DormitoryId);
        //    Assert.AreEqual("Test", updatedAnnouncement.Title);
        //    Assert.AreEqual("Test", updatedAnnouncement.Description);

        //}

        [Test]
        public void DeleteStudent_ShouldDeleteStudentFromDAtabase()
        {
            //Arrange

            var repo = new Repository();
            var student = new Students { Name = "Qazim", Surname = "Hasani" };
            repo.AddStudent(student);
            var initialCount = repo.GetAllStudents().Count();

            //Act
            repo.DeleteStudent(student.Id);

            //Assserrt

            var students = repo.GetAllStudents();
            Assert.AreEqual(initialCount - 1, students.Count);
            CollectionAssert.DoesNotContain(students, student.Id);

        }
        [Test]
        public void DeleteDormitory_ShouldDeleteDormitoryFromDAtabase()
        {
            //Arrange

            var repo = new Repository();
            var student = new Dormitories { Name = "Qazim" , Code = "123123" };
            repo.AddDormitory(student);
            var initialCount = repo.GetAllDormitories().Count();

            //Act
            repo.DeleteDormitory(student.Id);

            //Assserrt
        
            var students = repo.GetAllDormitories();
            Assert.AreEqual(initialCount - 1, students.Count);
            CollectionAssert.DoesNotContain(students, student.Id);

        }
        [Test]
        public void DeleteDormitoryStudent_ShouldDeleteDormitoryStudentFromDAtabase()
        {
            //Arrange

            var repo = new Repository();
            var student = new DormitoryStudent { DormitoryId = 4, StudentId = 2, Capacity = 10 };
            repo.AddDormitoryStudent(student);
            var initialCount = repo.GetAllDormitoryStudents().Count();

            //Act
            repo.DeleteDormitoryStudent(student.Id);

            //Assserrt

            var students = repo.GetAllDormitoryStudents();
            Assert.AreEqual(initialCount - 1, students.Count);
            CollectionAssert.DoesNotContain(students, student.Id);

        }
        [Test]
        public void DeleteAnnouncement_ShouldDeleteAnnouncementFromDAtabase()
        {
            //Arrange

            var repo = new Repository();
            var announcement = new Announcements { DormitoryId = 4, Title = "Test", Description = "Test" };
            repo.AddAnnouncement(announcement);
            var initialCount = repo.GetAllAnnouncements().Count();

            //Act
            repo.DeleteAnnouncement(announcement.Id);

            //Assserrt

            var students = repo.GetAllAnnouncements();
            Assert.AreEqual(initialCount - 1, students.Count);
            CollectionAssert.DoesNotContain(students, announcement.Id);

        }

        //[Test]
        //public void DeleteApplication_ShouldDeleteApplicationFromDAtabase()
        //{
        //    //Arrange

        //    var repo = new Repository();
        //    var announcement = new Announcements { DormitoryId = 4, Title = "Test", Description = "Test" };
        //    repo.AddAnnouncement(announcement);
        //    var initialCount = repo.GetAllAnnouncements().Count();

        //    //Act
        //    repo.DeleteAnnouncement(announcement.Id);

        //    //Assserrt

        //    var students = repo.GetAllAnnouncements();
        //    Assert.AreEqual(initialCount - 1, students.Count);
        //    CollectionAssert.DoesNotContain(students, announcement.Id);

        //////////////////}



    }
}

