using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TimeAutoValueBmw_db
    {
        [Key]
        public int ids { get; set; }
        public int timeins { get; set; }
        public int losts { get; set; }
        public int leaves { get; set; }
        public int time_lates { get; set; }
    }
}