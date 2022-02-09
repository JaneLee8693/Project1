using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext Context { get; set; }

        public HomeController(ApplicationContext someName)
        {
            Context = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Applications()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Applications(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else //If Invalid
            {
                return View();
            }

        }

    }
}
