using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_View_TimeMaxDateImport
    {
        [Key]
        public string TimeMinDate { get; set; }
        public string TimeMaxDate { get; set; }
        public string TimeMaxDateTimeFormat { get; set; }
        public string ShiftMaxDate { get; set; }
        public string ShiftMaxDateFormat { get; set; }
        public string maxDateSLeave { get; set; }
    }
}