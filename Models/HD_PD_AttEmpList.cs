using System;

namespace HrDashboard.Models
{
    public class HD_PD_AttEmpList
    {
        public string WorkDate { get; set; }
        public string FullAttStatus { get; set; }
        public string LeaveFull { get; set; }
        public int YearLost { get; set; }
        public int YearLate { get; set; }
        public int YearLeave { get; set; }
        public int YearPLeave { get; set; }
        public int YearSLeave { get; set; }
        public int YearALeave { get; set; }
        public int YearOLeave { get; set; }
        public int MonthLost { get; set; }
        public int MonthLate { get; set; }
        public int MonthLeave { get; set; }
        public int MonthPLeave { get; set; }
        public int MonthSLeave { get; set; }
        public int MonthALeave { get; set; }
        public int MonthOLeave { get; set; }
        public string Late { get; set; }
        public string PersonCode { get; set; }
        public string PersonCardID { get; set; }
        public string Fullname { get; set; }
        public string DeptGroup { get; set; }
    }
}