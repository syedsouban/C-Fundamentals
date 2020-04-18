using System;
namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        //virtual keyword is a way of saying that here is a method which the child class may override
        public abstract event InMemoryBook.GradeAddedDelegate GradeAdded;
        public abstract Statistics GetStatistics();

        // abstract method is implicitly virtual
        public abstract void AddGrade(double grade);
        public abstract bool HasGrades();
    }
}



