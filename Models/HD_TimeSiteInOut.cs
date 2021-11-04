using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_TimeSiteInOut
    {
        [Key]
        public int inout_id { get; set; }
        public int emp_id { get; set; }
        public DateTime datetime_inout { get; set; }
        public DateTime? create_datetime { get; set; }
        public string create_by { get; set; }
    }
}