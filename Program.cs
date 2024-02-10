using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Projekt_Databaser.Data;
using Projekt_Databaser.Models;
using Projekt_Databaser.ServiceClasses;
using System.Linq.Expressions;
using System.Runtime;
using System.Threading.Channels;

namespace Projekt_Databaser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ProjectSchoolDbContext db = new ProjectSchoolDbContext();

            Menu(db);

        }

        public static void Menu(ProjectSchoolDbContext db)
        {
            bool menuBool = true;            

            while (menuBool)
            {
                int input = 0;
                Console.WriteLine("1, Elevregister");
                Console.WriteLine("2, Avdelningsinformation");
                Console.WriteLine("3, Visa lista på aktiva kurser");
                Console.WriteLine("4, Sätt ett nytt betyg");

                string inputString = Console.ReadLine();
                                
                try
                {
                    input = Convert.ToInt32(inputString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Felaktig inmatning. Ange ett nummer.");
                    continue;
                }

                Console.Clear();

                Console.Clear();

                switch (input)
                {
                    case 1:
                        StudentService.StudentRegister(db);
                        break;
                    case 2:
                        DepartmentService.DepartmentInfo(db);
                        break;
                    case 3:
                        CourseService.ShowCourses(db);
                        break;
                    case 4:
                        MarkService.NewMark(db);
                        break;
                    default:
                        Console.WriteLine("Ange ett giltligt alternativ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }


        }



    }
}
