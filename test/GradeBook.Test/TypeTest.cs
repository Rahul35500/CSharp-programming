using System;
using Xunit;

namespace GradeBook.Test
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTest
    {
        int Count=0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log=ReturnMessage;
            log+=ReturnMessage;
            log+=IncrementCount;
            var Result=log("hello");
            Assert.Equal(3,Count);
            Assert.Equal("hello",Result);
        }
        string IncrementCount(string Message)
        {
            Count++;
            return Message.ToLower();
        }
         string ReturnMessage(string Message)
        {
            Count++;
            return Message;
        }
         

        [Fact]
         public void StingBehavesLikesSring()
         {
             String name="rahul";
             MakeUpperCase(name);
           //  Assert.Equal("RAHUL",name);
         }

        private void MakeUpperCase(string parameter)
        {
            parameter.ToUpper();
        }

        [Fact]
        public void CanSetNameFromResource()
        {

            var book1 = GetBook("book1");
            SetNAme(book1, "new Name");

           // Assert.Equal("New Name", book1.Name);

        }

        private void SetNAme(InMemoryBook book, string name)
        {

            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObject()
        {
            var book1 = GetBook("book1");
            var book2 = GetBook("book2");

            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));


        }

        InMemoryBook GetBook(string name)
        {

            return new InMemoryBook(name);
        }
    }
}
