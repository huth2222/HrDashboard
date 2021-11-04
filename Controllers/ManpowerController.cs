using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HrDashboard.Models;
using HrDashboard.Models.Repository;
using HrDashboard.Context;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace HrDashboard.Controllers
{
    public class ManpowerController : Controller
    {
        private readonly BangbooContext _db;
        public const string SessionCompany = "_Company";
        private readonly PD_ManAgeRangeSite_Repository _ManAgeRangeSite_Repository;
        private readonly PD_ManContractSite_Repository _ManContractSite_Repository;
        private readonly PD_ManGenderSite_Repository _ManGenderSite_Repository;
        private readonly PD_ManDeptSite_Repository _ManDeptSite_Repository;
        private readonly PD_ManListCusSite_ValuesRepository _ManListCusSite_ValuesRepository;
        private readonly PD_ManListMonthSite_ValuesRepository _ManListMonthSite_ValuesRepository;
        private readonly PD_ManGenderSite_ValuesRepository _ManGenderSite_ValuesRepository;
        private readonly PD_ManTodaySite_ValuesRepository _ManTodaySite_ValuesRepository;
        private readonly PD_ManListSite_ValuesRepository _ManListSite_ValuesRepository;
        private readonly PD_ManListDeptLps_ValuesRepository _ManListDeptLps_ValuesRepository;
        private readonly PD_ManListMonthLps_ValuesRepository _ManListMonthLps_ValuesRepository;
        private readonly PD_ManGenderLps_ValuesRepository _ManGenderLps_ValuesRepository;
        private readonly PD_ManTodayLps_ValuesRepository _ManTodayLps_ValuesRepository;
        private readonly PD_siteDept_ValuesRepository _siteDept_ValuesRepository;
        private readonly PD_ListMonthinfoDetail_ValuesRepository _ListMIDValuesRepository;
        private readonly PD_GenderDetail_ValuesRepository _GenderDetailValuesRepository;
        private readonly PD_ListDept_ValuesRepository _ListDeptValuesRepository;
        private readonly PD_Gender_ValuesRepository _GenderRepository;
        private readonly PD_TargetDetail_ValuesRepository _TargetDetailRepository;
        private readonly PD_BarList_ValuesRepository _BarListRepository;
        private readonly PD_BarTodday_ValuesRepository _MonthlyRepository;
        private readonly ILogger<ManpowerController> _logger;

        public ManpowerController(ILogger<ManpowerController> logger,
        BangbooContext context,
        PD_ManAgeRangeSite_Repository ManAgeRangeSite_Repository,
        PD_ManContractSite_Repository ManContractSite_Repository,
        PD_ManGenderSite_Repository ManGenderSite_Repository,
        PD_ManDeptSite_Repository ManDeptSite_Repository,
        PD_ManListCusSite_ValuesRepository ManListCusSite_ValuesRepository,
        PD_ManListMonthSite_ValuesRepository ManListMonthSite_ValuesRepository,
        PD_ManGenderSite_ValuesRepository ManGenderSite_ValuesRepository,
        PD_ManTodaySite_ValuesRepository ManTodaySite_ValuesRepository,
        PD_ManListSite_ValuesRepository ManListSite_ValuesRepository,
        PD_ManListDeptLps_ValuesRepository ManListDeptLps_ValuesRepository,
        PD_ManListMonthLps_ValuesRepository ManListMonthLps_ValuesRepository,
        PD_ManGenderLps_ValuesRepository ManGenderLps_ValuesRepository,
        PD_ManTodayLps_ValuesRepository ManTodayLps_ValuesRepository,
        PD_siteDept_ValuesRepository siteDept_ValuesRepository,
        PD_ListMonthinfoDetail_ValuesRepository ListMIDValuesRepository,
        PD_GenderDetail_ValuesRepository GenderDetailValuesRepository,
        PD_ListDept_ValuesRepository ListDeptValuesRepository,
        PD_Gender_ValuesRepository GenderRepository,
        PD_TargetDetail_ValuesRepository TargetDetailRepository,
        PD_BarList_ValuesRepository BarListRepository,
        PD_BarTodday_ValuesRepository MonthlyRepository
        )
        {
            _logger = logger;
            _db = context;
            _ManAgeRangeSite_Repository = ManAgeRangeSite_Repository ?? throw new ArgumentNullException(nameof(ManAgeRangeSite_Repository));
            _ManContractSite_Repository = ManContractSite_Repository ?? throw new ArgumentNullException(nameof(ManContractSite_Repository));
            _ManGenderSite_Repository = ManGenderSite_Repository ?? throw new ArgumentNullException(nameof(ManGenderSite_Repository));
            _ManDeptSite_Repository = ManDeptSite_Repository ?? throw new ArgumentNullException(nameof(ManDeptSite_Repository));
            _ManListCusSite_ValuesRepository = ManListCusSite_ValuesRepository ?? throw new ArgumentNullException(nameof(ManListCusSite_ValuesRepository));
            _ManListMonthSite_ValuesRepository = ManListMonthSite_ValuesRepository ?? throw new ArgumentNullException(nameof(ManListMonthSite_ValuesRepository));
            _ManGenderSite_ValuesRepository = ManGenderSite_ValuesRepository ?? throw new ArgumentNullException(nameof(ManGenderSite_ValuesRepository));
            _ManTodaySite_ValuesRepository = ManTodaySite_ValuesRepository ?? throw new ArgumentNullException(nameof(ManTodaySite_ValuesRepository));
            _ManListSite_ValuesRepository = ManListSite_ValuesRepository ?? throw new ArgumentNullException(nameof(ManListSite_ValuesRepository));
            _ManListDeptLps_ValuesRepository = ManListDeptLps_ValuesRepository ?? throw new ArgumentNullException(nameof(ManListDeptLps_ValuesRepository));
            _ManListMonthLps_ValuesRepository = ManListMonthLps_ValuesRepository ?? throw new ArgumentNullException(nameof(ManListMonthLps_ValuesRepository));
            _ManGenderLps_ValuesRepository = ManGenderLps_ValuesRepository ?? throw new ArgumentNullException(nameof(ManGenderLps_ValuesRepository));
            _ManTodayLps_ValuesRepository = ManTodayLps_ValuesRepository ?? throw new ArgumentNullException(nameof(ManTodayLps_ValuesRepository));
            _siteDept_ValuesRepository = siteDept_ValuesRepository ?? throw new ArgumentNullException(nameof(siteDept_ValuesRepository));
            _ListMIDValuesRepository = ListMIDValuesRepository ?? throw new ArgumentNullException(nameof(ListMIDValuesRepository));
            _GenderDetailValuesRepository = GenderDetailValuesRepository ?? throw new ArgumentNullException(nameof(GenderDetailValuesRepository));
            _ListDeptValuesRepository = ListDeptValuesRepository ?? throw new ArgumentNullException(nameof(ListDeptValuesRepository));
            _GenderRepository = GenderRepository ?? throw new ArgumentNullException(nameof(GenderRepository));
            _TargetDetailRepository = TargetDetailRepository ?? throw new ArgumentNullException(nameof(TargetDetailRepository));
            _BarListRepository = BarListRepository ?? throw new ArgumentNullException(nameof(BarListRepository));
            _MonthlyRepository = MonthlyRepository ?? throw new ArgumentNullException(nameof(MonthlyRepository));
        }
        public IActionResult BMW()
        {
            HttpContext.Session.SetString(SessionCompany, "BMW");
            return View();  
        }
        public IActionResult LPS()
        {
            HttpContext.Session.SetString(SessionCompany, "LPS");
            return View(); 
        }
        public IActionResult Target()
        {
            if (HttpContext.Session.GetString("_Company") == null)
            {
                return RedirectToAction("Login", "Intro");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Target([FromForm] int companys, [FromForm] DateTime startdate, [FromForm] DateTime enddate, [FromForm] int targetValue, [FromForm] int empInfo)
        {
            CultureInfo culture = new CultureInfo("en-US");
            int startYear = 0;
            if (startdate.Year < 2000)
            {
                startYear = startdate.Year + 543;
            }
            else if (startdate.Year > 2500)
            {
                startYear = startdate.Year - 543;
            }
            else
            {
                startYear = startdate.Year;
            }
            string sDate = startYear.ToString("0000") + '-' + startdate.Month.ToString("00") + "-" + startdate.Day.ToString("00");
            DateTime _startdate = Convert.ToDateTime(sDate, culture);
            DateTime? _enddate = null;
            if (enddate.Year > 1)
            {


                int endYear = 0;
                if (enddate.Year < 2000)
                {
                    endYear = enddate.Year + 543;
                }
                else if (enddate.Year > 2500)
                {
                    endYear = enddate.Year - 543;
                }
                else
                {
                    endYear = enddate.Year;
                }
                _enddate = Convert.ToDateTime(endYear.ToString("0000") + '-' + enddate.Month.ToString("00") + "-" + enddate.Day.ToString("00"), culture);
            }
            int valueKey = 1;
            var LastKey = _db.HD_Find.OrderByDescending(o => o.find_id).FirstOrDefault();
            string findKey = LastKey.find_id.Substring(2, 8);
            string sToday = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
            if (findKey == sToday)
            {
                valueKey = int.Parse(LastKey.find_id.Substring(10, 3)) + 1;
            }
            string pk = "FD" + sToday + valueKey.ToString("000");

            //string sDate = startdate.Year.ToString("0000") + "-" + startdate.Month.ToString("00") + "-" + startdate.Day.ToString("00");
            // var comName = _db.MN_View_Company.Where(c => c.ID_Company.Equals(companys)).FirstOrDefault();
            // string sComName = comName.Company_Code;
            // var Target = await _ManListCusSite_ValuesRepository.GetById(sDate, sComName, "all");

            string empId = HttpContext.Session.GetString("_UserID");
            if (companys > 0 && targetValue > 0)
            {
                int target = empInfo + targetValue;
                HD_Find modelAdd = new HD_Find
                {
                    find_id = pk,
                    CompanyID = companys,
                    target_date_start = _startdate,
                    target_date_end = _enddate,
                    carete_datetime = DateTime.Now,
                    create_by = empId,
                    quantity = targetValue,
                    target_value = target,
                    status = true
                };
                _db.HD_Find.Add(modelAdd);
                _db.SaveChanges();
            }
            return View();
        }

        [Route("/[controller]/[action]/{getSite}/{getDate}")]
        [HttpGet]
        public async Task<List<HD_PD_ManAgeRange_Site_db>> GetManAgeByRange([FromRoute] string getSite, [FromRoute] string getDate)
        {
            try
            {
                return await _ManAgeRangeSite_Repository.GetById(getSite, getDate);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getSite}/{getDate}/{parts}/{shift_id}")]
        [HttpGet]
        public async Task<List<HD_PD_ManContract_Site_db>> GetManContractSiteByDept([FromRoute] string getSite, [FromRoute] string getDate, [FromRoute] string parts, [FromRoute] string shift_id)
        {
            try
            {
                return await _ManContractSite_Repository.GetById(getSite, getDate, parts, shift_id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getSite}/{getDate}/{parts}/{shift_id}")]
        [HttpGet]
        public async Task<JsonResult> GetManGenderSiteByShift([FromRoute] string getSite, [FromRoute] string getDate, [FromRoute] string parts, [FromRoute] int shift_id)
        {
            try
            {
                return Json(await _ManGenderSite_Repository.GetById(getSite, getDate, parts, shift_id));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManGender_Site_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getSite}/{getDate}/{parts}/{shift_id}")]
        [HttpGet]
        public async Task<List<HD_PD_ManDept_Site_db>> GetManDeptSiteByDept([FromRoute] string getSite, [FromRoute] string getDate, [FromRoute] string parts, [FromRoute] string shift_id)
        {
            try
            {
                return await _ManDeptSite_Repository.GetById(getSite, getDate, parts, shift_id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{companyId}")]
        [HttpGet]
        public IActionResult GetManCompanyNameById([FromRoute] int companyId)
        {

            var companyName = _db.MN_View_Company.Where(c => c.ID_Company.Equals(companyId)).FirstOrDefault();
            return Json(companyName);

        }
        [Route("/[controller]/[action]/{getGroup}/{getZone}")]
        [HttpGet]
        public IActionResult GetManCompanyById([FromRoute] int getGroup, [FromRoute] string getZone)
        {
            if (getGroup == 1)
            {
                var company = _db.MN_View_Company.Where(c => c.Company_Group.Equals("LPS GROUP")).ToList();
                return Json(company);
            }
            else if (getGroup == 2)
            {
                var company = _db.MN_View_Company.Where(c => c.Site_Zone.Equals(getZone)).ToList();
                return Json(company);
            }
            else
            {
                var company = _db.MN_View_Company.ToList();
                return Json(company);
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompanyId}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListCustumer_Site_db>> GetManListCusSiteFindByDate([FromRoute] string getDate, [FromRoute] int getCompanyId)
        {
            var comName = _db.MN_View_Company.Where(c => c.ID_Company.Equals(getCompanyId)).FirstOrDefault();
            string company = comName.Company_Code.ToString();
            try
            {
                return await _ManListCusSite_ValuesRepository.GetById(getDate, company, "all");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}/{getZone}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListCustumer_Site_db>> GetManListCusSiteByDate([FromRoute] string getDate, [FromRoute] string getCompany, string getZone)
        {
            try
            {
                return await _ManListCusSite_ValuesRepository.GetById(getDate, getCompany, getZone);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}/{getZone}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListMonth_Site_db>> GetManListMonthSiteByDate([FromRoute] string getDate, [FromRoute] string getCompany, [FromRoute] string getZone)
        {
            try
            {
                return await _ManListMonthSite_ValuesRepository.GetById(getDate, getCompany, getZone);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Route("/[controller]/[action]/{getDate}/{getCompany}/{getZone}")]
        [HttpGet]
        public async Task<JsonResult> GetManGenderSiteByDate([FromRoute] string getDate, [FromRoute] string getCompany, [FromRoute] string getZone)
        {
            try
            {
                return Json(await _ManGenderSite_ValuesRepository.GetById(getDate, getCompany, getZone));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerGender_LPS_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}/{getZone}")]
        [HttpGet]
        public async Task<JsonResult> GetManMonthlySiteByDate([FromRoute] string getDate, [FromRoute] string getCompany, [FromRoute] string getZone)
        {
            try
            {
                return Json(await _ManTodaySite_ValuesRepository.GetById(getDate, getCompany, getZone));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerToday_LPS_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getGroup}/{getCompany}/{getZone}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListSite_LPS_db>> GetManListSiteLpsByDate([FromRoute] string getDate, [FromRoute] int getGroup, [FromRoute] string getCompany, string getZone)
        {
            try
            {
                return await _ManListSite_ValuesRepository.GetById(getDate, getGroup, getCompany, getZone);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListDept_LPS_db>> GetManListDeptLpsByDate([FromRoute] string getDate, [FromRoute] string getCompany)
        {
            try
            {
                return await _ManListDeptLps_ValuesRepository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerListMonth_LPS_db>> GetManListMonthLpsByDate([FromRoute] string getDate, [FromRoute] string getCompany)
        {
            try
            {
                return await _ManListMonthLps_ValuesRepository.GetById(getDate, getCompany);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<JsonResult> GetManGenderLpsByDate([FromRoute] string getDate, [FromRoute] string getCompany)
        {
            try
            {
                return Json(await _ManGenderLps_ValuesRepository.GetById(getDate, getCompany));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerGender_LPS_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getDate}/{getCompany}")]
        [HttpGet]
        public async Task<JsonResult> GetManMonthlyLpsByDate([FromRoute] string getDate, [FromRoute] string getCompany)
        {
            try
            {
                return Json(await _ManTodayLps_ValuesRepository.GetById(getDate, getCompany));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerToday_LPS_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_ListDeptSite_db>> GetSiteDeptByDate([FromRoute] string getdate, [FromRoute] string getsite)
        {
            try
            {
                return await _siteDept_ValuesRepository.GetById(getdate, getsite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_GenderDetail_db>> GetGenderDetailByDate([FromRoute] string getdate, [FromRoute] string getsite)
        {
            try
            {
                return await _GenderDetailValuesRepository.GetById(getdate, getsite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_ListDept_db>> GetListDeptByDate([FromRoute] string getdate, [FromRoute] string getsite)
        {
            try
            {
                return await _ListDeptValuesRepository.GetById(getdate, getsite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_ListMonthInfoDetail_db>> GetListMonthInfoDetailByDate([FromRoute] string getdate, [FromRoute] string getsite)
        {
            try
            {
                return await _ListMIDValuesRepository.GetById(getdate, getsite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<JsonResult> GetGenderByDate([FromRoute] string getDate, [FromRoute] string getSite)
        {
            try
            {
                return Json(await _GenderRepository.GetById(getDate, getSite));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerGender_db());
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_TargetDetail_db>> GetTargetDetailByDate([FromRoute] string getdate, [FromRoute] string getSite)
        {
            try
            {
                return await _TargetDetailRepository.GetById(getdate, getSite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public JsonResult GetTargetByDate([FromRoute] string getdate, [FromRoute] string getSite)
        {
            string val = getdate.Substring(0, 7);
            return Json(_db.HD_View_TargetDetail.Where(tar => tar.target_months.Equals(val)).ToList());
        }

        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<JsonResult> GetMonthlyByMonth([FromRoute] string getDate, [FromRoute] string getSite)
        {
            try
            {
                return Json(await _MonthlyRepository.GetById(getDate, getSite));
            }
            catch (System.Exception)
            {
                return Json(new HD_PD_ManpowerToday_db());
                throw;
            }
        }
        [Route("/[controller]/[action]/{getdate}/{getsite}")]
        [HttpGet]
        public async Task<List<HD_PD_ManpowerMonthList_db>> GetBarListById([FromRoute] string getdate, [FromRoute] string getSite)
        {

            try
            {
                return await _BarListRepository.GetById(getdate, getSite);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
