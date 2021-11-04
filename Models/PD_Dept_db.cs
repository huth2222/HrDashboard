using System.ComponentModel.DataAnnotations;
namespace HrDashboard.Models
{
    public class PD_Dept_db
    {
        public string dept { get; set; }
        public int all_emp { get; set; }
        public int checkin { get; set; }
        public int lost { get; set; }
    }
}