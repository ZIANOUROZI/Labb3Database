
using Labb3Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3Database.AppModels
{
    internal class App
    {
        public void GetAllEmployees()
        {
            // Method for all teachers
            MyDbContext context = new MyDbContext();
           try
            {
                var teacher = context.Staffs.FromSqlRaw("SELECT * FROM Staffs WHERE FKRoleId = 1;").ToList();
               foreach(var teachers in teacher)
               {
                    Console.WriteLine($"TeacherName {teachers.Name}");
               }
            }
            catch(Exception)
            {
                Console.WriteLine("fel");
            }
            Console.ReadKey();
        }    
        //Method for all employees
        public void GetAllEmpo()
        {
            MyDbContext context = new MyDbContext();
            var employees = context.Staffs.FromSqlRaw("SELECT * FROM Staffs").ToList();
            foreach (var empo in employees)
            {
                Console.WriteLine(empo.Name);

            }
            Console.ReadKey();
        }
        //Method of sorting the name
        public void GetAllSortByName()
        {
            MyDbContext context = new MyDbContext();
            var studentSortName = context.Students.OrderBy(s => s.Name).ToList();
            foreach(var sortName in studentSortName)
            {
                Console.WriteLine(" Elverna sorterad på namnet: " + sortName.Name);
            }
            Console.ReadKey();
        }
        // In this method you choose which class you want to see
        public void GetAllClasses()
        {
            MyDbContext context = new MyDbContext();
            var classes = context.Classes.ToList();
            Console.WriteLine("Lista över alla klasser:");
            foreach (var classObj in classes)
            {
                Console.WriteLine($"{classObj.ClassId}: {classObj.ClassName}");
            }
            Console.WriteLine("Välj en klass genom att ange dess ID:");
            if (int.TryParse(Console.ReadLine(), out int selectedClassId))
            {
                var students = context.Grades
                    .Include(g => g.Fkstudent)
                    .Include(g => g.Fkcourse)
                    .ThenInclude(c => c.Fkclass)
                    .Where(g => g.Fkcourse.Fkclass.ClassId == selectedClassId)
                    .Select(g => g.Fkstudent.Name)
                    .Distinct()
                    .ToList();
                Console.WriteLine($"Elever i den valda klassen ({classes.First(c => c.ClassId == selectedClassId).ClassName}):");
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Ange ett giltigt ID.");
            }
            Console.ReadKey();
        }
        // That method retrieves all grades set in the last month
        public void GetAllGrades()
        {
            MyDbContext context = new MyDbContext();
            var grades = context.Grades.FromSqlRaw("select * from Grades where YEAR(DateTime) = YEAR(GETDATE()) AND MONTH(DateTime) = MONTH(GETDATE())").ToList();
            foreach(var grade in grades)
            {
                Console.WriteLine(grade.DateTime);
            }
            Console.ReadKey();
        }
        //That method retrieves Lowest ratings
        public void LowestGrades()
        {
            MyDbContext context = new MyDbContext();
            var lowes = context.Grades.Min(g => g.GradeBetyg);
            Console.WriteLine($"Lägsta betyg: {lowes}");
            Console.ReadKey();
        }
        //That method retrieves max ratings
        public void MaxGrades()
        {
            MyDbContext context = new MyDbContext();
            var max = context.Grades.Max(g => g.GradeBetyg);
            Console.WriteLine($" Högsta betyg: {max}");
            Console.ReadKey();
        }
        //That method adds new students
        public void AddNewStudents()
        {
            MyDbContext context = new MyDbContext();
            Console.WriteLine("Ange namn på den nya eleven:");
            string studentName = Console.ReadLine();

            Console.WriteLine("Ange personnummer för den nya eleven:");
            string personNumber = Console.ReadLine();

            var newStudent = new Student
            {
                Name = studentName,
                PersonNumber = personNumber
            };
            context.Students.Add(newStudent);
            context.SaveChanges();

            Console.WriteLine($"Ny elev tillagd: {newStudent.Name} (Personnummer: {newStudent.PersonNumber})");
            Console.ReadKey();
        }
        //That method adds new employees
        public void AddNewEmployees()
        {
            MyDbContext context = new MyDbContext();
            Console.WriteLine(" Ange namn på den nya personal:");
            string staffName = Console.ReadLine();
            Console.WriteLine(" Ange ett role-Id för den nya anställda: ");
            Console.WriteLine(" Vill du lägga till som lärare tryck 1: \n" +
                   " Vill du lägga som admin tryck 2: \n" +
                   " Vill du lägga som rektor tryck 3:  ");
            if (int.TryParse(Console.ReadLine(), out int rolId))
            {
                var newStaff = new Staff
                {
                    Name = staffName,
                    FkroleId = rolId
                };
                context.Staffs.Add(newStaff);
                context.SaveChanges();
                Console.WriteLine($"Ny personal tillagd: {newStaff.Name} (RoleId: {newStaff.FkroleId})");
            }
            else
            {
                Console.WriteLine("Ogiltigt role - ID. Ange ett giltigt heltal");
            }
            Console.ReadKey();
        }
    }
}

