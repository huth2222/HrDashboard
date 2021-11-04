using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrDashboard.Models;
using HrDashboard.Models.Repository;
using HrDashboard.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Data;
using HrDashboard.ViewModels;

namespace HrDashboard.Controllers
{
    public class AttendanceController : Controller
    {        
        private readonly BangbooContext _db;
        public const string SessionCompany = "_Company";
        private readonly PD_TimeLateComLps_Repository _TimeLateComLps_Repository;
        private readonly PD_TimeLateLps_Repository _TimeLateLps_Repository;
        private readonly PD_TimeLostComLps_Repository _TimeLostComLps_Repository;
        private readonly PD_TimeLostLps_Repository _TimeLostLps_Repository;
        private readonly PD_TimeLeaveOtherComLps_Repository _TimeLeaveOtherComLps_Repository;
        private readonly PD_TimeLeaveOtherLps_Repository _TimeLeaveOtherLps_Repository;
        private readonly PD_TimeLeaveVacationComLps_Repository _TimeLeaveVacationComLps_Repository;
        private readonly PD_TimeLeaveVacationLps_Repository _TimeLeaveVacationLps_Repository;
        private readonly PD_TimeLeaveSickComLps_Repository _TimeLeaveSickComLps_Repository;
        private readonly PD_TimeLeaveSickLps_Repository _TimeLeaveSickLps_Repository;
        private readonly PD_TimeLeavePersComLps_Repository _TimeLeavePersComLps_Repository;
        private readonly PD_TimeLeavePersLps_Repository _TimeLeavePersLps_Repository;
        private readonly PD_TimeListYearComLps_Repository _TimeListYearComLps_Repository;
        private readonly PD_TimeListYearLps_Repository _TimeListYearLps_Repository;
        private readonly PD_TimeList30DayLps_Repository _TimeList30DayLps_Repository;
        private readonly PD_TimeList30DayComLps_Repository _TimeList30DayComLps_Repository;
        private readonly PD_TimeDeptList_Repository _TimeDeptList_Repository;
        private readonly PD_TimeDeptListOfCom_Repository _TimeDeptListOfCom_Repository;
        private readonly PD_TimeOverAllTodayLps_Repository _TimeOverAllTodayLps_Repository;
        private readonly PD_TimeOverAllComTodayLps_Repository _TimeOverAllComTodayLps_Repository;

        private readonly PD_TimeSiteList_ValuesRepository _TimeSiteList_ValuesRepository;
        private readonly PD_TimeLeavePers_ValuesRepository _TimeLeavePers_ValuesRepository;
        private readonly PD_TimeLeaveSick_ValuesRepository _TimeLeaveSick_ValuesRepository;
        private readonly PD_TimeLeaveVacation_ValuesRepository _TimeLeaveVacation_ValuesRepository;
        private readonly PD_TimeLeaveOther_ValuesRepository _TimeLeaveOther_ValuesRepository;

