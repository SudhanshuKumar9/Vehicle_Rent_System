using NUnit.Framework;
using Moq;
using VehicleWebApi.Controllers;
using VehicleWebApi.Model;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using VehicleWebApi.Repo;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VehicleApiTest
{
    public class Tests
    {
        List<Vehicle> vehicle = new List<Vehicle>
        {
             new Vehicle{VehicleID=1,Vehicle_Type="SUV",Cost_Per_Km=10,No_of_Seats=6,Number_InStock=10},
                new Vehicle{VehicleID=2,Vehicle_Type="Sedan",Cost_Per_Km=10,No_of_Seats=4,Number_InStock=5}

        };
        private Mock<IRepository> mockSet;
        private VehicleController con;

        [SetUp]
        public void Setup()
        {
            mockSet = new Mock<IRepository>();
            con = new VehicleController(mockSet.Object);
        }

        [Test]
        public void Get_All_Vehicles_Test()
        {
            mockSet.Setup(m => m.GetVehicles()).Returns(vehicle);

            var res = con.GetAllVehicles();

            Assert.AreEqual(res.Count(), vehicle.Count());

        }

        [Test]
        public void Get_All_Vehicles_Failed_Test()
        {
            mockSet.Setup(m => m.GetVehicles()).Returns(vehicle);

            var res = con.GetAllVehicles();

            Assert.AreNotEqual(res.Count()-1, vehicle.Count());

        }

        [TestCase(1)]
        [TestCase(2)]
        public void Get_Vehicle_By_Id_Test(int id)
        {
            mockSet.Setup(m => m.GetVehicle(id)).Returns(vehicle[0]);
            var res = con.GetVehicle(id) as OkObjectResult;
            Assert.AreEqual(200,res.StatusCode);
        }

    }
}