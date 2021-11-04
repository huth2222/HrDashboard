using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TimeLateCom_LPS_db
    {
        [Key]
        public string PersonCode { get; set; }
        public string Dept { get; set; }
        public string CompanyCode { get; set; }
        public string Fullname { get; set; }
        public int LateCount { get; set; }
        public string ScanTime { get; set; }
    }
}