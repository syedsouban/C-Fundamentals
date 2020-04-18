using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        public delegate string WriteLogDelegate(string message);
        int count = 0;

        [Fact]
        public void DelegateTest()
        {
            WriteLogDelegate log;
            log = getMessage;
            log+=getLowerStringMessage;
            var result = log("Hello!");
            Console.WriteLine(result);
            // Assert.Equal("Hello!",result);
            Assert.Equal(2,count);
        }
        public string getMessage(string message)
        {
            count++;
            return message;
        }

        public string getLowerStringMessage(string message)
        {
            count++;
            return message.ToLower();
        }

        //[Fact] is an attribute used to represent a particular function as a unit test
        [Fact]
        public void Test1()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
        }

        [Fact]
        public void Test2()
        {
            //book1 and book2 are references that point to the same object
            var book1 = GetBook("Book 1");
            var book2 = book1;
            Assert.Same(book1,book2);
        }

        [Fact]
        public void Test3()
        {
            var book1 = GetBook("Book 1");
            SetName1(book1,"New Name");
            
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName1(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void Test4()
        {
            var book1 = GetBook("Book 1");
            SetName2(book1,"New Name");
            
            Assert.Equal("Book 1",book1.Name);
        }

        private void SetName2(InMemoryBook book, string name)
        {
            book=new InMemoryBook(name);
        }


        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
