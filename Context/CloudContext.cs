using HrDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HrDashboard.Context
{
    public class CloudContext : DbContext
    {
        public CloudContext(DbContextOptions<CloudContext> options) : base(options) { }
        public DbSet<AP_CheckIn> AP_CheckIn { get; set; }
        public DbSet<AP_EmpPoint> AP_EmpPoint { get; set; }        
    }
}