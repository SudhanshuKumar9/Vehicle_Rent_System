using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using AuthenticateApi.Models;
using AuthenticateApi.Repos;
using System.Linq;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AuthenticateApi.Controllers;
using AuthenticateApi.LoginModel;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace AuthApiTest
{
    public class Tests
    {
        List<User> user = new List<User>
        {
            new User{Username="user",Name="James",Contact_Number=123456,Password="abcfg"}
        };
        Mock<UserRepository> mockSet;
        Mock<IConfiguration> config;
        AuthController con;
        [SetUp]
        public void Setup()
        {
            mockSet = new Mock<UserRepository>();
            config = new Mock<IConfiguration>();
            con = new AuthController(mockSet.Object,config.Object);
           
        }


        [Test]
        public void LoginTest()
        {
            mockSet.Setup(m => m.GetUser(new UserLogin { Username = "user", Password = "abcfg" })).Returns(user[0]);
            config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
            var data = con.Login(new UserLogin { Username = "user", Password = "abcfg" }) as ObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }

    }
}