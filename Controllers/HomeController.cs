﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Summary()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Category = Context.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Task(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                Context.Add(ar);
                Context.SaveChanges(); //add and save movies to the database
                return View("Confirmation", ar); //return a confirmation page
            }
            else //if it is invalid
            {
                ViewBag.Category = Context.Category.ToList();
                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult Quadrant()
        {
            var applications = Context.Response
            .Include(x => x.Category)
            .Where(x => x.Edited == false)
            .OrderBy(x => x.Task)
            .ToList();

            return View(applications);
           
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            //get the record id
            var application = Context.Response.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            taskContext.responses.Remove(ar);
            taskContext.SaveChanges();
            return RedirectToAction("TaskList");
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = movieContext.categories.ToList(); //get the record info
            var application = movieContext.responses.Single(x => x.ApplicationId == applicationid);
            return View("Movies", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                taskContext.Update(ar);
                taskContext.SaveChanges();
                return RedirectToAction("TaskList");
            }
            else
            {
                ViewBag.Error = "Invalid values!";
                return View("Task", ViewBag.Error);
            }

        }
    }
}
