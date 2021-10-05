using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        // a method declaration (or signature) looks like the following example 
        //--> [access_modifier] ["static"] return_type name([parameters])
        //make the return type of this method List<string>
        //Any method that does not return a value must be defined to return void
        static void Main(string[] args)
        {
            // This is our employee-getting code now --> method GetEmployees()
            // GetEmployees() needs to return employee names, which is stored in a list of strings
            // we call GetEmployees() and then PrintEmployees() prints it out in the console
            List<Employee> employees = new List<Employee>();

            // http://placekitten.com/200/300 --> link for placeholder image

            string Answer;
            //give user choice to fetch data frpm api or manually create badge
            Console.WriteLine("Do you want to fetch data from the APi? (y=Yes/n=No)");
            Answer = Console.ReadLine();
            if (Answer == "n")
            {

                employees = PeopleFetcher.GetEmployees();
            }
            else
            {

                employees = PeopleFetcher.GetFromAPI();
            }

            Util.MakeCSV(employees);
            Util.MakeBadges(employees);

        }
    }
}