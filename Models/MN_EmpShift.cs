using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class MN_EmpShift
    {
        [Key]
        public int emp_shift_id { get; set; }
        public string emp_id { get; set; }
        public string site_code { get; set; }
        public int shift_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? create_datetime { get; set; }
        public string create_by { get; set; }
    }
}