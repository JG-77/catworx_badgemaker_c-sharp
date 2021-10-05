using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq; //gives us access to a new class called JObject that will allow us to parse the JSON

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // code from GetEmployees() in Program.cs
        public static List<Employee> GetEmployees()
        // if a static method wants to call another method inside the same class directly, that method must also be static
        {
            //create employees variable with list object of Employee custom datatype
            List<Employee> employees = new List<Employee>();
            // Collect user values until the value is an empty string
            //executes a statement or a block of statements while a specified Boolean expression evaluates to true
            while (true)
            //Using a while loop, we'll get multiple employee names and store them in a list
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                // Get a name from the console and assign it to a variable
                //.NET runtime halts and waits for input
                //changed input to 'firstName', because that's how we've been using it all along. Now that we have other values to capture, it makes sense to be more specific
                string firstName = Console.ReadLine();
                // Break if the user hits ENTER without typing a name
                if (firstName == "")
                {
                    break;
                }
                // Create a new Employee instance
                // add a Console.ReadLine() for each value
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter ID: ");
                //To store a string as an integer, we can use the Int32.Parse() method
                int id = Int32.Parse(Console.ReadLine());

                Console.Write("Enter Photo URL:");
                string photoUrl = Console.ReadLine();

                //When you define a class in C#, it registers that class name as a custom type, so the type of any instance of Employee is also Employee
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // Add currentEmployee, not a string
                employees.Add(currentEmployee);
            }
            // Because we'll hand off the list of employee names to the caller of the method, we must make sure to return it at the end of the method
            return employees;
        }

        public static List<Employee> GetFromAPI()
        //This method will also return a List of Employee instances
        {
            List<Employee> employees = new List<Employee>();

            using (WebClient client = new WebClient())
            {
                // download all of the information from this URL as a string
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");

                //will convert the string that we downloaded from the API into a JObject
                JObject json = JObject.Parse(response);

                //the command json.SelectToken("results") should give us the entire array of people objects for us to iterate over --> It's a JObject
                foreach (JToken token in json.SelectToken("results"))
                {
                    // Parse JSON data
                    // loop set up now that's accessing a new JObject on every iteration
                    Employee emp = new Employee
                    (
                      token.SelectToken("name.first").ToString(),
                      token.SelectToken("name.last").ToString(),
                      //convert id to the right data types before giving them to the constructor
                      Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                      token.SelectToken("picture.large").ToString()
                    );
                    //add each new employee to the List that this method returns
                    employees.Add(emp);
                }
            }

            return employees;
        }
    }
}