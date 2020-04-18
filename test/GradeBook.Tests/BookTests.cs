using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        //[Fact] is an attribute used to represent a particular function as a unit test
        [Fact]
        public void BookCalculatesStats()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(65);
            book.AddGrade(78);
            book.AddGrade(45);


            // act
            var stats = book.GetStatistics();
            var avg = stats.average;
            var high = stats.highest;
            var low = stats.lowest;


            // assert(expected,actual)
            Assert.Equal((65+78.0+45)/3,avg);
            Assert.Equal(78,high);
            Assert.Equal(45,low);
        }
    }
}
