using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TimeListYear_LPS_db
    {
        [Key]
        public int getYear { get; set; }
        public int info { get; set; }
        public int timeIn { get; set; }
        public int timeLate { get; set; }
        public int leaves { get; set; }
        public int losts { get; set; }
    }
}