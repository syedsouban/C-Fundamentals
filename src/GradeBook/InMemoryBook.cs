using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
            this.Name = name;
        }
        private List<double> Grades;

        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        //events are mostly used in gui programming in dot net for event driven programming
        public override event GradeAddedDelegate GradeAdded;

        readonly string category;
        // private string name;

        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if(!String.IsNullOrEmpty(value))
        //             name = value;
        //         else
        //             throw new ArgumentNullException("Book name cannot be null or empty");        
        //     }
        // }

        
        public override bool HasGrades()
        {
            return Grades.Count > 0;
        }

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            foreach (var grade in Grades)
            {
                stats.Add(grade);
            }
            return stats;
        }

        public override void AddGrade(double grade)
        {

            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

            else
            {
                throw new ArgumentException("Grade should be between 0 and 100 inclusive");
            }
        }
    }
}