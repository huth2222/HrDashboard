using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HrDashboard.Models;
using HrDashboard.ViewModels;
using HrDashboard.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace HrDashboard.Controllers
{
    public class ImportController : Controller
    {
        private readonly BangbooContext _db;
        private readonly CloudContext _CloudDb;
        public ImportController(BangbooContext context,CloudContext CloudDb){
            _CloudDb = CloudDb;
            _db = context;
        }
        public IActionResult Index(){
            if (HttpContext.Session.GetString("_Company") == null)
            {
                return RedirectToAction("Login", "Intro");
            }
            else
            {
                ImportList_ViewModel mainViewModel = new ImportList_ViewModel();
                mainViewModel.MN_EmpShiftTemp = _db.MN_EmpShiftTemp.ToList();
                return View(mainViewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var userId = HttpContext.Session.GetString("_UserID");
            var siteCode = HttpContext.Session.GetString("_Company");
            if(siteCode == "all"){
                siteCode = "LPS";
            }

            
            using (var steam = new MemoryStream())
            {
                await file.CopyToAsync(steam);
                using (var package = new ExcelPackage(steam))
                {
                    ExcelWorksheet sheetShift = package.Workbook.Worksheets["Shift"];
                    int rowShift = sheetShift.Dimension.Rows;
          
                    var list = new List<MN_EmpShift>();
                    if (rowShift > 2)
                    {
                        for (int row = 3; row <= rowShift; row++)
                        {
                            var empId = sheetShift.Cells[row, 4].Value.ToString().Trim();
                            string sShift = sheetShift.Cells[row, 5].Value.ToString().Trim();
                            int shiftId = 0;
                            if (sShift == "A")
                            {
                                shiftId = 1;
                            }
                            else if (sShift == "B")
                            {
                                shiftId = 2;
                            }
                            else
                            {
                                shiftId = 1;
                            }

                            var sDate = sheetShift.Cells[row, 6].Value.ToString().Trim();
                            CultureInfo culture = new CultureInfo("en-US");
                            DateTime startDate = Convert.ToDateTime(sDate, culture);

                            //var empUpdate = _db.MN_EmpShift.Where(u => u.emp_id.Equals(empId) && u.emp_shift_id != shiftId && u.start_date.Equals(startDate)).FirstOrDefault();

                            //var test = _db.MN_EmpShift.Where(t => t.emp_id.Equals(empId) && t.shift_id.Equals(shiftId)).ToList();
                            var empDuplicate = _db.MN_EmpShift.Where(d => d.emp_id.Equals(empId) && d.shift_id.Equals(shiftId) &&
                                                d.start_date >= startDate && (d.end_date == null || d.end_date <= startDate)).ToList();
                            var empNew = _db.MN_EmpShift.Where(d => d.emp_id.Equals(empId)).FirstOrDefault();
                            if (empDuplicate.Count == 0)
                            {
                                var empResult = _db.MN_EmpShift.Where(r => r.emp_id.Equals(empId) && r.shift_id != shiftId && r.end_date == null).FirstOrDefault();

                                if (empResult != null)
                                {

                                        empResult.end_date = startDate.AddDays(-1);
                                        _db.SaveChanges();
                                    

                                    MN_EmpShift modelAdd = new MN_EmpShift()
                                    {
                                        emp_id = empId,
                                        site_code = siteCode,
                                        shift_id = shiftId,
                                        start_date = startDate,
                                        create_datetime = DateTime.Now,
                                        create_by = userId
                                    };

                                    _db.MN_EmpShift.Add(modelAdd);
                                    _db.SaveChanges();

                                }
                                else if (empNew == null)
                                {

                                    MN_EmpShift modelAdd = new MN_EmpShift()
                                    {
                                        emp_id = empId,
                                        site_code = siteCode,
                                        shift_id = shiftId,
                                        start_date = startDate,
                                        create_datetime = DateTime.Now,
                                        create_by = userId
                                    };

                                    _db.MN_EmpShift.Add(modelAdd);
                                    _db.SaveChanges();

                                }
                            }
                            var empUpdate = _db.MN_EmpShift.Where(u => u.emp_id.Equals(empId) && u.shift_id.Equals(shiftId) && (u.start_date > startDate || u.end_date >= startDate)).ToList();
                            if (empUpdate.Count > 0)
                            {

                                foreach (var item in empUpdate)
                                {
                                    var empTemp = _db.MN_EmpShiftTemp.Where(t => t.emp_id.Equals(item.emp_id)
                                    && t.old_shift_id.Equals(item.shift_id) && t.old_start_date.Equals(item.start_date) && t.old_end_date.Equals(item.end_date)
                                    && t.new_shift_id.Equals(shiftId) && t.new_start_date.Equals(startDate) && t.new_end_date.Equals(item.end_date)
                                    ).FirstOrDefault();
                                    if (empTemp == null)
                                    {
                                        MN_EmpShiftTemp modelTemp = new MN_EmpShiftTemp()
                                        {
                                            emp_id = item.emp_id,
                                            old_emp_shift_id = item.emp_shift_id,
                                            site_code = siteCode,
                                            old_shift_id = item.shift_id,
                                            old_start_date = item.start_date,
                                            old_end_date = item.end_date,
                                            new_shift_id = shiftId,
                                            new_start_date = startDate,
                                            new_end_date = item.end_date,
                                            type_name = "DataError",
                                            create_datetime = DateTime.Now,
                                            create_by = userId
                                        };
                                        _db.MN_EmpShiftTemp.Add(modelTemp);
                                        _db.SaveChanges();
                                    }
                                }
                            }

                        }
                    }


                    /*******vvv*********************************************vvv********/


                    ExcelWorksheet sheetTime = package.Workbook.Worksheets["Time"];
                    int rowTime = sheetTime.Dimension.Rows;
                    if (rowTime > 2)
                    {
                        for (int row = 3; row <= rowTime; row++)
                        {
                            int empIdTime = int.Parse(sheetTime.Cells[row, 4].Value.ToString().Trim());
                            string sTime = sheetTime.Cells[row, 5].Value.ToString().Trim();

                            CultureInfo culture = new CultureInfo("en-US");
                            DateTime timeInOut = Convert.ToDateTime(sTime, culture);

                            //var empUpdate = _db.MN_EmpShift.Where(u => u.emp_id.Equals(empId) && u.emp_shift_id != shiftId && u.start_date.Equals(startDate)).FirstOrDefault();

                            //var test = _db.MN_EmpShift.Where(t => t.emp_id.Equals(empId) && t.shift_id.Equals(shiftId)).ToList();
                            var empDuplicate = _db.HD_TimeSiteInOut.Where(t => t.emp_id.Equals(empIdTime) && t.datetime_inout.Equals(timeInOut)).FirstOrDefault();
                            if (empDuplicate == null)
                            {
                                HD_TimeSiteInOut model = new HD_TimeSiteInOut
                                {
                                    emp_id = empIdTime,
                                    datetime_inout = timeInOut,
                                    create_datetime = DateTime.Now,
                                    create_by = userId
                                };
                                _db.HD_TimeSiteInOut.Add(model);
                                _db.SaveChanges();
                            }
                        }

                    }
                    /*******vvv*********************************************vvv********/
                    ExcelWorksheet sheetHoliday = package.Workbook.Worksheets["Holiday"];
                    int rowHoliday = sheetHoliday.Dimension.Rows;
                    if (rowHoliday > 2)
                    {
                        for (int row = 3; row <= rowHoliday; row++)
                        {
                            string sDateTime = sheetHoliday.Cells[row, 3].Value.ToString().Trim();
                            string remark = sheetHoliday.Cells[row, 4].Value.ToString().Trim();

                            CultureInfo culture = new CultureInfo("en-US");
                            DateTime getDate = Convert.ToDateTime(sDateTime, culture);

                            //var empUpdate = _db.MN_EmpShift.Where(u => u.emp_id.Equals(empId) && u.emp_shift_id != shiftId && u.start_date.Equals(startDate)).FirstOrDefault();

                            //var test = _db.MN_EmpShift.Where(t => t.emp_id.Equals(empId) && t.shift_id.Equals(shiftId)).ToList();
                            var Duplicate = _db.MN_Holiday.Where(h => h.holiday_date.Equals(getDate)).FirstOrDefault();
                            if (Duplicate == null)
                            {
                                MN_Holiday model = new MN_Holiday
                                {
                                    holiday_date = getDate,
                                    remark = remark,
                                    status = true,
                                    create_datetime = DateTime.Now,
                                    create_by = userId
                                };
                                _db.MN_Holiday.Add(model);
                                _db.SaveChanges();
                            }

                        }
                    }

                    /*******^^^*********************************************^^^********/
                    ExcelWorksheet sheetLeave = package.Workbook.Worksheets["Leave"];
                    int rowLeave = sheetLeave.Dimension.Rows;
                    if (rowLeave > 3)
                    {


                        for (int row = 4; row <= rowLeave; row++)
                        {
                            string empId = sheetLeave.Cells[row, 1].Value.ToString().Trim();
                            string lFrom = sheetLeave.Cells[row, 7].Value.ToString().Trim();
                            string tFrom = sheetLeave.Cells[row, 8].Value.ToString().Trim();
                            string mainID = sheetLeave.Cells[row, 9].Value.ToString().Trim();
                            string leaveID = sheetLeave.Cells[row, 10].Value.ToString().Trim();

                            CultureInfo culture = new CultureInfo("en-US");
                            DateTime getLFrom = Convert.ToDateTime(lFrom, culture);
                            DateTime getTFrom = Convert.ToDateTime(tFrom, culture);

                            //var empUpdate = _db.MN_EmpShift.Where(u => u.emp_id.Equals(empId) && u.emp_shift_id != shiftId && u.start_date.Equals(startDate)).FirstOrDefault();

                            //var test = _db.MN_EmpShift.Where(t => t.emp_id.Equals(empId) && t.shift_id.Equals(shiftId)).ToList();
                            var Duplicate = _db.MN_EmpLeave.Where(el => el.emp_id.Equals(int.Parse(empId)) && el.Leave_DateS.Equals(getLFrom)).FirstOrDefault();
                            if (Duplicate == null)
                            {
                                MN_EmpLeave model = new MN_EmpLeave
                                {
                                    emp_id = int.Parse(empId),
                                    ID_Leave = int.Parse(mainID),
                                    custumer_leave_id = int.Parse(leaveID),
                                    Leave_DateS = getLFrom,
                                    Leave_DateE = getTFrom,
                                    create_datetime = DateTime.Now,
                                    create_by = userId
                                };
                                _db.MN_EmpLeave.Add(model);
                                _db.SaveChanges();
                            }

                        }
                    }

                    /*******^^^*********************************************^^^********/
                }
            }

            //**********************Import Assambly vvv **************
            var assam = _db.AP_View_CheckInImport.ToList();
            if(assam != null){
                foreach (var item in assam)
                {
                    var push = _CloudDb.AP_EmpPoint.Where(p => p.emp_id.Equals(int.Parse(item.PersonCardID))).FirstOrDefault();
                    if(push != null){
                        AP_CheckIn apModel = new AP_CheckIn
                        {
                            emp_id = push.emp_id,
                            working_datetime = item.DateInOut,
                            center_id = push.center_id,
                            row_id = push.row_id,
                            status = true
                        };
                        _CloudDb.AP_CheckIn.Add(apModel);
                        _CloudDb.SaveChanges();
                    }
                }
            }

            //**********************Import Assambly ^^^ **************
            ImportList_ViewModel mainViewModel = new ImportList_ViewModel();
            mainViewModel.MN_EmpShiftTemp = _db.MN_EmpShiftTemp.ToList();
// _db.MN_EmpShiftTemp.ToList();
            return View(mainViewModel);
        }
        [Route("/[controller]/[action]/{id}")]
        public IActionResult DelTemp([FromRoute]int id){
            var temp = _db.MN_EmpShiftTemp.Where(t => t.emp_shift_temp_id.Equals(id)).FirstOrDefault();
            if(temp != null){
                _db.MN_EmpShiftTemp.Remove(temp);
                _db.SaveChanges();
            }           
            
            return new JsonResult("Success");
        }
        [HttpPost]
        public IActionResult Editdata(
            int emp_shift_temp_id, 
            int old_emp_shift_id, 
            int newShift,
            string newStartDate,
            string newEndDate
            ){
            var modelUpdate = _db.MN_EmpShift.Where(u => u.emp_shift_id.Equals(old_emp_shift_id)).FirstOrDefault();
            CultureInfo culture = new CultureInfo("en-US");
            DateTime startDate = Convert.ToDateTime(newStartDate, culture);
            DateTime endDate = Convert.ToDateTime(newEndDate, culture);
            if(modelUpdate != null){               
                modelUpdate.shift_id = newShift;
                if(newStartDate != null){
                    modelUpdate.start_date = startDate;
                }
                if (newEndDate != null)
                {
                    modelUpdate.end_date = endDate;
                }
                _db.SaveChanges();
            }
            var empUpdate = _db.MN_EmpShift.Where(u => u.emp_shift_id.Equals(old_emp_shift_id) && (u.start_date <= startDate || u.end_date < startDate)).FirstOrDefault();
            if(empUpdate != null){
                var empTemp = _db.MN_EmpShiftTemp.Where(t => t.emp_shift_temp_id.Equals(emp_shift_temp_id)).FirstOrDefault();
                _db.MN_EmpShiftTemp.Remove(empTemp);
                _db.SaveChanges();
            }
            return RedirectToAction("Index","Import");
        }
        
        public IActionResult Cleardata(){
            var ClaerTemp = _db.MN_EmpShiftTemp.ToList();
            foreach (var item in ClaerTemp)
            {                
                _db.MN_EmpShiftTemp.Remove(item);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index","Import");
        }
    }
}