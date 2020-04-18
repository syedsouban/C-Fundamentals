using System;
using System.Collections.Generic;

namespace GradeBook
{
    // dotnet run --project src\GradeBook
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs args) {
            InMemoryBook book  = (InMemoryBook) sender;
            Console.WriteLine($"A grade was added in {book.Name}");
        }
        static void Main(string[] args)
        {

            Book diskBook = new DiskBook("Programming");
            // diskBook.AddGrade(12);
            Book gradeBook = new DiskBook("Mathematics Gradebook");
            // gradeBook.GradeAdded += OnGradeAdded;
            Console.WriteLine("Input grades(Enter q to stop): ");
            EnterGrades(gradeBook);
            if (gradeBook.HasGrades())
            {
                var result = gradeBook.GetStatistics();
                //Ni is used to print i digits after the decimal point
                System.Console.WriteLine($"The average grade is: {result.Average:N2}");
                System.Console.WriteLine($"The average grade letter is: {result.Letter:N2}");
                System.Console.WriteLine($"The lowest grade is: {result.Lowest:N2}");
                System.Console.WriteLine($"The highest grade is: {result.Highest:N2}");
                
            }
            else
            {
                Console.WriteLine("No grades given");
            }
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                    break;
                try
                {
                    double grade = Double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid grade entered!");
                    Console.WriteLine("Input grades(Enter q to stop): ");
                    continue;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Grade should be between 0 and 100!");
                    Console.WriteLine("Input grades(Enter q to stop): ");
                    continue;
                }
            }
        }
    }
}
