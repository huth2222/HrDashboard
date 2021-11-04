using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class AP_CheckIn
    {
        [Key]
        public int checkin_id { get; set; }
        public int emp_id { get; set; }
        public DateTime working_datetime { get; set; }
        public bool status { get; set; }
        public int center_id { get; set; }
        public int row_id { get; set; }
    }
}