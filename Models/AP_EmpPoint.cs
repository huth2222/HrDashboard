using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class AP_EmpPoint
    {
        [Key]
        public int emp_id { get; set; }
        public int center_id { get; set; }
        public int row_id { get; set; }
        public int row_level_id { get; set; }
    }
}