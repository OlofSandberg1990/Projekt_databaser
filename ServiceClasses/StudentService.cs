using Microsoft.EntityFrameworkCore;
using Projekt_Databaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.ServiceClasses
{
    internal class StudentService
    {
        public static void StudentRegister(ProjectSchoolDbContext db)
        {
            Console.WriteLine("Vilken elev vill du se information om?");
            Console.WriteLine(new string ('-',37));

            var resultat = db.Students
            .Include(s => s.Class)
            .Include(s => s.Marks)                  //Inkluderar tabellen Marks som har en relation till Students,
                .ThenInclude(m => m.MarkMeaning)    //Inkluderar MarkMeaning till Marks
            .Include(m => m.Marks)
            .ThenInclude(m => m.Course)
            .OrderBy(s => s.Class.ClassName)
            .ToList();

            int countIndex = 1;

            foreach (var student in resultat)
            {
                Console.WriteLine($"{countIndex}, {student.FirstName} {student.LastName} {student.Class.ClassName}");
                countIndex++;
            }


            int selectedIndex = GeneralService.CheckIfInt(1, resultat.Count) -1;
            
            var selectedStudent = resultat[selectedIndex];
            Console.Clear();
            Console.WriteLine("Studentinfo");
            Console.WriteLine(new string ('-', 12));
            Console.WriteLine($"Namn\t\t {selectedStudent.FirstName} {selectedStudent.LastName}");
            Console.WriteLine($"Klass\t\t {selectedStudent.Class.ClassName}");
            Console.WriteLine($"Kön\t\t {selectedStudent.Gender}");
            Console.WriteLine($"Personnummer\t {selectedStudent.SocialSecurityNumber}");
            Console.WriteLine("\nBetyg");
            Console.WriteLine(new string('-', 6));

            foreach (var item in selectedStudent.Marks)
            {
                Console.WriteLine($"Kurs : {item.Course.CourseName}\nBetyg : {item.MarkMeaning.MarkName}\n");
            }

            Console.ReadKey();
            Console.Clear();

        }
    }
}
