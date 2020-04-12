using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PiWeb.Models;

namespace PiWeb.Controllers
{

    public class HomeController : Controller
    {
        private string testValue = "NotSet";
        public HomeController(IConfiguration config)
        {
            testValue = config["testvalue"];

        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(new IndexViewModel() { TestValue = testValue });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class IndexViewModel
    {
        public string TestValue { get; set; }
    }
}
