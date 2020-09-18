using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sender;
using Xunit;

namespace SenderTests
{
    public class PathCheckerTests
    {
        [Fact]
        public void WhenExistingPathIsGivenToDoesPathExistReturnTrue()
        {
            const string path = "https://raw.githubusercontent.com/ajay300898/review-case-s21b1/master/Sample.csv";
            Assert.True(PathChecker.DoesPathExists(path));
        }
        [Fact]
        public void WhenNonExistingPathIsGivenToDoesPathExistReturnFalse()
        {
            const string path = "/Sample1.csv";
            Assert.False(PathChecker.DoesPathExists(path));
        }
    }
}
