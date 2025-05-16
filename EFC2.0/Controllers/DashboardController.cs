
using EFC2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFC2.Controllers
{
    public class DashboardController : Controller
    {

        private readonly EntitiesContext _context;
        public DashboardController(EFC2.Models.EntitiesContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetLeaveBalance()
        {
            int? empId = HttpContext.Session.GetInt32("EmpID");
            if (empId == null)
            {
                return BadRequest("Session expired or user not logged in.");
            }

            var result = _context.LeaveAllocation
                .Where(l => l.EmpID == empId)
                .GroupBy(l => l.LeaveType.Name)
                .Select(g => new
                {
                    LeaveType = g.Key, // This will be string (name only)
                    Balance = g.Sum(x => x.NumberOfDays)
                })
                .ToList();

            return Json(result);
        }


        [HttpGet]
        public IActionResult GetLatestAnnouncements()
        {
            var announcements = _context.DbmrAnnouncement
                .Where(s=>s.IsActive==true)                
                .OrderByDescending(a => a.DbmrAnnouncementID)
                .Take(10)
                .Select(a => new
                {
                    Title = a.AnnounceTitle,
                    CreatedDate = a.CreatedDate
                })
                .ToList();

            return Json(announcements);
        }

        [HttpGet]
        public IActionResult GetHolidayList()
        {
            var firstDayOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var thismonth = DateTime.Now.Month;

            var holidays = _context.Holidays
                .Where(h => h.isOptional == true && h.date.Value.Month == thismonth)
                .OrderBy(h => h.date)
                .Select(h => new
                {
                    holidayName = h.holidayName,
                    date = h.date,
                    resion = h.resion // Typo? Should be "region"
                })
                .Take(3) // Get top 3 upcoming holidays only
                .ToList();

            return Json(holidays);
        }

        [HttpGet]
        public IActionResult GetBirthdays()
        {
            var today = DateTime.Today;
            var result = _context.Emp
                .Where(e => e.IsActive == true &&
                            e.DOB.HasValue &&
                            e.DOB.Value.Month == today.Month &&
                            e.DOB.Value.Day == today.Day)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    DOB = e.DOB,
                    photo = e.Photo
                })
                .ToList();

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetAnniversaries()
        {
            var today = DateTime.Today;
            var result = _context.Emp
                .Where(e => e.IsActive == true &&
                            e.DOJ.HasValue &&
                            e.DOJ.Value.Month == today.Month &&
                            e.DOJ.Value.Day == today.Day)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    DOJ = e.DOJ,
                    YearsCompleted = today.Year - e.DOJ.Value.Year
                })
                .ToList();

            return Json(result);
        }

        

    }
}