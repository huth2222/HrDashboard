using System.ComponentModel.DataAnnotations;
namespace HrDashboard.Models
{
    public class HD_PD_ManpowerToday_db
    {
        public string months { get; set; }
        public int target { get; set; }
        public int info { get; set; }
        public int lost { get; set; }
    }
}