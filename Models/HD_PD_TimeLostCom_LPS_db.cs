using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TimeLostCom_LPS_db
    {
        [Key]
        public string Dept { get; set; }
        public string PersonCode { get; set; }
        public string Fullname { get; set; }
    }
}