//UNCOMMENT THIS ENTIRE FILE TO SEE HOW C# WORKS


// // file is where you'll develop the console application

// //with the 'using' directive, we're importing a common namespace called System
// //System namespace is part of the .NET framework. 
// //System is a collection of commonly used methods, data types, and data structures, which are the essential building blocks of a C# application
// using System;

// //import System.Collections.Generic
// using System.Collections.Generic;

// //Namespaces are used to organize and provide a level of separation in the code
// namespace CatWorx.BadgeMaker
// //everything inside the curly braces can be interpreted as members of that namespace
// {
//     class Program
//     {
//         //Main() is a very special method that serves as the entry point of the application
//         //Main() must be nested in a class
//         //use the following syntax to initialize the Main() method
//         static void Main(string[] args)//entry point
//         //void signifies that the return of this executable method will be void
//         //static implies that the scope of this method is at the class level, not the object level, and can thus be invoked without having to first create a new class instance
//         {
//             //variable 'greeting' was declared as a string --> data types are explicitly defined when the variables are declared
//             string greeting = "Hello";
//             //C# does not allow single quotes or backticks to express a string
//             greeting = greeting + "World";
//             Console.WriteLine("greeting" + greeting);
//             //output: greetingHelloWorld

//             //statement interpolates the variable greeting with the use of the $, and curly braces surround the variable ({greeting})
//             Console.WriteLine($"greeting {greeting}");
//             //output: greeting HelloWorld

//             // statement interpolates the variable greeting by associating the zero index with the second argument of the function call
//             Console.WriteLine("greeting: {0}", greeting);
//             //output: greeting: HelloWorld

//             //---------------------------------------------
//             //'int' for integers and 'float' for decimals
//             //'double' --> double data type used for a variable --> example 3.14 is a integer and decimal
//             // How do you find the area of a square? Area = side * side
//             double side = 3.14;
//             double area = side * side;
//             Console.WriteLine("area: {0}", area);// 3.14 * 3.14
//             //output: area: 9.8596

//             //se the GetType() function to identify the data type of a variable
//             Console.WriteLine("area is a {0}", area.GetType());

//             //-------------------------
//             Console.WriteLine(2 * 3);      // Basic Arithmetic: +, -, /, * --> 6
//             Console.WriteLine(10 % 3);       // Modulus Op => remainder of 10/3 --> 1
//             Console.WriteLine(1 + 2 * 3);     // order of operations --> 7
//             Console.WriteLine(10 / 3.0);     // int's and doubles --> 3.33333333335
//             Console.WriteLine(10 / 3);        // int's --> 3
//             Console.WriteLine("12" + "3");    // What happens here? --> 123

//             int num = 10;
//             num += 100; //10 + 100
//             Console.WriteLine(num); //--> 110
//             num++; //110 + 1
//             Console.WriteLine(num); //--> 111

//             //-------------------------------
//             bool isCold = true;
//             //if isCold is true, drink, if not, then add ice
//             Console.WriteLine(isCold ? "drink" : "add ice");  // output: drink
//             Console.WriteLine(!isCold ? "drink" : "add ice");  // output: add ice


//             string stringNum = "2"; // string of the number 2
//             int intNum = Convert.ToInt16(stringNum); //integer variable converts string to integer
//             Console.WriteLine(intNum); //output: 2
//             Console.WriteLine(intNum.GetType()); //output: System.int32
//             //Int32 designates the storage available for the variable --> This calculates to 32 bits, which is 2^32

//             Console.WriteLine("------------------------------------------");

//             //Data types for a dictionary's key-value pair types are declared in angled brackets < >
//             //declaring that the variable, myScoreBoard, is a dictionary that has a string key and an integer value
//             Dictionary<string, int> myScoreBoard = new Dictionary<string, int>();
//             //To populate the dictionary, we use the Add() method in multiple lines to add data
//             myScoreBoard.Add("firstInning", 10);
//             myScoreBoard.Add("secondInning", 20);
//             myScoreBoard.Add("thirdInning", 30);
//             myScoreBoard.Add("fourthInning", 40);
//             myScoreBoard.Add("fifthInning", 50);

//             //Alternatively, we could initialize the dictionary by listing the key-value pairs in a function call
//             // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(){
//             // { "firstInning", 10 },
//             // { "secondInning", 20},
//             // { "thirdInning", 30},
//             // { "fourthInning", 40},
//             // { "fifthInning", 50}
//             //};
//             Console.WriteLine("----------------");
//             Console.WriteLine("  Scoreboard");
//             Console.WriteLine("----------------");
//             Console.WriteLine("Inning |  Score");
//             Console.WriteLine("   1   |    {0}", myScoreBoard["firstInning"]);
//             Console.WriteLine("   2   |    {0}", myScoreBoard["secondInning"]);
//             Console.WriteLine("   3   |    {0}", myScoreBoard["thirdInning"]);
//             Console.WriteLine("   4   |    {0}", myScoreBoard["fourthInning"]);
//             Console.WriteLine("   5   |    {0}", myScoreBoard["fifthInning"]);


//             Console.WriteLine("-----------------------------------");
//             //data type of the array’s elements must be declared
//             //the length of the array must also be set when the array is declared
//             //the string array is names favFoods and contains 3 elements
//             string[] favFoods = new string[3] { "pizza", "doughnuts", "icecream" };
//             string firstFood = favFoods[0];
//             string secondFood = favFoods[1];
//             string thirdFood = favFoods[2];
//             Console.WriteLine("I like {0}, {1}, and {2}", firstFood, secondFood, thirdFood);
//             //output: I like pizza, doughnuts, and icecream

//             Console.WriteLine("-----------------------------------");
//             //declare a list and its data types using the angle bracket notation, similar to the dictionary
//             List<string> employees = new List<string>() { "adam", "amy" };
//             // added more employee names using the Add() method
//             employees.Add("barbara");
//             employees.Add("billy");
//             Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
//             //output: My employees include adam, amy, barbara, billy

//             Console.WriteLine("-----------------------------------");
//             //for loop
//             //instead of length, use Count in c#
//             for (int i = 0; i < employees.Count; i++)
//             {
//                 Console.WriteLine(employees[i]);
//             }

//         }
//     }
// }