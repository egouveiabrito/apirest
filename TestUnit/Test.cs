using System;
using System.Net;
using System.Net.Http;
using API.User.Util;
using Entity;
using Entity.Entities;
using Entity.Interfaces.Repositories;
using Entity.Interfaces.Services;
using Entity.Services;
using Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUnit.Util;

namespace TestUnit
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestSignup()
        {
            UserRepository repository = new UserRepository();
            IUserService service = new UserService(repository);

            User user = new User();
            user.firstName = GanerateTest.GenerateName();
            user.lastName = "da Silva";
            user.email = GanerateTest.Email();
            user.password = "@12345";

            for (int index = 0; index <= 10; index++)
            {
                Phones phones = new Phones();
                phones.number = GanerateTest.NumberPhone();
                phones.area_code = "81";
                phones.country_code = "+55";
                user.phones.Add(phones);
            }
            user = service.Signup(user);
        }

        [TestMethod]
        public void TestSignin()
        {
            UserRepository repository = new UserRepository();
            IUserService service = new UserService(repository);

            Login login = new Login();
            login.email = "edson.de.brito@teste.com";
            login.password = "@12345";
            var mensagem = service.Signin(login);
        }
    }
}
