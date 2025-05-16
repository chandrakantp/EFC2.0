
using EFC2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFC2.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly EntitiesContext _context;
        public AttendanceController(EFC2.Models.EntitiesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCalendarAttendanceData(DateTime start, DateTime end, string daterange, DateTime datepicker, DateTime? datepicker2)
        {
            if (!string.IsNullOrEmpty(daterange))
            {
                var dates = daterange.Split('-');
                if (dates.Length == 2)
                {
                    datepicker = DateTime.Parse(dates[0].Trim());
                    datepicker2 = DateTime.Parse(dates[1].Trim());
                }
            }
            else
            {
                datepicker = start;
                datepicker2 = (end > DateTime.Now) ? DateTime.Now : end;
            }

            int? empid = HttpContext.Session.GetInt32("EmpID");
            if (empid == null)
                return RedirectToAction("Index", "Home");

            var emp = _context.Emp
                .Where(m => m.EmpID == empid)
                .Select(m => new { m.EmpID, m.IsNightShift })
                .FirstOrDefault();

            if (emp == null)
                return NotFound("Employee not found.");

            var param1 = new SqlParameter("@fromDate", datepicker);
            var param2 = new SqlParameter("@toDate", datepicker2);
            var param3 = new SqlParameter("@empid", emp.EmpID);
            var param4 = new SqlParameter("@deptname", "");
            var today = DateTime.Today;

            var data = _context.AttendanceProcedure_from_essl_final
                .FromSqlRaw("AttendanceProcedure_from_essl_final @fromDate,@toDate,@empid,@deptname", param1, param2, param3, param4)
                .AsEnumerable()
                .Where(a => a.ThatDay.Date == today)
                .Select(a =>
                {
                    TimeSpan spentOutTime = TimeSpan.TryParse(a.Spent_Out_Time?.ToString(), out var sot) ? sot : TimeSpan.Zero;
                    TimeSpan actualWorking = TimeSpan.TryParse(a.Actual_Working_Hours?.ToString(), out var awh) ? awh : TimeSpan.Zero;

                    return new
                    {                       
                        ChekIn = a.ChekIn ?? TimeSpan.Zero,
                        ChekOut = a.ChekOut ?? TimeSpan.Zero,                        
                        Spent_Out_Time = spentOutTime,
                        Actual_Working_Hours = actualWorking,
                    };
                })
                .ToList();

            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetMonthlyAttendanceData(int month)
        {
            int? empId = HttpContext.Session.GetInt32("EmpID");
            if (empId == null)
                return Unauthorized();

            int year = DateTime.Today.Year;
            int currmonth = DateTime.Today.Month;

            // Calculate fromDate as 26th of the previous month of the selected month
            DateTime fromDate = new DateTime(year, month, 1).AddMonths(-1).AddDays(25);
            DateTime toDate = (currmonth == month) ? DateTime.Today : new DateTime(year, month, 24);

            var param1 = new SqlParameter("@fromDate", fromDate);
            var param2 = new SqlParameter("@toDate", toDate.AddDays(-1));
            var param3 = new SqlParameter("@empid", empId);
            var param4 = new SqlParameter("@deptname", "");

            var data1 = _context.AttendanceProcedure_from_essl_final
                        .FromSqlRaw("EXEC AttendanceProcedure_from_essl_final @fromDate, @toDate, @empid, @deptname",
                            param1, param2, param3, param4)
                        .AsEnumerable();

            var atsheetModel = data1.Select(a => new
            {
                EmployeeName = a.employeeCode + ": " + a.EmployeeName,
                EmployeeCode = a.employeeCode,
                ThatDayStatus = a.ThatDayStatus,
                LeaveDays = a.LeaveDays,
                HolidayStatus = a.HolidayStatus,
                checkin =a.ChekIn,
                checkout =a.ChekOut,
                tttime = a.TotalTime,
            }).ToList();

            var presentCount = atsheetModel.Count(x => x.ThatDayStatus == "Present");
            var HolidayStatus = atsheetModel.Count(x => x.HolidayStatus == "Weekend" || x.HolidayStatus == "Holiday");
            var absentCount = atsheetModel.Count(x => string.IsNullOrEmpty(x.HolidayStatus) && x.checkin ==null && x.checkout==null);
            var leaveCount = atsheetModel.Count(x => x.LeaveDays.HasValue && x.LeaveDays.Value > 0);

            var partialpresent = atsheetModel.Count(x =>
                                x.tttime.HasValue &&
                                x.tttime.Value > TimeSpan.Parse("06:00:00") &&
                                x.tttime.Value < TimeSpan.Parse("09:00:00")
                            );

            var lesshour = atsheetModel.Count(x => x.tttime.HasValue && x.tttime.Value > TimeSpan.Zero && x.tttime.Value < TimeSpan.Parse("06:00:00"));

            return Json(new
            {
                Present = (presentCount + HolidayStatus)-(partialpresent + lesshour + absentCount),
                Absent = absentCount + lesshour,
                Leave = leaveCount,
                partialpresent = partialpresent,
            });
        }


        [HttpGet]
        public IActionResult GetLeaveStatusCounts(string year)
        {
            int? empId = HttpContext.Session.GetInt32("EmpID");
            if (empId == null)
                return Unauthorized();

            int parsedYear = DateTime.Now.Year;
            if (!string.IsNullOrEmpty(year) && int.TryParse(year, out var y))
                parsedYear = y;

            var approvedSum = _context.LeaveRequest
                .Where(s => s.EmpID == empId && s.Approved == true && s.StartDate.Year == parsedYear)
                .Sum(s => s.totalCounts);

            var rejectedSum = _context.LeaveRequest
                .Where(s => s.EmpID == empId && s.Approved == false && s.StartDate.Year == parsedYear)
                .Sum(s => s.totalCounts);

            var pendingSum = _context.LeaveRequest
                .Where(s => s.EmpID == empId && s.Approved == null && s.StartDate.Year == parsedYear)
                .Sum(s => s.totalCounts);

            return Json(new
            {
                Approved = approvedSum,
                Pending = pendingSum,
                Rejected = rejectedSum
            });
        }




        [HttpGet]
        public IActionResult GetLeaveSummary()
        {
            int? empId = HttpContext.Session.GetInt32("EmpID");
            if (empId == null)
                return Unauthorized();

            // Load required data first from the database
            var leaveTypes = _context.LeaveType.ToList();
            var leaveAllocations = _context.LeaveAllocation
                .Where(x => x.EmpID == empId)
                .ToList();

            var leaveRequests = _context.LeaveRequest
                .Where(x => x.EmpID == empId)
                .Select(x => new
                {
                    x.LeaveTypeID,
                    x.totalCounts,
                    x.Approved
                })
                .ToList();

            // Now do the grouping and calculations in memory
            var result = leaveTypes.Select(lt =>
            {
                var allocations = leaveAllocations.Where(la => la.LeaveTypeID == lt.Id);
                var requests = leaveRequests.Where(lr => lr.LeaveTypeID == lt.Id);

                return new
                {
                    LeaveType = lt.Name,
                    taken = requests.Sum(x => x.totalCounts),
                    Granted = requests.Where(x => x.Approved == true).Sum(x => x.totalCounts ),
                    Balance = allocations.Sum(x => x.NumberOfDays)
                };
            }).ToList();

            return Json(result);
        }



    }
}