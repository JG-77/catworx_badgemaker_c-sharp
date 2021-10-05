// Import correct packages
using System;
using System.IO; // Directory & StreamWriter class tells us that it falls under the System.IO namespace
using System.Collections.Generic;
using System.Net; //use the WebClient class --> used to send HTTP requests, read files, download webpages, and upload data
using System.Drawing; //to use the Image class, we need to reference the System.Drawing namespace
// ran 'dotnet add package System.Drawing.Common' to install in terminal

namespace CatWorx.BadgeMaker
{
    //make this class available in the same namespace so that other classes like Program can see and use it
    //we won't create new instances of this class
    class Util
    {
        // Method declared as "static" meaning that it belongs to the class itself instead of individual instances or objects
        // In other words, we don’t have to create a new Util object to use it. We can access this method directly from the class name
        public static void PrintEmployees(List<Employee> employees)
        {
            //Using a while loop, we pass in employee list data in the parameter
            for (int i = 0; i < employees.Count; i++)
            {
                // each item in employees is now an Employee instance
                string template = "{0,-10}\t{1,-20}\t{2}"; //the formatting formula for the output
                //print out all of the employee information for each employee
                //String.Format() works similarly to template literals in JavaScript; it takes a string to use as a template and then fills in the placeholders with values
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
            }
        }
        //add another static method, called MakeCSV() --> which will make the CSV file
        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create it
                Directory.CreateDirectory("data");
            }

            //StreamWriter facilitates creating and writing to files
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            //keyword 'using' has two distinct meanings that depend on the context (importing a namespace versus temporarily using a resource)
            //whatever is defined in the parentheses is ONLY available within the subsequent set of curly brackets
            {
                file.WriteLine("ID,Name,PhotoUrl");
                // Loop over employees
                for (int i = 0; i < employees.Count; i++)
                {
                    // Write each employee to the file
                    string template = "{0},{1},{2}";
                    //repurpose the for loop from PrintEmployee() and console log logic --> change Console.WriteLine to file.WriteLine
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
                }
            }
        }
        //public — Must be accessible by the Main() method
        //void — The purpose of this method is to create a file, so there is no need for a return
        //static — Scoped to class, so can be invoked directly without instantiating an object
        public static void MakeBadges(List<Employee> employees)
        {
            // Layout variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;
            int COMPANY_NAME_START_X = 0;
            int COMPANY_NAME_START_Y = 110;
            int COMPANY_NAME_WIDTH = 100;
            int PHOTO_START_X = 184;
            int PHOTO_START_Y = 215;
            int PHOTO_WIDTH = 302;
            int PHOTO_HEIGHT = 302;
            int EMPLOYEE_NAME_START_X = 0;
            int EMPLOYEE_NAME_START_Y = 560;
            int EMPLOYEE_NAME_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_NAME_HEIGHT = 100;
            int EMPLOYEE_ID_START_X = 0;
            int EMPLOYEE_ID_START_Y = 690;
            int EMPLOYEE_ID_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_ID_HEIGHT = 100;

            // Create image
            Image newImage = Image.FromFile("badge.png");
            //ensure that the new image is stored in the data folder
            newImage.Save("data/employeeBadge.png");

            // Graphics objects, part of System.Drawing
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            int FONT_SIZE = 32;
            Font font = new Font("Arial", FONT_SIZE);
            Font monoFont = new Font("Courier New", FONT_SIZE);
            SolidBrush brush = new SolidBrush(Color.Black);

            // instance of WebClient is disposed after code in the block has run
            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    //opens a readable stream for the data downloaded from a resource with the URI specified as a String
                    //Stream employeeStream = client.OpenRead(employees[i].GetPhotoUrl());
                    //make the conversion from a Stream to an Image
                    // Image photo = Image.FromStream(employeeStream);

                    //simplify the code's readability and avoid unnecessarily creating variables, we can combine the last two expressions into one
                    Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoUrl()));

                    // variable name to background to signify that the badge image will be the background image onto which we'll print the employee information
                    Image background = Image.FromFile("badge.png");
                    Image badge = new Bitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    //Graphics object has been created, we can use the methods in the Graphics class to insert images onto the badge
                    Graphics graphic = Graphics.FromImage(badge);
                    //insert a badge template Image object, named background, onto the badge
                    //rectangle allows us to allocate a position and size on the badge
                    graphic.DrawImage(background, new Rectangle(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                    // insert the employee photo at the coordinates currently held by the placeholder image on the badge template
                    graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));

                    // Company name badge format
                    graphic.DrawString(
                      employees[i].GetCompanyName(),
                      font, //already created and initialized from the Font class
                      new SolidBrush(Color.White), //font color. We must create a new Brush object
                      new Rectangle( //allows placement and sizing on the Bitmap badge
                                     //order of arguments is important!!!
                        COMPANY_NAME_START_X,
                        COMPANY_NAME_START_Y,
                        BADGE_WIDTH,
                        COMPANY_NAME_WIDTH
                      ),
                    format //use the format instance object that we declared previously for center alignment
                    );

                    //Employee name badge format
                    graphic.DrawString(
                        employees[i].GetName(),
                        font,
                        brush,
                        new Rectangle(
                            EMPLOYEE_NAME_START_X,
                            EMPLOYEE_NAME_START_Y,
                            BADGE_WIDTH,
                            EMPLOYEE_NAME_HEIGHT
                        ),
                        format
                    );

                    //Employee ID badge format
                    graphic.DrawString(
                        employees[i].GetId().ToString(),
                        monoFont,
                        brush,
                        new Rectangle(
                            EMPLOYEE_ID_START_X,
                            EMPLOYEE_ID_START_Y,
                            EMPLOYEE_ID_WIDTH,
                            EMPLOYEE_ID_HEIGHT
                        ),
                        format
                    );

                    //save and create a badge for each employee ID
                    string template = "data/{0}_badge.png"; //convert the file name into a string before placing it into the Save() method argument
                    badge.Save(string.Format(template, employees[i].GetId())); //code to save and create mulitple badges
                }
            }


        }

    }

}
