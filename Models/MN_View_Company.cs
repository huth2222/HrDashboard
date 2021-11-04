using System;
using System.ComponentModel.DataAnnotations;

namespace HrDashboard.Models
{
    public class MN_View_Company
    {
        [Key]
        public int ID_Company { get; set; }
        public string Company_Code { get; set; }
        public string Company_Group { get; set; }
        public string Site_Zone { get; set; }
        public int Time_Active { get; set; }
    }
}