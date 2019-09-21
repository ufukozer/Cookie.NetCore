using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append("test1", "valueOfTest1", cookieOptions);
            return View();
        }

        public IActionResult About()
        {
            Response.Cookies.Delete("test1");
            string x = Request.Cookies["test1"];
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
}
