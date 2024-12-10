using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyPortal.Models;

namespace MyPortal.Controllers
{
    public class DashboardController : Controller
    {
        private static List<JobListing> jobListings = new List<JobListing>
        {
            new JobListing { Id = 1, Title = "Software Engineer", Location = "New York", Company = "TechCorp" },
            new JobListing { Id = 2, Title = "Data Analyst", Location = "San Francisco", Company = "DataWorks" },
            new JobListing { Id = 3, Title = "Product Manager", Location = "Seattle", Company = "Innovate Inc." }
        };

        public ActionResult Index()
        {
            ViewBag.UserName = Session["UserEmail"];
            ViewBag.JobListings = jobListings;
            return View("~/Views/Home/Dashboard.cshtml");
        }

        // Admin: Add Job
        [HttpPost]
        public ActionResult AddJob(JobListing newJob)
        {
            newJob.Id = jobListings.Count > 0 ? jobListings.Max(j => j.Id) + 1 : 1;
            newJob.PostedDate = DateTime.Now;
            jobListings.Add(newJob);
            return RedirectToAction("Index");
        }

        // Admin: Delete Job
        public ActionResult DeleteJob(int id)
        {
            var jobToDelete = jobListings.FirstOrDefault(j => j.Id == id);
            if (jobToDelete != null)
                jobListings.Remove(jobToDelete);

            return RedirectToAction("Index");
        }

        // Admin: Edit Job
        [HttpPost]
        public ActionResult EditJob(JobListing updatedJob)
        {
            var existingJob = jobListings.FirstOrDefault(j => j.Id == updatedJob.Id);
            if (existingJob != null)
            {
                existingJob.Title = updatedJob.Title;
                existingJob.Location = updatedJob.Location;
                existingJob.Company = updatedJob.Company;
                existingJob.Salary = updatedJob.Salary;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {
            ViewBag.JobListings = jobListings; // Pass the job listings to the admin view
            return View();
        }
        public ActionResult Apply
            ()
        {
            return View();
        }

    }
}
