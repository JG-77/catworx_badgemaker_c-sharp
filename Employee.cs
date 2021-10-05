namespace CatWorx.BadgeMaker
//By wrapping the class in the CatWorx.BadgeMaker namespace, we can access it directly from any class that uses CatWorx.BadgeMaker
{
    class Employee
    {
        // properties and methods defined in a class are given the protection level of private, which means that they can only be accessed within the class itself
        // If we try to access a private property from outside the class, we'll get an error
        // control the access level of properties when we declare them, using an access modifier
        private string FirstName;
        //To distinguish between public and private variables, use PascalCase for public variables and camelCase for private variables
        private string LastName;
        private int Id;
        private string PhotoUrl;

        //use camelCase for the parameters and PascalCase when assigning them to properties
        public Employee(string firstName, string lastName, int id, string photoUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        //create an Employee instance and set its FirstName and LastName properties in one statement
        //method returns a string
        public string GetName()
        {
            return FirstName + " " + LastName;
        }

        public int GetId()
        //create an Employee instance to return ID
        {
            return Id;
        }
        public string GetPhotoUrl()
        //create an Employee instance to return pic url
        {
            return PhotoUrl;
        }
        public string GetCompanyName()
        {
            return "Cat Worx";
        }
    }
}