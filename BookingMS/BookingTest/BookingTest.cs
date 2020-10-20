using NUnit.Framework;
using Moq;
using BookingMS.Model;
using System.Collections.Generic;
using System;
using BookingMS.Repo;
using BookingMS.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BookingTest
{
    public class Tests
    {
        
        List<Booking> booking = new List<Booking>
        {
            new Booking{BookingID=1,Date_of_Booking=DateTime.Parse("2020-10-01"),Total_Fare=500,Total_Km=10,Username="user",VehicleID=1},
            new Booking{BookingID=2,Date_of_Booking=DateTime.Parse("2020-10-01"),Total_Fare=500,Total_Km=15,Username="james",VehicleID=2}
        };
        Mock<IBookRepository> mockSet;
        BookingController con;
        [SetUp]
        public void Setup()
        {
            mockSet = new Mock<IBookRepository>();
            con = new BookingController(mockSet.Object);
            
        }

        [Test]
        public void Get_Booking_Details_Test()
        {
            
            mockSet.Setup(m => m.GetAllBookings("user")).Returns(booking.Where(b=>b.Username=="user").ToList());
            var data=con.GetAllBooking("user") as ObjectResult;
            Assert.AreEqual(200, data.StatusCode);
            //var data = con.GetAllBooking("user");
            //Assert.IsInstanceOf<ActionResult<IEnumerable<Booking>>>(data);
        }

        [Test]

        public void Save_Booking_Test()
        {
            Booking book = new Booking()
            {
                BookingID = 2, 
                Date_of_Booking = DateTime.Parse("2020-10-01"), 
                Total_Fare = 500, 
                Total_Km = 15, 
                Username = "james", 
                VehicleID = 2
            };
            mockSet.Setup(m => m.SaveBooking(book));
           
            var data = con.SaveBooking(book);
            Assert.IsNotNull(data);
        }
    }
}