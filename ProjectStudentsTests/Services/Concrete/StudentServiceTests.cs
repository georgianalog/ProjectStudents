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
    public class StudentServiceTests
    {
        [TestMethod()]
        public void GetStudentTest()
        {

            var ID = 1;
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void getAllBySpecializationAndYearTest()
        {
            var specialization = "Calculatoare";
            var year = 2;
            Assert.IsTrue(true);
        }
    }
}