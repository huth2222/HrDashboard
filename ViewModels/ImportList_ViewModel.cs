using System.Collections.Generic;
using HrDashboard.Models;

namespace HrDashboard.ViewModels
{
    public class ImportList_ViewModel
    {
       public List<MN_EmpShiftTemp> MN_EmpShiftTemp { get; set; }
       public MN_EmpShift MN_EmpShift { get; set; }
    }
}