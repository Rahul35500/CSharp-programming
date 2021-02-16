using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Rahul");
           // book.ArrayIntilizer();
           book.GradeAdded+=onGradeAdded;
           book.GradeAdded+=onGradeAdded;

            EnterGrades(book);
            var stats = book.GetStatistics();

            System.Console.WriteLine($"The lowgrade value are:{stats.Low}");
            System.Console.WriteLine($"The highGrade value are:{stats.High}");
            System.Console.WriteLine($"The average value of students is {stats.Average}");



            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]} {args[1]} !");
            }
            else
            {
                Console.WriteLine("Hello");

            }
        }
        static void onGradeAdded(object sender,EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter the grade and enter for quite press q");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {

                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                // catch(Exception ex)
                // {  
                //     System.Console.WriteLine("this is catch block");
                //    Console.WriteLine(ex.Message);
                // }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine("this is catch block");
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine("this is catch block1");
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("***");
                }
            }
        }
    }
}
