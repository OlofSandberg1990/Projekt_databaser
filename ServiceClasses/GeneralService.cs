using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.ServiceClasses
{
    internal class GeneralService
    {
        public static int CheckIfInt(int min, int max)
        {
            bool run = true;
            int result = 0;

            while (run)
            {
                string inputString = Console.ReadLine();

                if (int.TryParse(inputString, out result) && result >= min && result <= max)  //Fastställer så det inmatade talet är en int och inom inparametrarnas intervall.
                {
                    run = false;

                } else
                {
                    Console.WriteLine("Felaktig inmatning, ange ett heltal");
                }
                                

            }
            return result;
        }


    }
}
