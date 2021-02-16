using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTest
    {
        [Fact]
        public void BookCalCulatesAnAverageGrade()
        {    
            var book=new InMemoryBook("");
            book.AddGrade(10.3);
            book.AddGrade(34.4);
            book.AddGrade(31.3);

            var result=book.GetStatistics();

            Assert.Equal(25.3, result.Average,1);
            Assert.Equal(34.4,result.High,1);
            Assert.Equal(10.3,result.Low,1);
        }
    }
}
