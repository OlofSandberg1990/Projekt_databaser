using Microsoft.EntityFrameworkCore;
using Projekt_Databaser.Data;
using Projekt_Databaser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.ServiceClasses
{
    internal class MarkService
    {
        public static void NewMark(ProjectSchoolDbContext db)
        {
            Console.WriteLine("Vilken elev ska få betyg?");

            var allStudents = db.Students
            .Include(s => s.Class)
            .OrderBy(c => c.Class.ClassName)
            .ToList();

            int countIndex = 1;

            foreach (var student in allStudents)
            {
                Console.WriteLine($"{countIndex}, {student.FirstName} {student.LastName} {student.Class.ClassName}");
                countIndex++;
            }


            int selectedIndex = GeneralService.CheckIfInt(1, allStudents.Count) - 1;
            var selectedStudent = allStudents[selectedIndex];

            Console.Clear();

            Console.WriteLine($"Elev : {selectedStudent.FirstName}");
            Console.WriteLine("\n");
            Console.WriteLine($"Vilken kurs ska {selectedStudent.FirstName} få betyg i?");

            var allCourses = db.Courses
            .Where(c => c.IsActive == true)
            .ToList();



            int courseCount = 1;
            foreach (var course in allCourses)
            {
                Console.WriteLine($"{courseCount}, {course.CourseName}");
                courseCount++;
            }

            int courseIndex = GeneralService.CheckIfInt(1, allStudents.Count) - 1;
            var selectedCourse = allCourses[courseIndex];

            Console.Clear();



            Console.WriteLine($"Elev : {selectedStudent.FirstName}");
            Console.WriteLine($"Kurs : {selectedCourse.CourseName}");

            Console.WriteLine($"\nVilket betyg ska {selectedStudent.FirstName} få i {selectedCourse.CourseName}?");

            var allMarks = db.MarksMeanings.ToList();

            int markCount = 1;

            foreach (var marks in allMarks)
            {
                Console.WriteLine($"{markCount}, {marks.MarkName}");
                markCount++;
            }

            int markIndex = GeneralService.CheckIfInt(1, allMarks.Count) -1;
            var selectedMark = allMarks[markIndex];

            Console.Clear();

            Console.WriteLine($"Elev : {selectedStudent.FirstName}");
            Console.WriteLine($"Kurs : {selectedCourse.CourseName}");
            Console.WriteLine($"Betyg : {selectedMark.MarkName}");

            Console.WriteLine("\nVilken lärare har satt betyget?");

            var allTeachers = db.Employees
                .Where(e => e.RoleId == 1)
                .OrderBy(e => e.FirstName)
                .ToList();

            int teacherCount = 1;

            foreach (var teacher in allTeachers)
            {
                Console.WriteLine($"{teacherCount}, {teacher.FirstName} {teacher.LastName}");
                teacherCount++;
            }

            int teacherIndex = GeneralService.CheckIfInt(1, allTeachers.Count) -1;
            var selectedTeacher = allTeachers[teacherIndex];

            Console.Clear();

            Console.WriteLine($"Elev : {selectedStudent.FirstName}");
            Console.WriteLine($"Kurs : {selectedCourse.CourseName}");
            Console.WriteLine($"Betyg : {selectedMark.MarkName}");
            Console.WriteLine($"Lärare : {selectedTeacher.FirstName} {selectedTeacher.LastName}");

            Console.WriteLine("\nGodkänna betyget?");

            Console.WriteLine("1, Ja");
            Console.WriteLine("2, Avbryt");

            int inputChoice = GeneralService.CheckIfInt(1, 2);

            Console.Clear();
            switch (inputChoice)
            {
                case 1:
                    var addMark = RegisterMark(selectedStudent.Id, selectedCourse.Id, selectedTeacher.Id, selectedMark.Id);
                    db.Marks.Add(addMark);
                    db.SaveChanges();
                    Console.WriteLine("Betyget har godkänts och lagts till i databasen");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Betygsättningen har avbrutits");
                    Console.ReadKey();
                    Console.Clear();
                    break;               

            }






        }

        public static Mark RegisterMark(int studentId, int courseId, int employeeId, int markMeaningId)
        {
            Mark mark = new Mark()
            {
                StudentId = studentId,
                CourseId = courseId,
                EmployeeId = employeeId,
                MarkMeaningId = markMeaningId,
                DateOfMark = DateOnly.FromDateTime(DateTime.Now)

            };

            return mark;

        }
    }
}
