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
            const string path = "C:/Users/Ajay kumar/Desktop/Sample.csv";
            Assert.True(PathChecker.DoesPathExists(path));
        }
        [Fact]
        public void WhenNonExistingPathIsGivenToDoesPathExistReturnFalse()
        {
            const string path = "C:/Users/Desktop/Sample.csv";
            Assert.False(PathChecker.DoesPathExists(path));
        }
    }
}
