using Projekt_Databaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.ServiceClasses
{
    internal class CourseService
    {

        public static void ShowCourses(ProjectSchoolDbContext db)
        {
            Console.WriteLine("Lista över aktiva kurser");
            Console.WriteLine(new string ('-' , 25));

            var courses = db.Courses
            .Where(c => c.IsActive)                             //Skapar en variabel som sparar de kurser som har en bool med true-värde
            .OrderBy(cn => cn.CourseName)                       // och sorterar efter courseName.
            .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }

            var nonActiceCourses = db.Courses
            .Where(c => c.IsActive == false)                    //Skapar en liknande variabel, fast denna gången med kurser där 
            .OrderBy(cn => cn.CourseName)                       //boolen har false-värde.
            .ToList();

            Console.WriteLine("\n\nLista över kurser som inte är aktiva");
            Console.WriteLine(new string('-', 35));
            foreach (var course in nonActiceCourses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
