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
    public class DisciplineServiceTests
    {
        [TestMethod()]
        public void GetDisciplineBySpecializationAndYearTest()
        {
            //arrange 
            var specialization = "Calculatoare";
            var year = 2;
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetDisciplineByTeacherTest()
        {
            //arange
            var teacherID = 1;
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetDisciplineTest()
        {
            //arrange
            var ID = 1;
            Assert.IsTrue(true);
        }
    }
}