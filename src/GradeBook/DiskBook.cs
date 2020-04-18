using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event InMemoryBook.GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (StreamWriter sw = File.AppendText($"{Name}.txt"))
                {
                    sw.Write(grade.ToString() + "\n");
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
                throw new ArgumentException("Grade should be between 0 and 100 inclusive");
        }

        public override Statistics GetStatistics()
        {
            var openedFile = File.OpenText($"{Name}.txt");
            string line = "";
            var grade = 0.0;
            Statistics stats = new Statistics();
            while ((line = openedFile.ReadLine()) != null)
            {
                try
                {
                    grade = double.Parse(line);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Unable to parse one of the grade from {Name}.txt");
                    continue;
                }
                
                stats.Add(grade);
            }
            openedFile.Close();
            return stats;
        }

        public override bool HasGrades()
        {
            try{
                var openedFile = File.OpenText($"{Name}.txt");
                var firstGrade = double.Parse(openedFile.ReadLine());
            }
            catch(FileNotFoundException) {
                Console.WriteLine($"No such file exists with {Name}.txt");
                return false;
            }
            catch(FormatException)
            {
                Console.WriteLine($"No proper grades exists in {Name}.txt");
                return false;
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine($"File {Name}.txt is empty");
                return false;
            }
            return true;
        }
    }
}