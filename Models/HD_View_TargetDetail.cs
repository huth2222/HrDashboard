using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_View_TargetDetail
    {
        [Key]
        public string find_id { get; set; }
        public int Cmb1ID { get; set; }
        public int sex_man { get; set; }
        public int sex_wo { get; set; }
        public int sex_other { get; set; }
        public int quantity { get; set; }
        public int age_limt { get; set; }
        public string Cmb1NameT { get; set; }
        public string earmark { get; set; }
        public string target_months { get; set; }
    }
}