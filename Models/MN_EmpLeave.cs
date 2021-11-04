using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class MN_EmpLeave
    {
        [Key]
        public int emp_leave_id { get; set; }
        public int emp_id { get; set; }
        public int ID_Leave { get; set; }
        public int custumer_leave_id { get; set; }
        public DateTime Leave_DateS { get; set; }
        public DateTime Leave_DateE { get; set; }
        public string leave_memo { get; set; }
        public DateTime? create_datetime { get; set; }
        public string create_by { get; set; }
    }
}