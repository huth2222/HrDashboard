using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TargetDetail_db
    {
        public string company_Code { get; set; }
        public int sex_man { get; set; }
        public int sex_wo { get; set; }
        public int quantity { get; set; }
    }
}