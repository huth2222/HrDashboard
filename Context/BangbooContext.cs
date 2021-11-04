using HrDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HrDashboard.Context
{
    public class BangbooContext : DbContext
    {
        public BangbooContext(DbContextOptions<BangbooContext> options) : base(options) { }
        public DbSet<HD_View_TargetDetail> HD_View_TargetDetail { get; set; }
        public DbSet<HD_Account> HD_Account { get; set; }
        public DbSet<HD_View_TimeMaxDateImport> HD_View_TimeMaxDateImport { get; set; }
        public DbSet<MN_EmpShift> MN_EmpShift { get; set; }
        public DbSet<MN_EmpShiftTemp> MN_EmpShiftTemp { get; set; }
        public DbSet<HD_TimeSiteInOut> HD_TimeSiteInOut { get; set; }
        public DbSet<MN_Holiday> MN_Holiday { get; set; }
        public DbSet<MN_EmpLeave> MN_EmpLeave { get; set; }  
        public DbSet<AP_View_CheckInImport> AP_View_CheckInImport { get; set; }
        public DbSet<HD_Find> HD_Find { get; set; }
        public DbSet<MN_View_Company> MN_View_Company { get; set; }        
    }
}