        private readonly PD_TimeAutoBmw_ValuesRepository _TimeAutoBmw_ValuesRepository;
        private readonly PD_TimeLost_ValuesRepository _TimeLost_ValuesRepository;
        private readonly PD_TimeLate_ValuesRepository _TimeLate_ValuesRepository;
        private readonly PD_TimeAllListMonthBmw_ValuesRepository _TimeAllListMonthBmw_ValuesRepository;
        private readonly PD_TimeAll30DayBmw_ValuesRepository _TimeAll30DayBmw_ValuesRepository;
        private readonly PD_TimeDeptListDayBmw_ValuesRepository _TimeDeptListDayBmw_ValuesRepository;
        private readonly PD_TimeAllPercentBmw_ValuesRepository _TimeAllPercentBmw_ValuesRepository;
        private readonly PD_siteDept_ValuesRepository _siteDept_ValuesRepository;
        private readonly PD_EmpList_ValuesRepository _empList_ValuesRepository;
        private readonly PD_AttByDept_ValuesRepository _attByDept_ValuesRepository;
        public AttendanceController(
            BangbooContext context,
            PD_TimeLateComLps_Repository TimeLateComLps_Repository,
            PD_TimeLateLps_Repository TimeLateLps_Repository,
            PD_TimeLostComLps_Repository TimeLostComLps_Repository,
            PD_TimeLostLps_Repository TimeLostLps_Repository,
            PD_TimeLeaveOtherComLps_Repository TimeLeaveOtherComLps_Repository,
            PD_TimeLeaveOtherLps_Repository TimeLeaveOtherLps_Repository,
            PD_TimeLeaveVacationComLps_Repository TimeLeaveVacationComLps_Repository,
            PD_TimeLeaveVacationLps_Repository TimeLeaveVacationLps_Repository,
            PD_TimeLeaveSickComLps_Repository TimeLeaveSickComLps_Repository,
            PD_TimeLeaveSickLps_Repository TimeLeaveSickLps_Repository,
            PD_TimeLeavePersComLps_Repository TimeLeavePersComLps_Repository,
            PD_TimeLeavePersLps_Repository TimeLeavePersLps_Repository,
            PD_TimeListYearComLps_Repository TimeListYearComLps_Repository,
            PD_TimeListYearLps_Repository TimeListYearLps_Repository,
            PD_TimeList30DayLps_Repository TimeList30DayLps_Repository,
            PD_TimeList30DayComLps_Repository TimeList30DayComLps_Repository,
            PD_TimeDeptList_Repository TimeDeptList_Repository,
            PD_TimeDeptListOfCom_Repository TimeDeptListOfCom_Repository,
            PD_TimeOverAllTodayLps_Repository TimeOverAllTodayLps_Repository,
            PD_TimeOverAllComTodayLps_Repository TimeOverAllComTodayLps_Repository,

            PD_TimeSiteList_ValuesRepository TimeSiteList_ValuesRepository,
            PD_TimeLeavePers_ValuesRepository TimeLeavePers_ValuesRepository,
            PD_TimeLeaveSick_ValuesRepository TimeLeaveSick_ValuesRepository,
            PD_TimeLeaveVacation_ValuesRepository TimeLeaveVacation_ValuesRepository,
            PD_TimeLeaveOther_ValuesRepository TimeLeaveOther_ValuesRepository,

            PD_TimeAutoBmw_ValuesRepository TimeAutoBmw_ValuesRepository,
            PD_TimeLost_ValuesRepository TimeLost_ValuesRepository,
            PD_TimeLate_ValuesRepository TimeLate_ValuesRepository,
            PD_TimeAllListMonthBmw_ValuesRepository TimeAllListMonthBmw_ValuesRepository,
            PD_TimeAll30DayBmw_ValuesRepository TimeAll30DayBmw_ValuesRepository,
            PD_TimeDeptListDayBmw_ValuesRepository TimeDeptListDayBmw_ValuesRepository,
            PD_TimeAllPercentBmw_ValuesRepository TimeAllPercentBmw_ValuesRepository,
            PD_siteDept_ValuesRepository siteDept_ValuesRepository,
            PD_EmpList_ValuesRepository empList_ValuesRepository,
            PD_AttByDept_ValuesRepository attByDept_ValuesRepository
        )
        {
            _db = context;
            _TimeLateComLps_Repository = TimeLateComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLateComLps_Repository));
            _TimeLateLps_Repository = TimeLateLps_Repository ?? throw new ArgumentNullException(nameof(TimeLateLps_Repository));
            _TimeLostComLps_Repository = TimeLostComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLostComLps_Repository));
            _TimeLostLps_Repository = TimeLostLps_Repository ?? throw new ArgumentNullException(nameof(TimeLostLps_Repository));
            _TimeLeaveOtherComLps_Repository = TimeLeaveOtherComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveOtherComLps_Repository));
            _TimeLeaveOtherLps_Repository = TimeLeaveOtherLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveOtherLps_Repository));
            _TimeLeaveVacationComLps_Repository = TimeLeaveVacationComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveVacationComLps_Repository));
            _TimeLeaveVacationLps_Repository = TimeLeaveVacationLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveVacationLps_Repository));
            _TimeLeaveSickComLps_Repository = TimeLeaveSickComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveSickComLps_Repository));
            _TimeLeaveSickLps_Repository = TimeLeaveSickLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeaveSickLps_Repository));
            _TimeLeavePersComLps_Repository = TimeLeavePersComLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeavePersComLps_Repository));
            _TimeLeavePersLps_Repository = TimeLeavePersLps_Repository ?? throw new ArgumentNullException(nameof(TimeLeavePersLps_Repository));
            _TimeListYearComLps_Repository = TimeListYearComLps_Repository ?? throw new ArgumentNullException(nameof(TimeListYearComLps_Repository));
            _TimeListYearLps_Repository = TimeListYearLps_Repository ?? throw new ArgumentNullException(nameof(TimeListYearLps_Repository));
            _TimeList30DayLps_Repository = TimeList30DayLps_Repository ?? throw new ArgumentNullException(nameof(TimeList30DayLps_Repository));
            _TimeList30DayComLps_Repository = TimeList30DayComLps_Repository ?? throw new ArgumentNullException(nameof(TimeList30DayComLps_Repository));
            _TimeDeptList_Repository = TimeDeptList_Repository ?? throw new ArgumentNullException(nameof(TimeDeptList_Repository));
            _TimeDeptListOfCom_Repository = TimeDeptListOfCom_Repository ?? throw new ArgumentNullException(nameof(TimeDeptListOfCom_Repository));
            _TimeOverAllTodayLps_Repository = TimeOverAllTodayLps_Repository ?? throw new ArgumentNullException(nameof(TimeOverAllTodayLps_Repository));
            _TimeOverAllComTodayLps_Repository = TimeOverAllComTodayLps_Repository ?? throw new ArgumentNullException(nameof(TimeOverAllComTodayLps_Repository));
            _TimeSiteList_ValuesRepository = TimeSiteList_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeSiteList_ValuesRepository));
            _TimeLeavePers_ValuesRepository = TimeLeavePers_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLeavePers_ValuesRepository));
            _TimeLeaveSick_ValuesRepository = TimeLeaveSick_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLeaveSick_ValuesRepository));
            _TimeLeaveVacation_ValuesRepository = TimeLeaveVacation_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLeaveVacation_ValuesRepository));
            _TimeLeaveOther_ValuesRepository = TimeLeaveOther_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLeaveOther_ValuesRepository));

            _TimeAutoBmw_ValuesRepository = TimeAutoBmw_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeAutoBmw_ValuesRepository));
            _TimeLost_ValuesRepository = TimeLost_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLost_ValuesRepository));
            _TimeLate_ValuesRepository = TimeLate_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeLate_ValuesRepository));
            _TimeAllListMonthBmw_ValuesRepository = TimeAllListMonthBmw_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeAllListMonthBmw_ValuesRepository));
            _TimeAll30DayBmw_ValuesRepository = TimeAll30DayBmw_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeAll30DayBmw_ValuesRepository));
            _TimeDeptListDayBmw_ValuesRepository = TimeDeptListDayBmw_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeDeptListDayBmw_ValuesRepository));
            _TimeAllPercentBmw_ValuesRepository = TimeAllPercentBmw_ValuesRepository ?? throw new ArgumentNullException(nameof(TimeAllPercentBmw_ValuesRepository));
            _siteDept_ValuesRepository = siteDept_ValuesRepository ?? throw new ArgumentNullException(nameof(siteDept_ValuesRepository));
            _empList_ValuesRepository = empList_ValuesRepository ?? throw new ArgumentNullException(nameof(empList_ValuesRepository));
            _attByDept_ValuesRepository = attByDept_ValuesRepository ?? throw new ArgumentNullException(nameof(attByDept_ValuesRepository));
        }
        public IActionResult BMW()
        {            
                HttpContext.Session.SetString(SessionCompany, "BMW");
                return View();            
        }

        public IActionResult Test(){
            string msg = "Messege test.";
            string token = "Qvr3OK8YCRgbrvU8gJZwPUNrjiN6Pnh5mc71Iifrlja";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", msg);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer "+token);

                using (var stream = request.GetRequestStream())stream.Write(data, 0, data.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
        public IActionResult LPS()
        {
            HttpContext.Session.SetString(SessionCompany, "LPS");
                return View();
        }
        // public IActionResult Login()
        // {
        //     return View();
        // }
        // public IActionResult Test()
        // {
        //     return View();
        // }

        
        [Route("/[controller]/[action]/{getdate}")]
        [HttpGet]
        public async Task<List<HD_PD_AttDept>> GetDeptGroupByDate([FromRoute] string getdate)
        {
            try
            {
                return await _attByDept_ValuesRepository.GetById(getdate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [Route("/[controller]/[action]/{getdate}")]
        [HttpGet]
        public async Task<List<HD_PD_AttEmpList>> GetEmpListLpsGetDate([FromRoute] string getdate)
        {
            try
            {
                return await _empList_ValuesRepository.GetById(getdate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}")]
        [HttpGet]
        public async Task<List<HD_PD_SiteList_LPS_db>> GetSiteListLpsGetDate([FromRoute] string getdate)
        {
            try
            {
                return await _TimeSiteList_ValuesRepository.GetById(getdate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeDeptListToday_db>> GetDeptListAllLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeDeptList_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //----------------
        [Route("[controller]/[action]/{getDate}")]
        public JsonResult GetLateTest(string getDate)
        {
            //string PersonCode = "LPS0031";
            string connectionString = "Server=172.16.11.248; Database=LPS; User Id=sa; Password=Lps@2019;Connection Timeout=300000";
            SqlConnection sqlconn = new SqlConnection(connectionString);
            SqlDataAdapter q_result = new SqlDataAdapter(@"SELECT "+
"q_main.PersonCode,"+
"q_main.Dept,"+
"q_main.CompanyCode,"+
"q_main.Fullname,"+
"q_lateCount.LateCount,"+
"q_main.TimeIn + ' | ' + q_main.ScanTime + ' ('+ convert(varchar(2),q_lateCount.LateCount) + ')' as ScanTime,"+
"q_main.TimeScanActive"+
"--q_main.TimeIn + ' | <span style='color:blue;'>' + q_main.ScanTime + '</span>' as ScanTime"+
"FROM"+
"("+
"SELECT"+
"q_list.WorkDate,"+
"datepart(dw,q_list.WorkDate)as DayOfWeek,"+
"q_list.TimePost,"+
"q_list.holidaySatus,"+
"q_list.ScanDate,"+
"q_list.ScanTime,"+
"case when q_list.holidaySatus = 1 then null else q_list.TimeLate end as TimeLate,"+
"q_list.PersonID,"+
"q_list.PersonCode,"+
"q_list.PersonCardID,"+
"q_list.Fullname,"+
"q_list.Dept,"+
"q_list.CompanyCode,"+
"q_list.Company_Group,"+
"q_list.Shift,"+
"q_list.SinceIn,"+
"q_list.TimeIn,"+
"q_list.TimeOut,"+
"q_list.StartDate,"+
"q_list.EndDate,"+
"case when q_list.holidaySatus = 0 and dbo.MN_View_EmpLeave.LeaveDateS is not null then 'Leave' else null end as leaveStatus,"+
"dbo.MN_View_EmpLeave.LeaveDateS,"+
"dbo.MN_View_EmpLeave.LeaveTimeS,"+
"dbo.MN_View_EmpLeave.LeaveDateE,"+
"dbo.MN_View_EmpLeave.LeaveTimeE,"+
"dbo.MN_View_EmpLeave.LeaveNameT,"+
"dbo.MN_View_EmpLeave.LeaveMemo,"+
"dbo.MN_View_EmpLeave.leaveGroupName,"+
"dbo.MN_Holiday.holiday_date"+
",q_list.TimeScanActive"+
"FROM"+
"("+
"SELECT"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"case when q_emp.TimePost = 1 then convert(varchar(10),q_time.DateInOut,121) else q_emp.WorkDate end as ScanDate,"+
"min(case when q_emp.TimePost = 1 then convert(varchar(5),q_time.DateInOut,108) else q_emp.TimeIn end)as ScanTime,"+
"case when min(convert(varchar(5),q_time.DateInOut,108)) > q_emp.TimeIn then 'Late' else null end as TimeLate,"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
",q_emp.TimeScanActive"+
"FROM"+
"("+
"SELECT "+
"convert(varchar(10),case when len(q_workDay.workDate) < 10 then concat(substring(q_workDay.workDate,1,4),'-0',substring(q_workDay.workDate,6,1),substring(q_workDay.workDate,7,3)) else q_workDay.workDate end) as WorkDate,"+
"q_workDay.PersonID,"+
"dbo.MN_View_Person.PersonCode,"+
"dbo.MN_View_Person.PersonCardID,"+
"dbo.MN_View_Person.FnameT + ' ' + dbo.MN_View_Person.LnameT as Fullname,"+
"REPLACE(dbo.MN_View_lpsDept.Cmb2NameT,'LPS - ','')as Dept,"+
"case when dbo.MN_View_Person.Cmb6ID in(9,29) then 0 else 1 end as TimePost,"+
"dbo.MN_View_Company.Company_Code as CompanyCode,"+
"dbo.MN_View_Company.Company_Group,"+
"dbo.MN_View_Person.StartDate,"+
"dbo.MN_View_Person.EndDate,"+
"q_workDay.holidaySatus,"+
"q_workDay.Shift,"+
"dbo.MN_View_LpsShift.SinceIn,"+
"dbo.MN_View_LpsShift.TimeIn,"+
"dbo.MN_View_LpsShift.TimeOut,"+
"dbo.MN_View_Person.TimeScanActive"+
"FROM"+
"("+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-01') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS1 AS Shift , Cyberhrm.dbo.TAM_Work.CKH1 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 1 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-02') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS2 AS Shift , Cyberhrm.dbo.TAM_Work.CKH2 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 2 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-03') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS3 AS Shift , Cyberhrm.dbo.TAM_Work.CKH3 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 3 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-04') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS4 AS Shift , Cyberhrm.dbo.TAM_Work.CKH4 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 4 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-05') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS5 AS Shift , Cyberhrm.dbo.TAM_Work.CKH5 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 5 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-06') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS6 AS Shift , Cyberhrm.dbo.TAM_Work.CKH6 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 6 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-07') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS7 AS Shift , Cyberhrm.dbo.TAM_Work.CKH7 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 7 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-08') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS8 AS Shift , Cyberhrm.dbo.TAM_Work.CKH8 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 8 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-09') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS9 AS Shift , Cyberhrm.dbo.TAM_Work.CKH9 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 9 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-10') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS10 AS Shift , Cyberhrm.dbo.TAM_Work.CKH10 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 10 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-11') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS11 AS Shift , Cyberhrm.dbo.TAM_Work.CKH11 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 11 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-12') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS12 AS Shift , Cyberhrm.dbo.TAM_Work.CKH12 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 12 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-13') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS13 AS Shift , Cyberhrm.dbo.TAM_Work.CKH13 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 13 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-14') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS14 AS Shift , Cyberhrm.dbo.TAM_Work.CKH14 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 14 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-15') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS15 AS Shift , Cyberhrm.dbo.TAM_Work.CKH15 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 15 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-16') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS16 AS Shift , Cyberhrm.dbo.TAM_Work.CKH16 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 16 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-17') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS17 AS Shift , Cyberhrm.dbo.TAM_Work.CKH17 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 17 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-18') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS18 AS Shift , Cyberhrm.dbo.TAM_Work.CKH18 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 18 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-19') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS19 AS Shift , Cyberhrm.dbo.TAM_Work.CKH19 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 19 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-20') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS20 AS Shift , Cyberhrm.dbo.TAM_Work.CKH20 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 20 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-21') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS21 AS Shift , Cyberhrm.dbo.TAM_Work.CKH21 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 21 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-22') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS22 AS Shift , Cyberhrm.dbo.TAM_Work.CKH22 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 22 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-23') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS23 AS Shift , Cyberhrm.dbo.TAM_Work.CKH23 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 23 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-24') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS24 AS Shift , Cyberhrm.dbo.TAM_Work.CKH24 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 24 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-25') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS25 AS Shift , Cyberhrm.dbo.TAM_Work.CKH25 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 25 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-26') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS26 AS Shift , Cyberhrm.dbo.TAM_Work.CKH26 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 26 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-27') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS27 AS Shift , Cyberhrm.dbo.TAM_Work.CKH27 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 27 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-28') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS28 AS Shift , Cyberhrm.dbo.TAM_Work.CKH28 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 28 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-29') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS29 AS Shift , Cyberhrm.dbo.TAM_Work.CKH29 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 29 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-30') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS30 AS Shift , Cyberhrm.dbo.TAM_Work.CKH30 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 30 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-31') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS31 AS Shift , Cyberhrm.dbo.TAM_Work.CKH31 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 31 = convert(int,substring('" + getDate + "',9,2))  "+
")as q_workDay"+
"LEFT JOIN dbo.MN_View_Person on q_workDay.PersonID = dbo.MN_View_Person.PersonID"+
"LEFT JOIN dbo.MN_View_lpsDept on dbo.MN_View_Person.Cmb2ID = dbo.MN_View_lpsDept.Cmb2ID"+
"LEFT JOIN dbo.MN_View_Company on dbo.MN_View_Person.CompanyID = dbo.MN_View_Company.ID_Company"+
"LEFT JOIN dbo.MN_View_LpsShift on dbo.MN_View_LpsShift.Shift_Code = q_workDay.Shift AND dbo.MN_View_Person.CompanyID = dbo.MN_View_LpsShift.ID_Company"+
""+
"WHERE "+
"datepart(dw,q_workDay.workDate) <> 1 and"+
"convert(int,substring(q_workDay.workDate,1,4)) > 2019 "+
"and dbo.MN_View_Person.Cmb1ID <> 10028"+
"and dbo.MN_View_Person.PersonID not in(16689,13683,270,608,609,822,823,176,577)"+
"--and dbo.MN_View_Person.TimeScanStatus like 'e'"+
"--and dbo.MN_View_lpsDept.Cmb2NameT not like '%บริหาร%'"+
"and dbo.MN_View_Person.PersonID not in (16689,608,609,270,12502,12502,12503,1540,745,804,830,17718)"+
"and dbo.MN_View_Person.Cmb2ID not in (40,11,15,42,41,43,243,242,244,269)"+
"--and q_workDay.Shift not in ('','OFF')"+
"and"+
"--@getCompanyGroup = case when @getCompanyGroup = 'LPS GROUP' then @getCompanyGroup else dbo.MN_View_Company.Company_Group end and "+
"convert(datetime,'" + getDate + "') BETWEEN dbo.MN_View_Person.StartDate and case when dbo.MN_View_Person.EndDate is null then convert(datetime,'" + getDate + "') else dbo.MN_View_Person.EndDate end"+
"--and @getCompany = case when @getCompany = 'all' then @getCompany else dbo.MN_View_Company.Company_Code end"+
"--and @getCompany = dbo.MN_View_Company.Company_Code"+
"--and dbo.MN_View_Company.Company_Code = @getCompany"+
"and dbo.MN_View_Company.Company_Group = 'LPS GROUP'"+
")as q_emp"+
"LEFT JOIN"+
"("+
"SELECT"+
"dbo.HD_View_TimeInOut.ID_Card,"+
"dbo.HD_View_TimeInOut.DateInOut"+
""+
"FROM"+
"dbo.HD_View_TimeInOut"+
"WHERE convert(date,dbo.HD_View_TimeInOut.DateInOut) = convert(date,'" + getDate + "') and"+
"dbo.HD_View_TimeInOut.ID_Card is not null"+
")as q_time"+
"on q_emp.PersonCardID = q_time.ID_Card and q_emp.WorkDate = convert(varchar(10),q_time.DateInOut,121)"+
"WHERE ((convert(varchar(5),q_time.DateInOut,108) >= q_emp.SinceIn) or q_time.DateInOut is null)"+
"and q_emp.TimePost = 1"+
"--and q_emp.PersonCardID = '800891'"+
"GROUP BY"+
"--q_emp.active,"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"convert(varchar(10),q_time.DateInOut,121),"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
",q_emp.TimeScanActive"+
")as q_list"+
"LEFT JOIN dbo.MN_View_EmpLeave on q_list.PersonID = dbo.MN_View_EmpLeave.PersonID and q_list.WorkDate BETWEEN"+
"dbo.MN_View_EmpLeave.LeaveDateS and dbo.MN_View_EmpLeave.LeaveDateE"+
"LEFT JOIN dbo.MN_Holiday on q_list.Dept COLLATE Thai_100_BIN = dbo.MN_Holiday.site_name and dbo.MN_Holiday.holiday_date = convert(date,'" + getDate + "')"+
"--WHERE --@getCompany = case when @getCompany = 'all' then @getCompany else q_list.CompanyCode end"+
"left join"+
"("+
"SELECT"+
"q_list.WorkDate,"+
"datepart(dw,q_list.WorkDate)as DayOfWeek,"+
"q_list.TimePost,"+
"q_list.holidaySatus,"+
"q_list.ScanDate,"+
"q_list.ScanTime,"+
"case when q_list.holidaySatus = 1 then null else q_list.TimeLate end as TimeLate,"+
"q_list.PersonID,"+
"q_list.PersonCode,"+
"q_list.PersonCardID,"+
"q_list.Fullname,"+
"q_list.Dept,"+
"q_list.CompanyCode,"+
"q_list.Company_Group,"+
"q_list.Shift,"+
"q_list.SinceIn,"+
"q_list.TimeIn,"+
"q_list.TimeOut,"+
"q_list.StartDate,"+
"q_list.EndDate,"+
"case when q_list.holidaySatus = 0 and dbo.MN_View_EmpLeave.LeaveDateS is not null then 'Leave' else null end as leaveStatus,"+
"dbo.MN_View_EmpLeave.LeaveDateS,"+
"dbo.MN_View_EmpLeave.LeaveTimeS,"+
"dbo.MN_View_EmpLeave.LeaveDateE,"+
"dbo.MN_View_EmpLeave.LeaveTimeE,"+
"dbo.MN_View_EmpLeave.LeaveNameT,"+
"dbo.MN_View_EmpLeave.LeaveMemo,"+
"dbo.MN_View_EmpLeave.leaveGroupName,"+
"dbo.MN_Holiday.holiday_date"+
"FROM"+
"("+
"SELECT"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"case when q_emp.TimePost = 1 then convert(varchar(10),q_time.DateInOut,121) else q_emp.WorkDate end as ScanDate,"+
"min(case when q_emp.TimePost = 1 then convert(varchar(5),q_time.DateInOut,108) else q_emp.TimeIn end)as ScanTime,"+
"case when min(convert(varchar(5),q_time.DateInOut,108)) > q_emp.TimeIn then 'Late' else null end as TimeLate,"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
"FROM"+
"("+
"SELECT "+
"convert(varchar(10),case when len(q_workDay.workDate) < 10 then concat(substring(q_workDay.workDate,1,4),'-0',substring(q_workDay.workDate,6,1),substring(q_workDay.workDate,7,3)) else q_workDay.workDate end) as WorkDate,"+
"q_workDay.PersonID,"+
"dbo.MN_View_Person.PersonCode,"+
"dbo.MN_View_Person.PersonCardID,"+
"dbo.MN_View_Person.FnameT + ' ' + dbo.MN_View_Person.LnameT as Fullname,"+
"REPLACE(dbo.MN_View_lpsDept.Cmb2NameT,'LPS - ','')as Dept,"+
"case when dbo.MN_View_Person.Cmb6ID in(9,29) then 0 else 1 end as TimePost,"+
"dbo.MN_View_Company.Company_Code as CompanyCode,"+
"dbo.MN_View_Company.Company_Group,"+
"dbo.MN_View_Person.StartDate,"+
"dbo.MN_View_Person.EndDate,"+
"q_workDay.holidaySatus,"+
"q_workDay.Shift,"+
"dbo.MN_View_LpsShift.SinceIn,"+
"dbo.MN_View_LpsShift.TimeIn,"+
"dbo.MN_View_LpsShift.TimeOut"+
"FROM"+
"("+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-01') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS1 AS Shift , Cyberhrm.dbo.TAM_Work.CKH1 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 1 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-02') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS2 AS Shift , Cyberhrm.dbo.TAM_Work.CKH2 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 2 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-03') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS3 AS Shift , Cyberhrm.dbo.TAM_Work.CKH3 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 3 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-04') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS4 AS Shift , Cyberhrm.dbo.TAM_Work.CKH4 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 4 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-05') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS5 AS Shift , Cyberhrm.dbo.TAM_Work.CKH5 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 5 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-06') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS6 AS Shift , Cyberhrm.dbo.TAM_Work.CKH6 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 6 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-07') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS7 AS Shift , Cyberhrm.dbo.TAM_Work.CKH7 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 7 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-08') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS8 AS Shift , Cyberhrm.dbo.TAM_Work.CKH8 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 8 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-09') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS9 AS Shift , Cyberhrm.dbo.TAM_Work.CKH9 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 9 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-10') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS10 AS Shift , Cyberhrm.dbo.TAM_Work.CKH10 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 10 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-11') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS11 AS Shift , Cyberhrm.dbo.TAM_Work.CKH11 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 11 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-12') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS12 AS Shift , Cyberhrm.dbo.TAM_Work.CKH12 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 12 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-13') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS13 AS Shift , Cyberhrm.dbo.TAM_Work.CKH13 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 13 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-14') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS14 AS Shift , Cyberhrm.dbo.TAM_Work.CKH14 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 14 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-15') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS15 AS Shift , Cyberhrm.dbo.TAM_Work.CKH15 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 15 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-16') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS16 AS Shift , Cyberhrm.dbo.TAM_Work.CKH16 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 16 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-17') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS17 AS Shift , Cyberhrm.dbo.TAM_Work.CKH17 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 17 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-18') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS18 AS Shift , Cyberhrm.dbo.TAM_Work.CKH18 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 18 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-19') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS19 AS Shift , Cyberhrm.dbo.TAM_Work.CKH19 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 19 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-20') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS20 AS Shift , Cyberhrm.dbo.TAM_Work.CKH20 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 20 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-21') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS21 AS Shift , Cyberhrm.dbo.TAM_Work.CKH21 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 21 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-22') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS22 AS Shift , Cyberhrm.dbo.TAM_Work.CKH22 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 22 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-23') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS23 AS Shift , Cyberhrm.dbo.TAM_Work.CKH23 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 23 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-24') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS24 AS Shift , Cyberhrm.dbo.TAM_Work.CKH24 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 24 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-25') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS25 AS Shift , Cyberhrm.dbo.TAM_Work.CKH25 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 25 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-26') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS26 AS Shift , Cyberhrm.dbo.TAM_Work.CKH26 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 26 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-27') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS27 AS Shift , Cyberhrm.dbo.TAM_Work.CKH27 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 27 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-28') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS28 AS Shift , Cyberhrm.dbo.TAM_Work.CKH28 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 28 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-29') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS29 AS Shift , Cyberhrm.dbo.TAM_Work.CKH29 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 29 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-30') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS30 AS Shift , Cyberhrm.dbo.TAM_Work.CKH30 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 30 = convert(int,substring('" + getDate + "',9,2)) UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-31') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS31 AS Shift , Cyberhrm.dbo.TAM_Work.CKH31 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE Cyberhrm.dbo.TAM_Work.Work_Year = convert(int,substring('" + getDate + "',1,4)) and Cyberhrm.dbo.TAM_Work.work_Month = convert(int,substring('" + getDate + "',6,2)) and 31 = convert(int,substring('" + getDate + "',9,2))  "+
")as q_workDay"+
"LEFT JOIN dbo.MN_View_Person on q_workDay.PersonID = dbo.MN_View_Person.PersonID"+
"LEFT JOIN dbo.MN_View_lpsDept on dbo.MN_View_Person.Cmb2ID = dbo.MN_View_lpsDept.Cmb2ID"+
"LEFT JOIN dbo.MN_View_Company on dbo.MN_View_Person.CompanyID = dbo.MN_View_Company.ID_Company"+
"LEFT JOIN dbo.MN_View_LpsShift on dbo.MN_View_LpsShift.Shift_Code = q_workDay.Shift AND dbo.MN_View_Person.CompanyID = dbo.MN_View_LpsShift.ID_Company"+
""+
"WHERE "+
"datepart(dw,q_workDay.workDate) <> 1 and"+
"convert(int,substring(q_workDay.workDate,1,4)) > 2019 "+
"and dbo.MN_View_Person.Cmb1ID <> 10028"+
"and dbo.MN_View_Person.PersonID not in(16689,13683,270,608,609,822,823,176,577)"+
"--and dbo.MN_View_Person.TimeScanStatus like 'e'"+
"--and dbo.MN_View_lpsDept.Cmb2NameT not like '%บริหาร%'"+
"and dbo.MN_View_Person.PersonID not in (16689,608,609,270,12502,12502,12503,1540,745,804,830,17718)"+
"and dbo.MN_View_Person.Cmb2ID not in (40,11,15,42,41,43,243,242,244,269)"+
"--and q_workDay.Shift not in ('','OFF')"+
"and"+
"--@getCompanyGroup = case when @getCompanyGroup = 'LPS GROUP' then @getCompanyGroup else dbo.MN_View_Company.Company_Group end and "+
"convert(datetime,'" + getDate + "') BETWEEN dbo.MN_View_Person.StartDate and case when dbo.MN_View_Person.EndDate is null then convert(datetime,'" + getDate + "') else dbo.MN_View_Person.EndDate end"+
"--and @getCompany = case when @getCompany = 'all' then @getCompany else dbo.MN_View_Company.Company_Code end"+
"--and @getCompany = dbo.MN_View_Company.Company_Code"+
"--and dbo.MN_View_Company.Company_Code = @getCompany"+
"and dbo.MN_View_Company.Company_Group = 'LPS GROUP'"+
")as q_emp"+
"LEFT JOIN"+
"("+
"SELECT"+
"dbo.HD_View_TimeInOut.ID_Card,"+
"dbo.HD_View_TimeInOut.DateInOut"+
""+
"FROM"+
"dbo.HD_View_TimeInOut"+
"WHERE convert(date,dbo.HD_View_TimeInOut.DateInOut) = convert(date,'" + getDate + "') and"+
"dbo.HD_View_TimeInOut.ID_Card is not null"+
")as q_time"+
"on q_emp.PersonCardID = q_time.ID_Card and q_emp.WorkDate = convert(varchar(10),q_time.DateInOut,121)"+
"WHERE ((convert(varchar(5),q_time.DateInOut,108) >= q_emp.SinceIn) or q_time.DateInOut is null)"+
"and q_emp.TimePost = 1"+
"--and q_emp.PersonCardID = '800891'"+
"GROUP BY"+
"--q_emp.active,"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"convert(varchar(10),q_time.DateInOut,121),"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
"--,q_emp.TimeScanActive"+
")as q_list"+
"LEFT JOIN dbo.MN_View_EmpLeave on q_list.PersonID = dbo.MN_View_EmpLeave.PersonID and q_list.WorkDate BETWEEN"+
"dbo.MN_View_EmpLeave.LeaveDateS and dbo.MN_View_EmpLeave.LeaveDateE"+
"--WHERE --@getCompany = case when @getCompany = 'all' then @getCompany else q_list.CompanyCode end"+
"LEFT JOIN dbo.MN_Holiday on q_list.Dept COLLATE Thai_100_BIN = dbo.MN_Holiday.site_name and dbo.MN_Holiday.holiday_date = convert(date,'" + getDate + "')"+
""+
"WHERE"+
"datepart(dw,q_list.WorkDate) <> 1 and"+
"dbo.MN_Holiday.holiday_date is null and"+
"case "+
"when q_list.Dept in( 'คนพิการ (HR)','คนพิการ (สมุทรปราการ)' )then 'คนพิการ' "+
"when q_list.PersonID in('17694','12845') then 'ACC'"+
"when q_list.Dept like '%พิการ%' and q_list.Dept not in('คนพิการ (HR)','คนพิการ (สมุทรปราการ)')then 'Delete' "+
"when q_list.Dept like '%การตลาด%' then 'MAR' "+
"when q_list.Dept like '%ลูกค้าสัมพันธ์%' then 'CUS' "+
"else q_list.Dept end <> 'Delete'"+
"and q_list.TimeLate is not null"+
""+
")as q_lart on q_list.PersonID = q_lart.PersonID"+
""+
")as q_main"+
"left join"+
"("+
"SELECT"+
"q_count.PersonCode,"+
"count(q_count.PersonCode)as LateCount"+
""+
"FROM"+
"("+
"SELECT"+
"q_list.WorkDate,"+
"datepart(dw,q_list.WorkDate)as DayOfWeek,"+
"q_list.TimePost,"+
"q_list.holidaySatus,"+
"q_list.ScanDate,"+
"q_list.ScanTime,"+
"case when q_list.holidaySatus = 1 then null else q_list.TimeLate end as TimeLate,"+
"q_list.PersonID,"+
"q_list.PersonCode,"+
"q_list.PersonCardID,"+
"q_list.Fullname,"+
"q_list.Dept,"+
"q_list.CompanyCode,"+
"q_list.Company_Group,"+
"q_list.Shift,"+
"q_list.SinceIn,"+
"q_list.TimeIn,"+
"q_list.TimeOut,"+
"q_list.StartDate,"+
"q_list.EndDate,"+
"case when q_list.holidaySatus = 0 and dbo.MN_View_EmpLeave.LeaveDateS is not null then 'Leave' else null end as leaveStatus,"+
"dbo.MN_View_EmpLeave.LeaveDateS,"+
"dbo.MN_View_EmpLeave.LeaveTimeS,"+
"dbo.MN_View_EmpLeave.LeaveDateE,"+
"dbo.MN_View_EmpLeave.LeaveTimeE,"+
"dbo.MN_View_EmpLeave.LeaveNameT,"+
"dbo.MN_View_EmpLeave.LeaveMemo,"+
"dbo.MN_View_EmpLeave.leaveGroupName,"+
"dbo.MN_Holiday.holiday_date"+
"FROM"+
"("+
"SELECT"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"case when q_emp.TimePost = 1 then convert(varchar(10),q_time.DateInOut,121) else q_emp.WorkDate end as ScanDate,"+
"min(case when q_emp.TimePost = 1 then convert(varchar(5),q_time.DateInOut,108) else q_emp.TimeIn end)as ScanTime,"+
"case when min(convert(varchar(5),q_time.DateInOut,108)) > q_emp.TimeIn then 'Late' else null end as TimeLate,"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
"FROM"+
"("+
"SELECT "+
"convert(varchar(10),case when len(q_workDay.workDate) < 10 then concat(substring(q_workDay.workDate,1,4),'-0',substring(q_workDay.workDate,6,1),substring(q_workDay.workDate,7,3)) else q_workDay.workDate end) as WorkDate,"+
"q_workDay.PersonID,"+
"dbo.MN_View_Person.PersonCode,"+
"dbo.MN_View_Person.PersonCardID,"+
"dbo.MN_View_Person.FnameT + ' ' + dbo.MN_View_Person.LnameT as Fullname,"+
"REPLACE(dbo.MN_View_lpsDept.Cmb2NameT,'LPS - ','')as Dept,"+
"case when dbo.MN_View_Person.Cmb6ID in(9,29) then 0 else 1 end as TimePost,"+
"dbo.MN_View_Company.Company_Code as CompanyCode,"+
"dbo.MN_View_Company.Company_Group,"+
"dbo.MN_View_Person.StartDate,"+
"dbo.MN_View_Person.EndDate,"+
"q_workDay.holidaySatus,"+
"q_workDay.Shift,"+
"dbo.MN_View_LpsShift.SinceIn,"+
"dbo.MN_View_LpsShift.TimeIn,"+
"dbo.MN_View_LpsShift.TimeOut"+
"FROM"+
"("+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-01') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS1 AS Shift , Cyberhrm.dbo.TAM_Work.CKH1 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',1)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-02') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS2 AS Shift , Cyberhrm.dbo.TAM_Work.CKH2 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',2)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-03') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS3 AS Shift , Cyberhrm.dbo.TAM_Work.CKH3 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',3)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-04') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS4 AS Shift , Cyberhrm.dbo.TAM_Work.CKH4 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',4)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-05') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS5 AS Shift , Cyberhrm.dbo.TAM_Work.CKH5 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',5)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-06') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS6 AS Shift , Cyberhrm.dbo.TAM_Work.CKH6 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',6)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-07') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS7 AS Shift , Cyberhrm.dbo.TAM_Work.CKH7 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',7)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-08') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS8 AS Shift , Cyberhrm.dbo.TAM_Work.CKH8 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',8)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-09') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS9 AS Shift , Cyberhrm.dbo.TAM_Work.CKH9 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',9)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-10') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS10 AS Shift , Cyberhrm.dbo.TAM_Work.CKH10 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',10)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-11') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS11 AS Shift , Cyberhrm.dbo.TAM_Work.CKH11 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',11)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-12') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS12 AS Shift , Cyberhrm.dbo.TAM_Work.CKH12 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',12)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-13') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS13 AS Shift , Cyberhrm.dbo.TAM_Work.CKH13 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',13)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-14') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS14 AS Shift , Cyberhrm.dbo.TAM_Work.CKH14 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',14)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-15') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS15 AS Shift , Cyberhrm.dbo.TAM_Work.CKH15 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',15)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-16') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS16 AS Shift , Cyberhrm.dbo.TAM_Work.CKH16 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',16)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-17') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS17 AS Shift , Cyberhrm.dbo.TAM_Work.CKH17 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',17)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-18') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS18 AS Shift , Cyberhrm.dbo.TAM_Work.CKH18 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',18)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-19') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS19 AS Shift , Cyberhrm.dbo.TAM_Work.CKH19 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',19)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-20') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS20 AS Shift , Cyberhrm.dbo.TAM_Work.CKH20 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',20)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-21') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS21 AS Shift , Cyberhrm.dbo.TAM_Work.CKH21 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',21)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-22') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS22 AS Shift , Cyberhrm.dbo.TAM_Work.CKH22 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',22)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-23') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS23 AS Shift , Cyberhrm.dbo.TAM_Work.CKH23 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',23)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-24') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS24 AS Shift , Cyberhrm.dbo.TAM_Work.CKH24 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',24)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-25') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS25 AS Shift , Cyberhrm.dbo.TAM_Work.CKH25 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',25)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-26') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS26 AS Shift , Cyberhrm.dbo.TAM_Work.CKH26 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',26)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-27') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS27 AS Shift , Cyberhrm.dbo.TAM_Work.CKH27 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',27)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-28') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS28 AS Shift , Cyberhrm.dbo.TAM_Work.CKH28 as holidaySatus FROM Cyberhrm.dbo.TAM_Work WHERE convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',28)) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
""+
""+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-29') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS29 AS Shift , Cyberhrm.dbo.TAM_Work.CKH29 as holidaySatus FROM Cyberhrm.dbo.TAM_Work "+
"WHERE"+
"case "+
"when day(EOMONTH(convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-01')))) < 29 then convert(date,'1900-01-01')"+
"else convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',29)) end BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
""+
""+
""+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-30') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS30 AS Shift , Cyberhrm.dbo.TAM_Work.CKH30 as holidaySatus FROM Cyberhrm.dbo.TAM_Work "+
"WHERE "+
"case "+
"when day(EOMONTH(convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-01')))) < 30 then convert(date,'1900-01-01')"+
"else convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',30)) end BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') UNION "+
""+
""+
"SELECT concat(Cyberhrm.dbo.TAM_Work.Work_Year, '-' ,Cyberhrm.dbo.TAM_Work.work_Month, '-31') as workDate,Cyberhrm.dbo.TAM_Work.PersonID,Cyberhrm.dbo.TAM_Work.DS31 AS Shift , Cyberhrm.dbo.TAM_Work.CKH31 as holidaySatus FROM Cyberhrm.dbo.TAM_Work "+
"WHERE "+
"case "+
"when day(EOMONTH(convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-01')))) < 31 then convert(date,'1900-01-01')"+
"else convert(date,concat(Cyberhrm.dbo.TAM_Work.Work_Year,'-',Cyberhrm.dbo.TAM_Work.work_Month,'-',31)) end BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') "+
")as q_workDay"+
"LEFT JOIN dbo.MN_View_Person on q_workDay.PersonID = dbo.MN_View_Person.PersonID"+
"LEFT JOIN dbo.MN_View_lpsDept on dbo.MN_View_Person.Cmb2ID = dbo.MN_View_lpsDept.Cmb2ID"+
"LEFT JOIN dbo.MN_View_Company on dbo.MN_View_Person.CompanyID = dbo.MN_View_Company.ID_Company"+
"LEFT JOIN dbo.MN_View_LpsShift on dbo.MN_View_LpsShift.Shift_Code = q_workDay.Shift AND dbo.MN_View_Person.CompanyID = dbo.MN_View_LpsShift.ID_Company"+
""+
"WHERE "+
"convert(int,substring(q_workDay.workDate,1,4)) > 2019 "+
"and dbo.MN_View_Person.Cmb1ID <> 10028"+
"and dbo.MN_View_Person.PersonID not in(16689,13683,270,608,609,822,823,176,577)"+
"--and dbo.MN_View_Person.TimeScanStatus like 'e'"+
"--and dbo.MN_View_lpsDept.Cmb2NameT not like '%บริหาร%'"+
"and dbo.MN_View_Person.PersonID not in (16689,608,609,270,12502,12502,12503,1540,745,804,830,17718)"+
"and dbo.MN_View_Person.Cmb2ID not in (40,11,15,42,41,43,243,242,244,269)"+
"--and q_workDay.Shift not in ('','OFF')"+
"and"+
"--@getCompanyGroup = case when @getCompanyGroup = 'LPS GROUP' then @getCompanyGroup else dbo.MN_View_Company.Company_Group end and "+
"convert(datetime,'" + getDate + "') BETWEEN dbo.MN_View_Person.StartDate and case when dbo.MN_View_Person.EndDate is null then convert(datetime,'" + getDate + "') else dbo.MN_View_Person.EndDate end"+
"--and @getCompany = case when @getCompany = 'all' then @getCompany else dbo.MN_View_Company.Company_Code end"+
"--and @getCompany = dbo.MN_View_Company.Company_Code"+
"--and dbo.MN_View_Company.Company_Code = @getCompany"+
"and dbo.MN_View_Company.Company_Group = 'LPS GROUP'"+
")as q_emp"+
"LEFT JOIN"+
"("+
"SELECT"+
"dbo.HD_View_TimeInOut.ID_Card,"+
"dbo.HD_View_TimeInOut.DateInOut"+
""+
"FROM"+
"dbo.HD_View_TimeInOut"+
"WHERE convert(date,dbo.HD_View_TimeInOut.DateInOut) BETWEEN convert(date,concat(convert(varchar(7),dateadd(month,-1,'" + getDate + "'),121),'-21')) and convert(date,'" + getDate + "') "+
"and dbo.HD_View_TimeInOut.ID_Card is not null"+
")as q_time"+
"on q_emp.PersonCardID = q_time.ID_Card and q_emp.WorkDate = convert(varchar(10),q_time.DateInOut,121)"+
"WHERE ((convert(varchar(5),q_time.DateInOut,108) >= q_emp.SinceIn) or q_time.DateInOut is null)"+
"and q_emp.TimePost = 1"+
"--and q_emp.PersonCardID = '800891'"+
"GROUP BY"+
"--q_emp.active,"+
"q_emp.WorkDate,"+
"q_emp.TimePost,"+
"convert(varchar(10),q_time.DateInOut,121),"+
"q_emp.PersonID,"+
"q_emp.PersonCode,"+
"q_emp.PersonCardID,"+
"q_emp.Fullname,"+
"q_emp.Dept,"+
"q_emp.CompanyCode,"+
"q_emp.Company_Group,"+
"q_emp.holidaySatus,"+
"q_emp.Shift,"+
"q_emp.SinceIn,"+
"q_emp.TimeIn,"+
"q_emp.TimeOut,"+
"q_emp.StartDate,"+
"q_emp.EndDate"+
")as q_list"+
"LEFT JOIN dbo.MN_View_EmpLeave on q_list.PersonID = dbo.MN_View_EmpLeave.PersonID and q_list.WorkDate BETWEEN"+
"dbo.MN_View_EmpLeave.LeaveDateS and dbo.MN_View_EmpLeave.LeaveDateE"+
"LEFT JOIN dbo.MN_Holiday on q_list.Dept COLLATE Thai_100_BIN = dbo.MN_Holiday.site_name and dbo.MN_Holiday.holiday_date = convert(date,'" + getDate + "')"+
"--WHERE --@getCompany = case when @getCompany = 'all' then @getCompany else q_list.CompanyCode end"+
"where datepart(dw,q_list.WorkDate) <> 1 and"+
"dbo.MN_Holiday.holiday_date is null"+
")as q_count"+
"WHERE"+
"case "+
"when q_count.Dept in( 'คนพิการ (HR)','คนพิการ (สมุทรปราการ)' )then 'คนพิการ' "+
"when q_count.PersonID in('17694','12845') then 'ACC'"+
"when q_count.Dept like '%พิการ%' and q_count.Dept not in('คนพิการ (HR)','คนพิการ (สมุทรปราการ)')then 'Delete' "+
"when q_count.Dept like '%การตลาด%' then 'MAR' "+
"when q_count.Dept like '%ลูกค้าสัมพันธ์%' then 'CUS' "+
"else q_count.Dept end <> 'Delete'"+
"and q_count.TimeLate is not null"+
"--and q_count.PersonCode = 'LPSS168'"+
"GROUP BY q_count.PersonCode"+
")as q_lateCount on q_main.PersonCode = q_lateCount.PersonCode"+
"WHERE"+
"q_main.holiday_date is null and"+
"case "+
"when q_main.Dept in( 'คนพิการ (HR)','คนพิการ (สมุทรปราการ)' )then 'คนพิการ' "+
"when q_main.PersonID in('17694','12845') then 'ACC'"+
"when q_main.Dept like '%พิการ%' and q_main.Dept not in('คนพิการ (HR)','คนพิการ (สมุทรปราการ)')then 'Delete' "+
"when q_main.Dept like '%การตลาด%' then 'MAR' "+
"when q_main.Dept like '%ลูกค้าสัมพันธ์%' then 'CUS' "+
"else q_main.Dept end <> 'Delete'"+
"and q_main.TimeLate is not null"+
"ORDER BY q_main.Dept, q_main.ScanTime desc"

            , sqlconn);
            DataTable GroupResult = new DataTable();
            q_result.Fill(GroupResult);
            List<HD_PD_Test_ViewModel> listTest = new List<HD_PD_Test_ViewModel>();
            foreach (DataRow Row in GroupResult.Rows)
            {
                listTest.Add(new HD_PD_Test_ViewModel(){
                    PersonCode = Row["PersonCode"].ToString(),
                    Dept = Row["Dept"].ToString(),
                    CompanyCode = Row["CompanyCode"].ToString(),
                    Fullname = Row["Fullname"].ToString(),
                    LateCount = int.Parse(Row["LateCount"].ToString()),
                    ScanTime = Row["ScanTime"].ToString(),
                    TimeScanActive = int.Parse(Row["TimeScanActive"].ToString())
                });
            }

            return Json(listTest);
        }
        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLate_LPS_db>> GetLateLps([FromRoute] string getDate)
        {
            try
            {
                var GetData = await _TimeLateLps_Repository.GetById(getDate);
                var GetResult = GetData.ToList();
                return GetResult;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLateCom_LPS_db>> GetLateComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLateComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLost_LPS_db>> GetLostLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeLostLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLostCom_LPS_db>> GetLostComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLostComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeOtherLeaveLps_db>> GetOtherLeaveLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeLeaveOtherLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeOtherLeaveComLps_db>> GetOtherLeaveComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLeaveOtherComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeVacationLeaveLps_db>> GetVacationLeaveLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeLeaveVacationLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeVacationLeaveComLps_db>> GetVacationLeaveComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLeaveVacationComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeSickLeaveLps_db>> GetSickLeaveLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeLeaveSickLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeSickLeaveComLps_db>> GetSickLeaveComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLeaveSickComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimePersonalLeaveLps_db>> GetPersLeaveLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeLeavePersLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimePersonalLeaveComLps_db>> GetPersLeaveComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeLeavePersComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeListYear_LPS_db>> GetListYearLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeListYearLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeListYearCom_LPS_db>> GetListYearComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeListYearComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeList30DayCom_LPS_db>> GetList30DayComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeList30DayComLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeList30Day_LPS_db>> GetList30DayLps([FromRoute] string getDate)
        {
            try
            {
                return await _TimeList30DayLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeDeptListOfComToday_db>> GetDeptListComLps([FromRoute] string getDate, string getCompany)
        {
            try
            {
                return await _TimeDeptListOfCom_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}")]
        [HttpGet]
        public async Task<HD_PD_TimeOverAllToday_LPS_db> GetOverAllLpsToday([FromRoute] string getDate)
        {
            try
            {
                return await _TimeOverAllTodayLps_Repository.GetById(getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<HD_PD_TimeOverAllComToday_LPS_db> GetOverAllComLpsToday([FromRoute] string getDate, [FromRoute] string getCompany)
        {
            try
            {
                return await _TimeOverAllComTodayLps_Repository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //----------------------------^^ LPS ^^--------------------------------

        [Route("/[controller]/[action]")]
        public IActionResult GetMaxDate()
        {
            return new JsonResult(_db.HD_View_TimeMaxDateImport);
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeOtherLeave_db>> GetLeaveOther([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLeaveOther_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeVacationLeave_db>> GetLeaveVacation([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLeaveVacation_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeSickLeave_db>> GetLeaveSick([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLeaveSick_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimePersonalLeave_db>> GetLeavePersonal([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLeavePers_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getShift}")]
        [HttpGet]
        public async Task<JsonResult> GetAutoTime([FromRoute] string getDate, [FromRoute] int getShift)
        {
            try
            {
                return Json(await _TimeAutoBmw_ValuesRepository.GetById(getDate, getShift));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_TimeAutoValueBmw_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLostBmw_db>> GetLostBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLost_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeLateDayBmw_db>> GetLateBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeLate_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeAllListMonthBmw_db>> GetAllListMonthBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeAllListMonthBmw_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeAll30DayBmw_db>> GetAll30DayBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeAll30DayBmw_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeDeptListDayBmw_db>> GetDeptListDayBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeDeptListDayBmw_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getshift}")]
        [HttpGet]
        public async Task<List<HD_PD_TimeAllPercentBmw_db>> GetAllPercentBmwByDate([FromRoute] string getdate, [FromRoute] int getshift)
        {
            try
            {
                return await _TimeAllPercentBmw_ValuesRepository.GetById(getdate, getshift);
            }
            catch (System.Exception)
            {
                throw;
            }
        }



    }
}