using NUnit.Framework;
using Projekt_s16696.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NUnitTestProject1
{

    [TestFixture]
    class ClientUnitTest
    {

        //reg
        [Test]
        public void AddClient_Corrent()
        {
            RegisterRequest request = new RegisterRequest
            {
                FirstName = "Stefan",
                LastName = "Ącki",
                Email = "email",
                Phone = "23456512",
                Login = "stefanek",
                Password = "Pass"
            };

            var con = new ValidationContext(request, null, null);
            var res = new List<ValidationContext>();

            Assert.IsTrue(Validator.TryValidateObject(request, con, (ICollection<ValidationResult>)res, true));
        }

        [Test]
        public void AddClient_error()
        {
            RegisterRequest request = new RegisterRequest
            {
                FirstName = "Stefan",
                LastName = "Ącki",
                Email = "email",
                Phone = "23456512"
            };

            var con = new ValidationContext(request, null, null);
            var res = new List<ValidationContext>();

            Assert.IsFalse(Validator.TryValidateObject(request, con, (ICollection<ValidationResult>)res, true));
        }

        //login
        [Test]
        public void userExists()
        {
            LoginRequest request = new LoginRequest { Login = "root", Password = "pass" };
            var con = new ValidationContext(request, null, null);
            var res = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(request, con, res, true));

        }

        [Test]
        public void userNotExists()
        {
            LoginRequest request = new LoginRequest { Login = "asdasd" };
            var con = new ValidationContext(request, null, null);
            var res = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(request, con, res, true));

        }
    }
}
