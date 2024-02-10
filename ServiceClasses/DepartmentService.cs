using Projekt_Databaser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.ServiceClasses
{
    internal class DepartmentService
    {
        public static void DepartmentInfo(ProjectSchoolDbContext db)
        {
            var teachers = db.Employees
                .Where(e => e.Role.Id == 1)                     //Skapar en variabel där RoleId är 1 (och ett är Lärare i min tabell)
                .GroupBy(e => e.Department.DepartmentName)      //Gruperar reslutatet efter avdelningsnamnet som de tillhör
                .Select(group => new
                {
                    DepartmentName = group.Key,                 //Sedan använder jag mig av Select-satsen för att skriva ut gruppens Key
                    CountTeachers = group.Count()               //(dvs DepartmentName) och sedan räknar ihop hur många som tillhör varje department
                })                                              //genom count-metoden
                .ToList();

            Console.WriteLine("Avdelningsinformation");
            Console.WriteLine(new string('-', 22));
            foreach (var item in teachers)
            {
                Console.WriteLine($"Avelningsnamn : {item.DepartmentName}\tAntal lärare : {item.CountTeachers}");
            }
            Console.ReadKey();
            Console.Clear();

        }
    }
}
