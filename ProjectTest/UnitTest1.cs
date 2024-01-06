using NUnit.Framework;
using NUnit.Framework.Internal;
using Find_me_a_roommate;

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
        //[Test]
        //public void AddApplication_ShouldAddApplicationToDatabase()
        //{

        //    //Arrange

        //    var repo = new Repository();
        //    var initialCount = repo.GetAllApplications().Count;

        //    //Act

        //    repo.AddApplication(new Applications { StudentId = 2 ,AnnouncementId= 17 });
        //    //Assert
             
        //    var applications = repo.GetAllApplications();
        //    Assert.AreEqual(initialCount + 1, applications.Count);
        //    CollectionAssert.Contains(applications.Select(s => s.StudentId).ToList(),2);
        //}


    }
}

