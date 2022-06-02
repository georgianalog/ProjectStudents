using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStudents.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudents.Services.Concrete.Tests
{
    [TestClass()]
    public class LearnServiceTests
    {
        [TestMethod()]
        public void GetTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetByDisciplineTest()
        {
            var disciplineID = 1;
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetByStudentTest()
        {
            var studentID = 1;
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.IsTrue(true);
        }
    }
}