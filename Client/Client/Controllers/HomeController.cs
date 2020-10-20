using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if user is not authorize then return
            //login page

            //else return user Index Page
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login([FromForm] UserLogin user)
        {
            //Authenticate user with username and password
            //and store token in seesion variable
            //HttpContext.Session.SetString("")


            string token = GetToken("http://localhost:62606/api/Auth/Login", user);

            if(token!=null)
            {
                HttpContext.Session.SetString("JWTtoken", token);
                HttpContext.Session.SetString("Name", user.Username);
                ViewBag.Login = user.Username;
                return RedirectToAction("Index","User");
            }

            ModelState.Clear();
            ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
            return View();
        }

        public string GetToken(string url, UserLogin user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;

            string name = response.Content.ReadAsStringAsync().Result;
            dynamic details = JObject.Parse(name);
            return details.token;
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
