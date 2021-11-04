using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_Account
    {
        [Key]
        public string emp_id { get; set; }
        public string company_code { get; set; }
        public string site_code { get; set; }
        public string password { get; set; }
        public int level_id { get; set; }
        public bool status { get; set; }
    }
}