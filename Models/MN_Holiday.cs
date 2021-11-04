using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class MN_Holiday
    {
        [Key]
        public int date_id { get; set; }
        public DateTime holiday_date { get; set; }
        public string remark { get; set; }
        public bool status { get; set; }
        public DateTime? create_datetime { get; set; }
        public string create_by { get; set; }
    }
}