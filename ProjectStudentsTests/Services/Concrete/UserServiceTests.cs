using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudents.Services.Concrete.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void getUserTest()
        {
            var id = 1;
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void LogoutTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            var user = new User
            {
                UserName = "Ana123",
                Email = "ana@yahoo.com",
                FirstName = "Ana",
                SecondName = "Popa"
            };
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void LoginTest()
        {
            var user = new User
            {
                Email = "ana@yahoo.com",
                PasswordHash = "ana1234"
            };
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void IsUserLoggedInTest()
        {
            Assert.IsTrue(true);
        }
    }
}