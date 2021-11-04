using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class AP_View_CheckInImport
    {
        [Key]
        public string PersonCardID { get; set; }
        public DateTime DateInOut { get; set; }
        public int shift_emp { get; set; }
        public string sTime { get; set; }
    }
}