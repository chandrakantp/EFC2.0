using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2.Models
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options)
        { }

        public DbSet<Media> Media { get; set; }
        public DbSet<Emp> Emp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // First relationship: Emp → PareentEmp
            modelBuilder.Entity<Emp>()
                .HasOne(e => e.PareentEmp)
                .WithMany()
                .HasForeignKey(e => e.PareentEmpID)
                .OnDelete(DeleteBehavior.Restrict);

            // Second relationship: Emp → TwoStepEmp
            modelBuilder.Entity<Emp>()
                .HasOne(e => e.TwoStepEmp)
                .WithMany()
                .HasForeignKey(e => e.TwoStepEmpID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AttendanceProcedure_from_essl_final>()
               .HasKey(e => new { e.StaffId, e.ThatDay });
        }


        public DbSet<EmpDocument> EmpDocument { get; set; }
        public DbSet<AssetsMgt> AssetsMgt { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Dept> Dept { get; set; }
        public DbSet<DeptQuery> DeptQuery { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<StatusMaster> StatusMaster { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }
        public DbSet<StarPerformar> StarPerformar { get; set; }
        public DbSet<DBMRActivity> DBMRActivity { get; set; }
        public DbSet<DbmrCsr> DbmrCsr { get; set; }
        public DbSet<LeaderShepTeam> LeaderShepTeam { get; set; }

        //HRMS
        public DbSet<UserLoginLogout> UserLoginLogout { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocation { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<RestrictedHolidays> RestrictedHolidays { get; set; }
        public DbSet<OptionalHolidays> OptionalHolidays { get; set; }
        public DbSet<AttendanceRequest> AttendanceRequest { get; set; }

        public virtual DbSet<AttendanceProcedure> AttendanceProcedure { get; set; }
        public virtual DbSet<AttendanceProcedureEssl> AttendanceProcedureEssl { get; set; }
        public virtual DbSet<GenerateAttendanceProcedure> GenerateAttendanceProcedure { get; set; }
        public virtual DbSet<AttendanceProcedure_from_essl_final> AttendanceProcedure_from_essl_final { get; set; }
        //End HRMS

        public virtual DbSet<GetUserChilds> GetUserChilds { get; set; }
        public virtual DbSet<GetUserChildsNew> GetUserChildsNew { get; set; }
        public virtual DbSet<GetUserParents> GetUserParents { get; set; }
        public virtual DbSet<GlobalData> GlobalData { get; set; }
        public virtual DbSet<Pairs> Pairs { get; set; }
        public virtual DbSet<RegionCountry> RegionCountry { get; set; }
        public virtual DbSet<ParentChild> ParentChild { get; set; }
        public virtual DbSet<ParentChildRegion> ParentChildRegion { get; set; }

        public DbSet<DbmrAnnouncement> DbmrAnnouncement { get; set; }
        public DbSet<AttendanceLog> AttendanceLog { get; set; }


        public DbSet<Job_Vacancy> Job_Vacancy { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Webinar> Webinar { get; set; }

        public DbSet<CompensatoryLeave> CompensatoryLeave { get; set; }
        public DbSet<DBMRHiring> DBMRHiring { get; set; }
        public DbSet<CandidateAllocated> CandidateAllocated { get; set; }
        public DbSet<HiringCandidate> HiringCandidate { get; set; }
        public DbSet<HiringFolder> HiringFolder { get; set; }
        public DbSet<DBMRJobs> DBMRJobs { get; set; }
        public DbSet<HiringInterview> HiringInterview { get; set; }
        public DbSet<DBMRHiringInterview> DBMRHiringInterview { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<InterviewFeedbackDBMR> InterviewFeedbackDBMR { get; set; }
        public DbSet<MailboxDBMRHiring> MailboxDBMRHiring { get; set; }
        public DbSet<DBMRChatbox> DBMRChatbox { get; set; }
        public DbSet<DeviceLogs> DeviceLogs { get; set; }

        public DbSet<Grievance> Grievance { get; set; }
        public DbSet<GrievanceHistory> GrievanceHistory { get; set; }
        public DbSet<tbl_salary_slip> tbl_salary_slip { get; set; }
        public DbSet<offerletter> offerletter { get; set; }
        public DbSet<RequestForWfh> RequestForWfh { get; set; }
        public DbSet<GenerateAttendance> GenerateAttendance { get; set; }
    }



    public class EntitiesContextNew : DbContext
    {
        public EntitiesContextNew(DbContextOptions<EntitiesContextNew> options)
            : base(options)
        { }
        //public DbSet<DeviceLogs> DeviceLogs { get; set; }
        //public DbSet<DeviceLogs> tableName { get; set; }
        // public DbSet<DeviceLogs> DeviceLogs_11_2024 { get; set; }
        public DbSet<DeviceLogs> DeviceLogs_12_2024 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_1_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_2_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_3_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_4_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_5_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_6_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_7_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_8_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_9_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_10_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_11_2025 { get; set; }
        //public DbSet<DeviceLogs> DeviceLogs_12_2025 { get; set; }


    }

    public class HiringInterview
    {
        public int HiringInterviewId { get; set; }
        public int dbmrjobsId { get; set; }
        public DBMRJobs dbmrjobs { get; set; }

        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }

        public string videolink { get; set; }
        public string Interviewer { get; set; }
        public string InterviewStatus { get; set; }
        public string InterviewType { get; set; }
        public string InterviewDuration { get; set; }
        public string interviewCancelBy { get; set; }
        public string interviewCancelRegions { get; set; }
        public bool? isCancelled { get; set; }
        public DateTime? InterviewDateTime { get; set; }
        public DateTime? InterviewRescheduleDateTime { get; set; }
        public DateTime? createdDate { get; set; }

    }


    public class DBMRHiringInterview
    {
        public int DBMRHiringInterviewId { get; set; }
        public int DBMRHiringId { get; set; }
        public DBMRHiring DBMRHiring { get; set; }

        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }
        public string videolink { get; set; }
        public string Interviewer { get; set; }
        public string InterviewStatus { get; set; }
        public string InterviewType { get; set; }
        public string InterviewDuration { get; set; }
        public string interviewCancelBy { get; set; }
        public string interviewCancelRegions { get; set; }
        public bool? isCancelled { get; set; }
        public DateTime? InterviewDateTime { get; set; }
        public DateTime? InterviewRescheduleDateTime { get; set; }
        public DateTime? createdDate { get; set; }
        public int scheduleby { get; set; }

    }


    public class InterviewFeedback
    {
        public int InterviewFeedbackId { get; set; }
        public int dbmrjobsId { get; set; }
        public DBMRJobs dbmrjobs { get; set; }
        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }
        public string FeedbackRating { get; set; }
        public string FeedbackDiscription { get; set; }
        public string FeedbackFrom { get; set; }
        public DateTime? createdDate { get; set; }

    }

    public class InterviewFeedbackDBMR
    {
        public int InterviewFeedbackDBMRId { get; set; }
        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }
        public string FeedbackRating { get; set; }
        public string FeedbackDiscription { get; set; }
        public string FeedbackFrom { get; set; }
        public DateTime? createdDate { get; set; }

    }


    public class MailboxDBMRHiring
    {
        public int MailboxDBMRHiringId { get; set; }
        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }
        public string tomail { get; set; }
        public string ccmail { get; set; }
        public string mailsubject { get; set; }
        public string mailtemplate { get; set; }
        public string mailbody { get; set; }
        public DateTime? createdDate { get; set; }

    }


    public class DBMRChatbox
    {
        public int DBMRChatboxId { get; set; }
        public int HiringCandidateId { get; set; }
        public HiringCandidate HiringCandidate { get; set; }
        public int EmpId { get; set; }
        public Emp Emp { get; set; }
        public string CommentText { get; set; }
        public DateTime? HrAllocateDate { get; set; }
    }


    public class DBMRJobs
    {

        public int DBMRJobsID { get; set; }
        public string jobId { get; set; }
        public string jobTitle { get; set; }
        public string department { get; set; }
        public string location { get; set; }
        public string discription { get; set; }
        public string EmploymentType { get; set; }
        public string SeniorityLevel { get; set; }
        public string IndustryType { get; set; }
        public string SalaryMonthYear { get; set; }
        public string SalaryMin { get; set; }
        public string SalaryMax { get; set; }
        public string WorkExperienceFrom { get; set; }
        public string WorkExperienceTo { get; set; }
        public string HideSalary { get; set; }
        public string jobSkills { get; set; }
        public string jobEducation { get; set; }
        public string subdepartment { get; set; }
        public string regiondept { get; set; }
        public string domainDept { get; set; }

        public DateTime? jobCreatedOn { get; set; }
    }



    public class HiringFolder
    {
        public int HiringFolderId { get; set; }
        public string FolderName { get; set; }
        public string Discription { get; set; }
        public Nullable<DateTime> createdDate { get; set; }
        public Boolean isActive { get; set; }
    }

    public class HiringCandidate
    {
        public int HiringCandidateId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string email { get; set; }
        public string currentCTCInLakh { get; set; }
        public string currentCTCInThausand { get; set; }
        public string expectedCTCInLakh { get; set; }
        public string expectedCTCInThausand { get; set; }
        public string NoticePeriod { get; set; }
        public string Resume { get; set; }
        public DateTime? createdDate { get; set; }
        public Boolean? isFresher { get; set; }
        public string CompName { get; set; }
        public string compDesignation { get; set; }
        public string WorkLink { get; set; }
        public string Skills { get; set; }
        public DateTime? DurationStart { get; set; }
        public DateTime? DurationEnd { get; set; }
        public Boolean? isCurruntyWork { get; set; }


        public string EducationType { get; set; }
        public string Course { get; set; }
        public string specialist { get; set; }
        public string instituteName { get; set; }

        public DateTime? CourseDurationStart { get; set; }
        public DateTime? CourseDurationEnd { get; set; }


        public string Photo { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string city { get; set; }
        public DateTime? DofBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }

        public int HiringFolderId { get; set; }
        public HiringFolder HiringFolder { get; set; }

        public int? dbmrjobId { get; set; }
        public int? allocatedManagerid { get; set; }
        public string currentStage { get; set; }
        public string hrcomment { get; set; }

    }


    public class GetUserChilds
    {
        [Key]
        public int EmpID { get; set; }
        public int? PareentEmpID { get; set; }
        public string FirstName { get; set; }
        public string OfficialMailID { get; set; }
        public int Level { get; set; }
    }

    public class GetUserChildsNew
    {
        [Key]
        public int EmpID { get; set; }
        public int? PareentEmpID { get; set; }
        public string FirstName { get; set; }
        public string OfficialMailID { get; set; }
        public int Level { get; set; }
    }




    public class GetUserParents
    {
        [Key]
        public int EmpID { get; set; }
        //public int? PareentEmpID { get; set; }
        //public string FirstName { get; set; }
        public string OfficialMailID { get; set; }

    }

    public class AttendanceProcedure
    {
        [Key]
        public int StaffId { get; set; }
        public DateTime ThatDay { get; set; }
        public string EmployeeName { get; set; }
        public string employeeCode { get; set; }
        public TimeSpan? ChekIn { get; set; }
        public TimeSpan? ChekOut { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string ThatDayStatus { get; set; }
        public string HolidayStatus { get; set; }
        public string Sesssion { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? PresentFlag { get; set; }
        public string ShiftName { get; set; }
        public string sandwitchstatus { get; set; }
        public string department { get; set; }
        public int ParentID { get; set; }
    }


    public class AttendanceProcedureEssl
    {
        [Key]
        public int StaffId { get; set; }
        public DateTime ThatDay { get; set; }
        public string EmployeeName { get; set; }
        public string employeeCode { get; set; }
        public TimeSpan? ChekIn { get; set; }
        public TimeSpan? ChekOut { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string ThatDayStatus { get; set; }
        public string HolidayStatus { get; set; }
        public string Spent_Out_Time { get; set; }
        public string Sesssion { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? PresentFlag { get; set; }
        public string ShiftName { get; set; }
        public string sandwitchstatus { get; set; }
        public string department { get; set; }
        public int ParentID { get; set; }
    }

    public class GenerateAttendanceProcedure
    {
        [Key]
        public int StaffId { get; set; }
        public DateTime ThatDay { get; set; }
        public string EmployeeName { get; set; }
        public string employeeCode { get; set; }
        public TimeSpan? ChekIn { get; set; }
        public TimeSpan? ChekOut { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string ThatDayStatus { get; set; }
        public string HolidayStatus { get; set; }
        public string Sesssion { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? PresentFlag { get; set; }
        public string ShiftName { get; set; }
        public string sandwitchstatus { get; set; }
        public string department { get; set; }
        public int ParentID { get; set; }
    }

    public class AttendanceDTO
    {
        public DateTime ThatDay { get; set; }
        public string ThatDayStatus { get; set; }
        public decimal? LeaveDays { get; set; }
    }

    public class AttendanceProcedure_from_essl_final
    {
        [Key]
        public int StaffId { get; set; }
        public DateTime ThatDay { get; set; }
        public string EmployeeName { get; set; }
        public string employeeCode { get; set; }
        public TimeSpan? ChekIn { get; set; }
        public TimeSpan? ChekOut { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string ThatDayStatus { get; set; }
        public string HolidayStatus { get; set; }
        public string sesssion { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? PresentFlag { get; set; }
        public string ShiftName { get; set; }
        public string sandwitchstatus { get; set; }
        public string department { get; set; }
        public int ParentID { get; set; }
        public string Spent_Out_Time { get; set; }
        public string Time_Details { get; set; }
        public string Actual_Working_Hours { get; set; }
  

    }

    //public class AttendanceProcedure
    //{
    //    [Key]
    //    public int number { get; set; }

    //    public DateTime ThatDay { get; set; }
    //    public string EmployeeName { get; set; }
    //    public string EmployeeCode { get; set; }
    //    public TimeSpan? ChekIn { get; set; }
    //    public TimeSpan? ChekOut { get; set; }
    //    public TimeSpan? TotalTime { get; set; }  
    //    public string ThatDayStatus { get; set; }
    //    public string HolidayStatus { get; set; }
    //    public int StaffId { get; set; }
    //    public string Sesssion { get; set; } 
    //    public decimal? LeaveDays { get; set; }
    //    public decimal? PresentFlag { get; set; }
    //    public string ShiftName { get; set; }     
    //    public string sandwitchstatus { get; set; }  
    //}

    public class DbmrAnnouncement
    {
        public int DbmrAnnouncementID { get; set; }
        public string AnnounceTitle { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

    }

    public class Holidays
    {
        public int HolidaysId { get; set; }
        public string holidayName { get; set; }
        public DateTime? date { get; set; }
        public string resion { get; set; }
        public Boolean isOptional { get; set; }

    }

    public class RestrictedHolidays
    {
        public int RestrictedHolidaysId { get; set; }
        public string holidayName { get; set; }
        public DateTime? date { get; set; }
        public string resion { get; set; }
        public Boolean isOptional { get; set; }


    }
    public class AttendanceRequest
    {
        public int AttendanceRequestId { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
        public Nullable<System.DateTime> attendDate { get; set; }
        public Nullable<int> inOutMode { get; set; }
        public string narration { get; set; }
        public Nullable<bool> isApproved { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<int> ApprovedById { get; set; }
        public Emp ApprovedBy { get; set; }
        public virtual Emp emp { get; set; }

    }

    //HRMS
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }

    public class LeaveAllocation
    {
        public int Id { get; set; }
        public decimal NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public int? EmpID { get; set; }
        public Emp Emp { get; set; }

        public int? LeaveTypeID { get; set; }
        public LeaveType LeaveType { get; set; }

    }
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int? EmpID { get; set; }
        public Emp Emp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeID { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public int? ApprovedByID { get; set; }
        public Emp ApprovedBy { get; set; }

        public bool? Cancelled { get; set; }
        public string RequestComments { get; set; }

        public string sesionDateFrom { get; set; }
        public string sesionDateTo { get; set; }
        public decimal totalCounts { get; set; }
        public string UploadMedicalDoc { get; set; }
        public bool? SecondStepApproved { get; set; }
        public int? SecondStepApprovedByID { get; set; }
        public Emp SecondStepApprovedBy { get; set; }
        public DateTime? SecondStepApproveRejectDate { get; set; }
        public bool? DomainManagerApprove { get; set; }
        public int? DomainManagerApproveId { get; set; }
        public DateTime? DomainManagerApproveRejectDate { get; set; }
    }

    public class UserLoginLogout
    {
        #region Properties
        public int UserLoginLogoutID { get; set; }
        [Column(TypeName = "datetime")]
        public Nullable<DateTime> LoginDate_time { get; set; }

        [Column(TypeName = "datetime")]
        public Nullable<DateTime> LogOutDate_time { get; set; }
        public Nullable<int> empID { get; set; }
        public Emp emp { get; set; }
        public bool isLogedIn { get; set; }
        public string autologout { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

        #endregion
    }
    //END HRMS

    public class Media
    {
        #region Properties
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaId { get; set; }
        [Column(Order = 1)]
        public string MediaUrl { get; set; }
        [Column(Order = 2)]
        public Nullable<int> MediaType { get; set; }
        [Column(Order = 3)]
        public Nullable<DateTime> CreatedDate { get; set; }

        #endregion
    }
    public class User
    {
        public int UserID { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string DBMREmpID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string isActive { get; set; }
        public bool mailVerified { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

    }

    public class Dept
    {
        public int DeptID { get; set; }
        public String DeptName { get; set; }

        public Nullable<DateTime> createdDate { get; set; }
    }


    public class DeptQuery
    {
        public int DeptQueryID { get; set; }
        public String QueryTitle { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Dept Dept { get; set; }
        public string QuerySentOnEmail { get; set; }
        public Nullable<DateTime> createdDate { get; set; }
    }

    public class StatusMaster
    {
        #region Properties
        public int StatusMasterID { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        #endregion
    }
    public class Ticket
    {
        public int TicketID { get; set; }
        public string subject { get; set; }
        public string msg { get; set; }
        public string Priority { get; set; }


        public Nullable<DateTime> createdDate { get; set; }

        public Nullable<int> DeptQueryID { get; set; }
        public DeptQuery DeptQuery { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        // public bool Isintegernull { get; set; }
        public Emp CreatedBy { get; set; }
        // public Emp Isinteger { get; set; }  
        public Emp ModifiedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public StatusMaster Status { get; set; }
        public Nullable<int> purchaseAmt { get; set; }
    }


    public class TicketHistory
    {
        public int TicketHistoryId { get; set; }
        public string body_content { get; set; }
        public Nullable<int> TaskProgress { get; set; }
        public Nullable<DateTime> taskWillCompleteOn { get; set; }
        public Nullable<int> TaskTAT { get; set; }
        public Nullable<int> TaskTATComment { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string Priority { get; set; }
        public string Accepted { get; set; }
        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Nullable<int> AssignedToId { get; set; }
        public Nullable<int> AssignedById { get; set; }

        public Emp CreatedBy { get; set; }
        public Emp AssignedTo { get; set; }
        public Emp AssignedBy { get; set; }



        // End User Relations

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Nullable<int> StatusID { get; set; }
        public StatusMaster Status { get; set; }

        public Nullable<int> DeptQueryID { get; set; }
        public DeptQuery DeptQuery { get; set; }
    }

    public class Grievance
    {
        public int GrievanceID { get; set; }
        public string subject { get; set; }
        public string msg { get; set; }
        public string Priority { get; set; }


        public Nullable<DateTime> createdDate { get; set; }

        public Nullable<int> DeptQueryID { get; set; }
        public DeptQuery DeptQuery { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Emp CreatedBy { get; set; }
        public Emp ModifiedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public StatusMaster Status { get; set; }
    }

    public class GrievanceHistory
    {
        public int GrievanceHistoryId { get; set; }
        public string body_content { get; set; }
        public Nullable<int> TaskProgress { get; set; }
        public Nullable<DateTime> taskWillCompleteOn { get; set; }
        public Nullable<int> TaskTAT { get; set; }
        public Nullable<int> TaskTATComment { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string Priority { get; set; }
        public string Accepted { get; set; }
        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Nullable<int> AssignedToId { get; set; }
        public Nullable<int> AssignedById { get; set; }

        public Emp CreatedBy { get; set; }
        public Emp AssignedTo { get; set; }
        public Emp AssignedBy { get; set; }
        public int GrievanceId { get; set; }
        public Grievance Grievance { get; set; }

        public Nullable<int> StatusID { get; set; }
        public StatusMaster Status { get; set; }

        public Nullable<int> DeptQueryID { get; set; }
        public DeptQuery DeptQuery { get; set; }
    }

    public class Emp
    {
        #region Properties
        public int EmpID { get; set; }
        public Nullable<int> EmpTypeID { get; set; }
        public string UHID { get; set; }
        public string DBMREMPID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Photo { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public string OfficialMailID { get; set; }
        public string PersonalMailID { get; set; }
        public string ContactNumber { get; set; }
        public string PresentAddress { get; set; }
        public string Permanent_Address { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string AdharNumber { get; set; }
        public string PanNumber { get; set; }
        public string Marital_Status { get; set; }
        public string Educational_Qualification { get; set; }
        public string BloodGroup { get; set; }
        public string BaseLocation { get; set; }
        public string Shift { get; set; }
        public string Password { get; set; }


        public string LastComapny { get; set; }
        public string Hobbies { get; set; }
        public Nullable<float> YearsOfExp { get; set; }



        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<DateTime> ProExtentionDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public int? PareentEmpID { get; set; }
        public Emp PareentEmp { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string menuAccess { get; set; }
        public string FormSixteenUpload { get; set; }
        public string FormSixteenUploadPartB { get; set; }
        public int? TwoStepEmpID { get; set; }
        public Emp TwoStepEmp { get; set; }

        public string certificateOne { get; set; }

        public string certificateTwo { get; set; }


        public string MiddleName { get; set; }
        public string Nationality { get; set; }
        public string vaccinationStatus { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string emergencyCommunicationAddress { get; set; }
        public string AlternateEmergencyContact { get; set; }
        public string emergencyEmailid { get; set; }
        public string PoliceVerification { get; set; }
        public string OthersStr { get; set; }
        public string alternateContact { get; set; }
        public string docVerificationStatus { get; set; }
        public string MajorHelthStatus { get; set; }
        public string IsHelthDoc { get; set; }
        public string HelthDocument { get; set; }
        public int? AssignToHrID { get; set; }
        public bool? ProbationApprovedEmp { get; set; }
        public int? ProbationApprovedByID { get; set; }

        public string ProExtentionResion { get; set; }
        public bool? IsApprovedByDomainMgr { get; set; }
        public bool? IsRejectedByDomainMgr { get; set; }
        public int? ProbationAppRejDomainMgrID { get; set; }
        public string devicename { get; set; }
        public string workpoilicy { get; set; }
        public string userdomain { get; set; }
        public int AttEmp { get; set; }
        public int IsNightShift { get; set; }
        public int buttonvisible { get; set; }
        public bool? Isintegernull { get; set; }
        #endregion
    }

    public class LeaderShepTeam
    {
        public int LeaderShepTeamId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string message { get; set; }
        public string Department { get; set; }
        public string LinkedInID { get; set; }
        public string image { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Emp CreatedBy { get; set; }

        public Nullable<int> empId { get; set; }
        public Emp emp { get; set; }
    }


    public class StarPerformar
    {
        public int StarPerformarId { get; set; }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string message { get; set; }
        public string Department { get; set; }
        public string WiningImage { get; set; }
        public Nullable<int> Rank { get; set; }
        public Nullable<int> Type { get; set; }

        public Nullable<DateTime> PerformanceMonth { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Emp CreatedBy { get; set; }

        public Nullable<int> empId { get; set; }
        public Emp emp { get; set; }
    }


    public class DBMRActivity
    {
        public int DBMRActivityId { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string activityDiscription { get; set; }
        public string image { get; set; }
        public Nullable<DateTime> ActivityDate { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Emp CreatedBy { get; set; }
    }

    public class DbmrCsr
    {
        public int DbmrCsrId { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string shortDiscriptino { get; set; }
        public string Discription { get; set; }
        public string image { get; set; }
        public Nullable<DateTime> CSRDate { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }

        // User Relatins
        public Nullable<int> CreatedById { get; set; }
        public Emp CreatedBy { get; set; }
    }

    public class EmpDocument
    {
        public int EmpDocumentID { get; set; }
        public string DocumentName { get; set; }
        public string empDocument { get; set; }
        public string documentPath { get; set; }
        public string docType { get; set; }
        public string verifyStatus { get; set; }
        public string documentType { get; set; }
        public string InstituteOrCompanyName { get; set; }
        public string companyInfo { get; set; }

        public Nullable<DateTime> hrUploladedDate { get; set; }
        public Nullable<DateTime> empUploadDate { get; set; }
        public Nullable<DateTime> empDocDownloadDate { get; set; }
        // User relational
        public Nullable<int> uploadedByID { get; set; }
        public Emp uploadedBy { get; set; }
        public Nullable<int> empid { get; set; }
        public Emp emp { get; set; }
        public Nullable<int> verifyByID { get; set; }
        public Emp verifyBy { get; set; }

    }


    public class AssetsMgt
    {
        public int AssetsMgtID { get; set; }
        public string AssetsName { get; set; }
        public string AssetsDescription { get; set; }
        public string assetCompanyName { get; set; }
        public string assetSerialNo { get; set; }
        public string OtherAssets { get; set; }
        public Nullable<DateTime> ITUploladedDate { get; set; }
        public Nullable<DateTime> createdDate { get; set; }

        // User relational
        public Nullable<int> uploadedByID { get; set; }
        public Emp uploadedBy { get; set; }
        public int empid { get; set; }
        public Emp emp { get; set; }
    }

    public class AttendanceLog
    {
        public int AttendanceLogId { get; set; }
        public string userId { get; set; }
        public Nullable<DateTime> attendanceDateTime { get; set; }
        public Boolean? inOutMode { get; set; }
        public int? deviceID { get; set; }
        public string extraMode { get; set; }

    }
    public class Candidate
    {
        #region Properties
        public int CandidateId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string phone { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Education { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CurrentCompany { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Experience { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string NoticePeriod { get; set; }
        [Column(TypeName = "text")]
        public string Resume { get; set; }

        public Nullable<DateTime> createdDate { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string PreferredLocation { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string WillingToWorkInShift { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string currentCTC { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PositionApplied { get; set; }
        public string linkdlnID { get; set; }
        #endregion
    }
    public class Job_Vacancy
    {
        #region Properties
        public int Job_VacancyId { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string RequiredExp { get; set; }
        public string RequiredSkills { get; set; }
        public Nullable<int> NoOfPositions { get; set; }
        public string CTC { get; set; }
        public string Qualification { get; set; }
        public string Certification { get; set; }

        public string Brand { get; set; }
        public string Grade { get; set; }
        public string WorkingLanguage { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> ActiveFromDate { get; set; }
        public Nullable<DateTime> ActiveToDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> UserID { get; set; }
        public User User { get; set; }

        public Nullable<int> EFC_EPID { get; set; }
        #endregion
    }
    public class Webinar
    {
        #region Properties
        public int WebinarId { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string title { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string subtitle { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string url { get; set; }
        public string vidioUrl { get; set; }
        public Nullable<DateTime> webinarDate { get; set; }
        public string webinarTime { get; set; }
        public string webinarType { get; set; }
        public string webinarImage { get; set; }
        public bool IsActive { get; set; }

        public string eventDetails { get; set; }
        public string sessionAgeda { get; set; }
        public string whoShouldAttend { get; set; }

        public string aboutSpeakers { get; set; }
        public string confirenceProgram { get; set; }
        public string sponsor { get; set; }
        public string mediaPartner { get; set; }

        public string whyToAttend { get; set; }
        public string discription { get; set; }
        public string webi_speaker { get; set; }
        public string eventType { get; set; }
        public Nullable<decimal> Price { get; set; }

        public Nullable<int> NoOfspeakers { get; set; }
        public Nullable<int> NoOfHours { get; set; }
        public Nullable<int> NoOfSessions { get; set; }
        public Nullable<int> NoOfAttenees { get; set; }

        public Nullable<DateTime> createdDate { get; set; }



        #endregion
    }

    public class OptionalHolidays
    {
        public int OptionalHolidaysId { get; set; }
        public int? EmpId { get; set; }
        public int? approvedByID { get; set; }
        public Emp Emp { get; set; }
        public string holidayName { get; set; }
        public Nullable<DateTime> date { get; set; }
        public string resion { get; set; }
        public Boolean isOptional { get; set; }
        public string isApproved { get; set; }
        public Nullable<DateTime> applydate { get; set; }
    }

    public class CompensatoryLeave
    {
        public int CompensatoryLeaveId { get; set; }
        public int? EmpId { get; set; }
        public Emp Emp { get; set; }
        public Nullable<DateTime> date { get; set; }
        public Nullable<DateTime> whichDateCompensate { get; set; }
        public int? ApprovedByID { get; set; }
        public Emp ApprovedBy { get; set; }
        public string Compensateresion { get; set; }
        public string isApproved { get; set; }

    }

    public class OptionalHolidaysModel
    {
        public int OptionalHolidaysId { get; set; }
        public int? EmpId { get; set; }
        public Emp Emp { get; set; }
        public string holidayName { get; set; }
        public string empEmails { get; set; }
        public string employeeName { get; set; }
        public Nullable<DateTime> date { get; set; }
        public string applydatestr { get; set; }
        public string resion { get; set; }
        public Boolean isOptional { get; set; }

        public string isApproved { get; set; }
    }


    public class DBMRHiring
    {
        public int DBMRHiringId { get; set; }
        public int? EmpID { get; set; }
        public Emp Emp { get; set; }

        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string DomainName { get; set; }
        public string Region { get; set; }
        public string Designation { get; set; }
        public int? quantity { get; set; }

        public Nullable<DateTime> date { get; set; }

        public Nullable<DateTime> createdadte { get; set; }
        public string status { get; set; }
        public string attachment { get; set; }
        public string typeofJob { get; set; }
        public string baselocation { get; set; }
        public string ApprovalStatus { get; set; }
        public int? ApprovedById { get; set; }
        public Emp ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovalDate { get; set; }
        public string ActiveOrPauseStatus { get; set; }

        public Nullable<DateTime> pauseDatetime { get; set; }
        public string pauseRegion { get; set; }

        public int? pauseByid { get; set; }
        public Emp pauseBy { get; set; }
        public string AllocateHrSpoke { get; set; }
        public string HrStatus { get; set; }
        public Nullable<DateTime> CloseStausDatetime { get; set; }
        public string ExtraCol { get; set; }
        public string JobCode { get; set; }
        public Nullable<DateTime> HrAllocateDate { get; set; }
        public string replacementName { get; set; }


        public string jobTitle { get; set; }

        public string discription { get; set; }
        public string EmploymentType { get; set; }
        public string SeniorityLevel { get; set; }
        public string IndustryType { get; set; }
        public string SalaryMonthYear { get; set; }
        public string SalaryMin { get; set; }
        public string SalaryMax { get; set; }
        public string WorkExperienceFrom { get; set; }
        public string WorkExperienceTo { get; set; }

        public string jobSkills { get; set; }
        public string jobEducation { get; set; }
        public string priorityjob { get; set; }
        public bool? whichjobcreate { get; set; }

    }


    public class CandidateAllocated
    {
        public int CandidateAllocatedId { get; set; }
        public int DBMRHiringId { get; set; }
        public DBMRHiring DBMRHiring { get; set; }
        public Nullable<DateTime> DateOfSourcing { get; set; }
        public string Source { get; set; }
        public string SubSource { get; set; }
        public string canName { get; set; }
        public string canContact { get; set; }
        public string email { get; set; }
        public string CurLocation { get; set; }
        public string PreferLocation { get; set; }
        public string RelevantExperience { get; set; }
        public string CurrentOrLastEmployer { get; set; }
        public string CurrentDesignation { get; set; }
        public string CurrentAnnualCTC { get; set; }
        public string CurrentInhandSalary { get; set; }
        public string Varable { get; set; }
        public string ExpectedAnnualCTC { get; set; }
        public string ExpectedInhandSalary { get; set; }
        public string NoticePeriod { get; set; }
        public string MedicalHistory { get; set; }
        public string CovidVaccination { get; set; }
        public string MaritalStatus { get; set; }
        public string FamilyDetails { get; set; }
        public string HighestQualification { get; set; }
        public string Gender { get; set; }
        public string hrStatus { get; set; }
        public Nullable<DateTime> createdDate { get; set; }
        public int? hrid { get; set; }

    }
    public class DeviceLogs
    {
        [Key]
        public int DeviceLogId { get; set; }
        public Nullable<DateTime> DownloadDate { get; set; }
        public int DeviceId { get; set; }
        public string UserId { get; set; }
        public Nullable<DateTime> LogDate { get; set; }
        public string Direction { get; set; }
        public string AttDirection { get; set; }
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }
        public string C5 { get; set; }
        public string C6 { get; set; }
        public string C7 { get; set; }
        public string WorkCode { get; set; }
        public int IsApproved { get; set; }
        public byte[] EmployeeImage { get; set; }
        public string FileName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> LastModifiedDate { get; set; }
        public double? BodyTemperature { get; set; }
        public int IsMaskOn { get; set; }
        public string LocationAddress { get; set; }
    }
    public class tbl_salary_slip
    {
        [Key]
        public int tbl_salary_slip_ID { get; set; }
        public string salary_month { get; set; }
        public int EmpID { get; set; }
        public DateTime created_date { get; set; }
        public int? Manager_ID { get; set; }
        public bool? Approved_Rejected_Status { get; set; }
        public DateTime? Approved_Rejected_Date { get; set; }
        public Emp Emp { get; set; }
        public string Comment
        {
            get; set;
        }

    }

    public class offerletter
    {
        [Key]
        public int offerid
        {
            get; set;
        }
        public string joiningCode
        {
            get; set;
        }
        public DateTime offerDate
        {
            get; set;
        }
        public DateTime documentDate
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string designation
        {
            get; set;
        }
        public string pancard
        {
            get; set;
        }
        public decimal monthyinhand
        {
            get; set;
        }
        public decimal basicSalary
        {
            get; set;
        }
        public decimal hra
        {
            get; set;
        }
        public decimal ana
        {
            get; set;
        }
        public decimal totalgrossSalary
        {
            get; set;
        }
        public DateTime dateOfJoining
        {
            get; set;
        }
        public decimal basicSalaryYearly
        {
            get; set;
        }
        public decimal hraYearly
        {
            get; set;
        }
        public decimal anaYearly
        {
            get; set;
        }
        public decimal totalgrossSalaryYear
        {
            get; set;
        }
        public decimal EmpPF1
        {
            get; set;
        }
        public decimal EmpPF2
        {
            get; set;
        }
        public decimal bonus
        {
            get; set;
        }
        public decimal retention
        {
            get; set;
        }
        public decimal totalNetMonthly
        {
            get; set;
        }
        public decimal totalNetYearly
        {
            get; set;
        }
        public decimal tctc
        {
            get; set;
        }
        public string place
        {
            get; set;
        }
        public string reportingTo
        {
            get; set;
        }
        public int noticePeriod
        {
            get; set;
        }
        public string fatherName
        {
            get; set;
        }
        public string address
        {
            get; set;
        }
        public string so_do
        {
            get; set;
        }
        public DateTime bondDatejoin
        {
            get; set;
        }
        public DateTime bondDateEnd
        {
            get; set;
        }
        public DateTime CreatedDate
        {
            get; set;
        }
        public int? EmpId
        {
            get; set;
        }

        public string jd
        {
            get; set;
        }
        public string path
        {
            get; set;
        }



    }
    public class RequestForWfh
    {
        [Key]
        public int RequestId
        {
            get; set;
        }
        public int? EmpId
        {
            get; set;
        }
        public DateTime RequestedDate
        {
            get; set;
        }
        public DateTime From
        {
            get; set;
        }
        public DateTime TO
        {
            get; set;
        }
        public int? ApprovedRejectBy
        {
            get; set;
        }
        public bool? ApprovedRejectStatus
        {
            get; set;
        }
        public DateTime? ApprovedRejectedDate
        {
            get; set;
        }
        public int? ParentEmpID
        {
            get; set;
        }
        public string RequestReason
        {
            get; set;
        }
    }
    public class GenerateAttendance
    {
        [Key]
        public int GenerateAttendanceID { get; set; }
        public int StaffId { get; set; }
        public DateTime ThatDay { get; set; }
        public string EmployeeName { get; set; }
        public string employeeCode { get; set; }
        public TimeSpan? ChekIn { get; set; }
        public TimeSpan? ChekOut { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string ThatDayStatus { get; set; }
        public string HolidayStatus { get; set; }
        public string sesssion { get; set; }
        public decimal LeaveDays { get; set; }
        public decimal PresentFlag { get; set; }
        public string shiftname { get; set; }
        public string sandwitchstatus { get; set; }
        public string department { get; set; }
        public int ParentID { get; set; }
        public TimeSpan? Spent_Out_Time { get; set; }
        public string Time_Details { get; set; }
        public TimeSpan? Actual_Working_Hours { get; set; }

    }
    public class GlobalData
    {
        [Key]
        public int DataArrangeID { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5 { get; set; }
        public string Item6 { get; set; }
        public string Item7 { get; set; }
        public string Item8 { get; set; }
        public string Item9 { get; set; }
        public string Item10 { get; set; }
    }
    public class Pairs
    {
        [Key]
        public int PairsID { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }

    }
    public class RegionCountry
    {
        [Key]
        public int RegionCountryID { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

    }
    public class ParentChild
    {
        [Key]
        public int ParentChildID { get; set; }
        public string Parent { get; set; }
        public string Child { get; set; }

    }


    public class MeaAutomation
    {

        public string IndicationLevel1 { get; set; }
        public string IndicationLevel2 { get; set; }
        public string IndicationLevel3 { get; set; }
        public string IndicationLevel4 { get; set; }
        public string IndicationLevel5 { get; set; }
        public string IndicationLevel6 { get; set; }
        public string IndicationLevel7 { get; set; }
        public string IndicationLevel8 { get; set; }
        //public string IndicationLevel9 { get; set; }
        //public string IndicationLevel10 { get; set; }
        //public string IndicationLevel11 { get; set; }
        //public string IndicationLevel12 { get; set; }
        //public string IndicationLevel13 { get; set; }
        //public string IndicationLevel14 { get; set; }
        //public string IndicationLevel15 { get; set; }

    }



    public class ParentChildRegion
    {
        [Key]
        public int ParentChildID { get; set; }
        public string Parent { get; set; }
        public string Child { get; set; }

    }
}



