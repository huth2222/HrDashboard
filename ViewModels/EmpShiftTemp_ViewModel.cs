using System;

namespace HrDashboard.ViewModels
{
    public class EmpShiftTemp_ViewModel
    {   
        public int emp_shift_temp_id { get; set; }
        public string emp_id { get; set; }
        public string site_code { get; set; }
        public int old_shift_id { get; set; }
        public DateTime old_start_date { get; set; }
        public DateTime? old_end_date { get; set; }
        public int new_shift_id { get; set; }
        public DateTime new_start_date { get; set; }
        public DateTime? new_end_date { get; set; }
        public string type_name { get; set; }
    }
}