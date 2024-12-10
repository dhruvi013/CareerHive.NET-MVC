using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MyPortal.Controllers
{
    public class AccountController : Controller
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["JobPortalDB"].ToString();

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(string fullName, string email, string phoneNumber, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO UserAccounts (FullName, Email, Password, PhoneNumber) " +
                                   "VALUES (@FullName, @Email, @Password, @PhoneNumber)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Ideally, hash the password before saving
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Registration failed. Please try again.";
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and Password are required.";
                return View();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM UserAccounts WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Consider hashing the password before checking
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count>0)
                        {
                            // Login successful
                            Session["UserEmail"] = email; // Store email in session
                            return RedirectToAction("Index", "Dashboard"); // Redirect to Dashboard
                        }
                        else
                        {
                            // Invalid credentials
                            ViewBag.ErrorMessage = "Invalid email or password.";
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // Logout action
        public ActionResult Logout()
        {
            Session.Abandon(); // Clear session
            return RedirectToAction("Login", "Account"); // Redirect to login
        }
    }
}
