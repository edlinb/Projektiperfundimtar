using Find_me_a_roommate;

class Program
{
    static void Main(string[] args)
    {
        var operationsRepo = new Repository();
        var exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Display all students");
            Console.WriteLine("2. Display all dormitories");
            Console.WriteLine("3. Display student with their assigned dormitory");
            Console.WriteLine("4. Display all Anouncements");
            Console.WriteLine("5. Add a student");
            Console.WriteLine("6. Add a dormitory");
            Console.WriteLine("7. Delete a student");
            Console.WriteLine("8. Assign dormitory to student");
            Console.WriteLine("9. New Anouncement");
            Console.WriteLine("10. Delete Anouncement");
            Console.WriteLine("11. Apply for Anouncement");
            Console.WriteLine("12. Display all Applications");
            Console.WriteLine("13. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var students = operationsRepo.GetAllStudents();
                    if (students == null)
                    {
                        Console.WriteLine("There are no students registered in the database");
                        Console.WriteLine("------------------------------");
                    }
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                        Console.WriteLine("------------------------------");
                    }
                    break;
                case "2":
                    var dormitories = operationsRepo.GetAllDormitories();
                    if (dormitories == null)
                    {
                        Console.WriteLine("There are no dormitories registered in the database");
                        Console.WriteLine("------------------------------");
                    }
                    foreach (var dormitory in dormitories)
                    {
                        Console.WriteLine($"Dormitory ID: {dormitory.Id}, Name: {dormitory.Name}");
                        Console.WriteLine($"Students Count: {dormitory.DormitoryStudent.Count}");
                        Console.WriteLine("------------------------------");
                    }
                    break;
                case "3":
                    var studentsWithDormitory = operationsRepo.GetAllStudents();
                    if (studentsWithDormitory == null)
                    {
                        Console.WriteLine("There are no students with assigned dormitories registered in the database");
                        Console.WriteLine("------------------------------");
                    }
                    foreach (var student in studentsWithDormitory)
                    {
                        Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                        Console.WriteLine($"Assigned Dormitory: {(student.DormitoryStudent != null ? student.Name : "None")}");
                        Console.WriteLine("------------------------------");
                    }
                    break;
                case "4":
                    var announcements = operationsRepo.GetAllAnnouncements();
                    if (announcements == null)
                    {
                        Console.WriteLine("There are no active announcements in the database");
                        Console.WriteLine("------------------------------");
                    }
                    else
                    {
                        foreach (var a in announcements)
                        {
                            Console.WriteLine($"Announcement ID: {a.Id}");
                            Console.WriteLine($"Title: {a.Title}");
                            Console.WriteLine($"Description: {a.Description}");
                            Console.WriteLine($"Published Date: {a.PublishedDate}");
                            Console.WriteLine("------------------------------");
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine("Enter student name:");
                    var studentName = Console.ReadLine();
                    Console.WriteLine("Enter student surname:");
                    var studentSurname = Console.ReadLine();
                    var newStudent = new Students { Name = studentName, Surname = studentSurname };
                    operationsRepo.AddStudent(newStudent);
                    break;
                case "6":
                    Console.WriteLine("Enter dormitory name:");
                    var dormitoryName = Console.ReadLine();
                    Console.WriteLine("Enter dormitory code:");
                    var dormitoryCode = Console.ReadLine();
                    var newDormitory = new Dormitories { Name = dormitoryName, Code = dormitoryCode };
                    operationsRepo.AddDormitory(newDormitory);
                    break;
                case "7":
                    Console.WriteLine("Enter student ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteStudentId))
                    {
                        operationsRepo.DeleteStudent(deleteStudentId);
                    }
                    break;
                case "8":
                    Console.WriteLine("Enter Student ID:");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Enter Dormitory ID to assign to the student:");
                        if (int.TryParse(Console.ReadLine(), out int dormitoryId))
                        {
                            operationsRepo.RegisterDormitoryToStudent(studentId, dormitoryId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Dormitory ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Student ID.");
                    }
                    break;
                case "9":
                    Console.WriteLine("Enter announcement title:");
                    var announcementTitle = Console.ReadLine();
                    Console.WriteLine("Enter announcement description:");
                    var announcementDescription = Console.ReadLine();
                    Console.WriteLine("Enter announcement dormitory Id");
                    var announcementDormitoryId =Convert.ToInt32(Console.ReadLine()) ;
                    var newAnouncement = new Announcements { Title = announcementTitle, Description = announcementDescription, DormitoryId = announcementDormitoryId };
                    operationsRepo.AddAnnouncement(newAnouncement);
                    break;
                case "10":
                    Console.WriteLine("Enter announcement ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteAnnouncementId))
                    {
                        operationsRepo.DeleteAnnouncement(deleteAnnouncementId);
                    }
                    break;
                case "11":
                    Console.WriteLine("Enter Student ID:");
                    if (int.TryParse(Console.ReadLine(), out int studentsId))
                    {
                        Console.WriteLine("Enter Anouncement ID to assign to the student:");
                        if (int.TryParse(Console.ReadLine(), out int announcementId))
                        {
                            operationsRepo.RegisterStudentsToAnnouncements(studentsId, announcementId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Anouncement ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Student ID.");
                    }
                    break;
                case "12":
                    var applications = operationsRepo.GetAllApplications();
                    if (applications == null)
                    {
                        Console.WriteLine("There are no applications in the database");
                        Console.WriteLine("------------------------------");
                    }
                    foreach (var an in applications)
                    {
                        Console.WriteLine($"Application ID: {an.Id}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Student ID: {an.StudentsId}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Announcement ID: {an.AnnouncementId}");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Application Date: {an.ApplicationDate}");
                        Console.WriteLine("------------------------------");
                    }
                    break;
                    //tani eshte ne rregull po unittestet nuk me beheshin prej ksaj apo arsye tjeter
                    //ja ta shohim

                case "13":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}

//hiii
//e rregullove ate prb qe kishe dje errorin e hoqa por me del qe nuk ka aplikime dhe kur i shtoj eshte kjo me komen