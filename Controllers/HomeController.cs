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
        private ApplicationContext ApplicationContext { get; set; }

        public HomeController(ApplicationContext someName)
        {
            ApplicationContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        //This is the extrapage that links to the Stephen Corvey's Hompage
        public IActionResult Summary()
        {
            return View();
        }

        //Directs to the Task page in the View folder to create tasks 
        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Category = ApplicationContext.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Task(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext.Add(ar);
                ApplicationContext.SaveChanges(); //add and save movies to the database
                return View("Confirmation", ar); //return a confirmation page
            }
            else //if it is invalid
            {
                ViewBag.Category = ApplicationContext.Category.ToList();
                return View(ar);
            }
        }

        // Directs to the Quadrant page in the View folder to see the list of the tasks in the quadrant 
        [HttpGet]
        public IActionResult Quadrant()
        {
            var applications = ApplicationContext.Response
            .Include(x => x.CategoryName)
            .Where(x => x.Completed == false)
            .OrderBy(x => x.Task)
            .ToList();

            return View(applications);
           
        }


        // CRUD - Deletion Part 
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            //get the record id
            var application = ApplicationContext.Response.Single(x => x.TaskId == taskid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            ApplicationContext.Response.Remove(ar);
            ApplicationContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        // CRUD - Edit/Update Part 
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Category = ApplicationContext.Category.ToList(); //get the record info
            var application = ApplicationContext.Response.Single(x => x.TaskId == taskid);
            return View("Task", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext.Update(ar);
                ApplicationContext.SaveChanges();
                return RedirectToAction("Quadrant");
            }
            else
            {
                ViewBag.Error = "Invalid values!";
                return View("Task", ViewBag.Error);
            }

        }

        // When the user presses Completed button, change the task status to (completed:true) and delete from the quadrant list. 
        public IActionResult MarkComplete(int taskId)
        {
            // get a single data by its taskId
            var record = ApplicationContext.Response.Single(x => x.TaskId == taskId);

            // change its completed as true
            record.Completed = true;
            ApplicationContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }
    }
}
