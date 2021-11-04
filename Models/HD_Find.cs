using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class HD_Find
    {
        [Key]
        public string find_id { get; set; }
        public int CompanyID { get; set; }
        public int quantity { get; set; }
        public string create_by { get; set; }
        public DateTime carete_datetime { get; set; }
        public bool status { get; set; }
        public DateTime target_date_start { get; set; }
        public DateTime? target_date_end { get; set; }
        public int target_value { get; set; }
        public int Cmb2ID { get; set; }
    }
}