namespace GradeBook
{
    public interface IBook
    {
         void AddGrade(double grade);
         Statistics GetStatistics();
         
         event InMemoryBook.GradeAddedDelegate GradeAdded;
    }
}