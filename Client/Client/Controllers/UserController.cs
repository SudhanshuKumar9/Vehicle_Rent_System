using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using Client.ViewModel;
using System.Net;

namespace Client.Controllers
{
    public class UserController : Controller
    {

        private static int vid;
        // GET: UserController1

        public bool CheckValid()
        {
            if (HttpContext.Session.GetString("JWTtoken") != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet]

        public ActionResult Index()
        {
            if (CheckValid())
            {
                ViewBag.Name = HttpContext.Session.GetString("Name");
                return View();
            }
            return RedirectToAction("Index","Home");
        }

        // GET: UserController1/Details/5
        [HttpGet]
        public ActionResult VehicleDetails()
        {
            if (CheckValid())
            {
                var vehicles = ListOfVehicle();
                return View(vehicles);
            }

            return RedirectToAction("Index", "Home");

        }


        //Get list of vehicle from vehicle api using httpclient
        public List<Vehicle> ListOfVehicle()
        {
            List<Vehicle> v = new List<Vehicle>();

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:63674/api/")
            };
            var response = client.GetAsync("Vehicle").Result;
            var data = response.Content.ReadAsStringAsync().Result;

            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(data);

            foreach (var i in vehicles)
            {
                v.Add(i);
            }

            return v;
        }


        [HttpGet]
        public ActionResult BookVehicle(int id)
        {
            if (CheckValid())
            {
                vid = id;
                return View();
            }

            return RedirectToAction("Index", "Home");
           
        }

        [HttpPost]
        public ActionResult SaveBooking([FromForm] Booking book)
        {
            Booking booking = new Booking()
            {
                VehicleID = vid,
                Username = HttpContext.Session.GetString("Name"),
                Total_Km = book.Total_Km,
                Date_of_Booking = book.Date_of_Booking
            };
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63674/");
                var response = client.GetAsync("api/Vehicle/" + booking.VehicleID).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var vehicle = JsonConvert.DeserializeObject<Vehicle>(data);
                booking.Total_Fare = vehicle.Cost_Per_Km * booking.Total_Km;

            }

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:62606/api/Auth/");
            //    var response = client.GetAsync("" +HttpContext.Session.GetString("Name")).Result;
            //    var data = response.Content.ReadAsStringAsync().Result;
            //    var user = JsonConvert.DeserializeObject<User>(data);
            //    booking.User = user;
            //}


            var json = JsonConvert.SerializeObject(booking);
            var datas = new StringContent(json, Encoding.UTF8, "application/json");

            //var jsonforVid = JsonConvert.SerializeObject(vid);
            //var dataforVid = new StringContent(jsonforVid, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59816/");
                var response = client.PostAsync("api/Booking", datas).Result;
                if(response.IsSuccessStatusCode)
                    using(var newclient =new HttpClient())
                    {
                        newclient.BaseAddress = new Uri("http://localhost:63674/");
                        var newresponse = newclient.GetAsync("api/Vehicle/"+vid).Result;
                    }

                //ModelState.AddModelError(string.Empty,"boo")
                return View("SuccessFull");
            }

        }

       

        public ActionResult<IEnumerable<Booking>> BookingDetails()
        {
            if(CheckValid())
            {
                var book = GetListOfBooking();


                return View(book);
            }

            return RedirectToAction("Index", "Home");
            
            
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("JWTtoken");
            
            

            return RedirectToAction("Index", "Home");
        }

        public List<BookingViewModel> GetListOfBooking()
        {
            List<BookingViewModel> book = new List<BookingViewModel>();
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:59816/api/")
            };
            var response = client.GetAsync("Booking/" + HttpContext.Session.GetString("Name")).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            var booking = JsonConvert.DeserializeObject<List<BookingViewModel>>(data);

            foreach (var i in booking)
            {
                book.Add(i);
            }

            return book;
        }
    }
}
