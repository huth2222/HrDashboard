using System.Linq;
using HrDashboard.Models;
using HrDashboard.ViewModels;
using HrDashboard.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HrDashboard.Controllers
{
    public class IntroController : Controller
    {
        BangbooContext _db;
        public const string SessionCompany = "_Company";
        public const string SessionLevelID = "_LevelID";
        public const string SessionUserID = "_UserID";
        public IntroController(BangbooContext context)
        {
            _db = context;
        }
        public IActionResult LPS()
        {
            HttpContext.Session.Clear();
            var emp = _db.HD_Account.Where(acc => acc.company_code.Equals("LPS") && acc.status.Equals(true)).FirstOrDefault();
            if (emp != null)
                {
                    HttpContext.Session.SetString(SessionCompany, "LPS");
                    return RedirectToAction("LPS", "Attendance");
                }else{
                    return RedirectToAction("Login", "Intro");
                }         
        }

        public IActionResult BMW()
        {
            HttpContext.Session.Clear();
            var emp = _db.HD_Account.Where(acc => acc.company_code.Equals("BMW") && acc.status.Equals(true)).FirstOrDefault();
            if (emp != null)
                {
                    HttpContext.Session.SetString(SessionCompany, "BMW");
                    return RedirectToAction("BMW", "Manpower");
                }else{
                    return RedirectToAction("Login", "Intro");
                }         
        }


        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Login_ViewModel user)
        {
            if (user != null)
            {
                var emp = _db.HD_Account.Where(acc => acc.emp_id.Equals(user.username) && acc.password.Equals(user.password) && acc.status.Equals(true)).FirstOrDefault();
                if (emp != null)
                {
                    HttpContext.Session.SetString(SessionUserID, emp.emp_id);
                    if (emp.company_code == "LPS")
                    {
                        HttpContext.Session.SetString(SessionCompany, "all");
                    }
                    else
                    {
                        HttpContext.Session.SetString(SessionCompany, emp.company_code);
                    }
                    HttpContext.Session.SetString(SessionLevelID, emp.level_id.ToString());

                    HD_Account model = new HD_Account
                    {
                        emp_id = emp.emp_id,
                        company_code = emp.company_code
                    };
                    return RedirectToAction("BMW", "Manpower");
                }
            }
            ModelState.AddModelError("password", "Username or Password is wrong");
            return View();
        }
    }
}