
using EFC2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFC2.Controllers
{
    public class HomeController : Controller
    {

        private readonly EntitiesContext _context;
        public HomeController(EFC2.Models.EntitiesContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Login(string DBMREmpID, string password)
        {
            // Load User + Employee in a single step where possible
            var user = _context.User
                .FirstOrDefault(jj => (jj.DBMREmpID == DBMREmpID || jj.Email == DBMREmpID) && jj.Password == password);

            if (user == null) return "Incorect Username or password";

            var emp = _context.Emp
                .Where(jj => (jj.DBMREMPID == DBMREmpID || jj.OfficialMailID == DBMREmpID) && jj.IsActive == true)
                .Select(jj => new
                {
                    jj.EmpID,
                    DbmrID = jj.DBMREMPID,
                    jj.EmpTypeID,
                    jj.PareentEmpID,
                    jj.FirstName,
                    jj.Department,
                    jj.Designation,
                    jj.AttEmp
                })
                .FirstOrDefault();

            if (emp == null) return "Incorect Username or password";

            string dbmrid_remove_dbmr = emp.DbmrID.Length > 4 ? emp.DbmrID.Substring(4) : emp.DbmrID;

            // Set session
            HttpContext.Session.SetString("Department", emp.Department);
            HttpContext.Session.SetString("Designation", emp.Designation);
            HttpContext.Session.SetString("EmpName", emp.FirstName);
            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetInt32("EmpID", emp.EmpID);
            HttpContext.Session.SetInt32("AttEmp", emp.AttEmp);
            HttpContext.Session.SetString("userEmail", user.Email);
            HttpContext.Session.SetString("userPassword", user.Password);

            HttpContext.Session.Remove("day_startedFrom");

            // Efficient login check
            bool alreadyLoggedIn = _context.UserLoginLogout
                .Any(aa => aa.isLogedIn == true && aa.empID == emp.EmpID);

            if (alreadyLoggedIn)
            {
                HttpContext.Session.SetString("day_startedFrom", DateTime.Now.ToString());
            }

            var today = DateTime.Today;

            // Efficient check in DeviceLogs
            bool logExists = _context.DeviceLogs
                .Any(a => a.LogDate.HasValue &&
                          a.LogDate.Value.Date == today &&
                          a.UserId == dbmrid_remove_dbmr &&
                          (a.C3 == "DirectEntry" || a.C3 == null));

            if (logExists)
            {
                HttpContext.Session.SetString("day_loginEssl", "esslLoginFirst");
            }

            return "Login has successfully";
        }


    }
}