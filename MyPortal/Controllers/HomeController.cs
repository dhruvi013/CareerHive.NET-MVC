using MyPortal.Models;  // Ensure you're using the correct namespace for JobListing
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyPortal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index (Landing page)
        public ActionResult Index()
        {
            if (Session["UserEmail"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.UserEmail = Session["UserEmail"];
            return View();
        }

        // GET: Home/Homepage
        public ActionResult Homepage()
        {
            return View();
        }

        // GET: Home/Dashboard
        public ActionResult Dashboard()
        {
            // Ensure the user is logged in
            if (Session["UserEmail"] == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to Login if not authenticated
            }

            // Example data for job listings (replace with actual database data if needed)
            List<JobListing> jobListings = new List<JobListing>
            {
                new JobListing { Title = "Software Engineer", Location = "New York", Company = "TechCorp" },
                new JobListing { Title = "Data Analyst", Location = "San Francisco", Company = "DataWorks" },
                new JobListing { Title = "Product Manager", Location = "Seattle", Company = "Innovate Inc." }
            };

            ViewBag.UserName = Session["UserEmail"];
            ViewBag.JobListings = jobListings;

            return View(); // Return Dashboard view
        }

        // GET: Home/LoginPage (this is where users will be redirected for login)
        public ActionResult LoginPage()
        {
            return View();
        }

        // POST: Home/LoginPage (when users submit their login details)
        [HttpPost]
        public ActionResult LoginPage(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and Password are required.";
                return View();
            }

            // Simulate the login process (replace with actual login logic)
            if (email == "test@example.com" && password == "password")
            {
                Session["UserEmail"] = email;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials.";
                return View();
            }
        }

        // GET: Home/Logout (logout action)
        public ActionResult Logout()
        {
            Session.Abandon(); // Ends the session
            return RedirectToAction("LoginPage", "Home"); // Redirect to login page
        }

        // GET: Home/Contact (Example of another page)
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Home/About (Example of another page)
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
    }
}
