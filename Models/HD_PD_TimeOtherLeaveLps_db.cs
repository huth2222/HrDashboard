using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_PD_TimeOtherLeaveLps_db
    {
        [Key]
        public string Dept { get; set; }
        public string PersonCode { get; set; }
        public string Fullname { get; set; }
        public string LeaveNameT { get; set; }
        public string LeaveGroupName { get; set; }
    }
}