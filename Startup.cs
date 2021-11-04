using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrDashboard.Models.Repository;
using HrDashboard.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HrDashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<BangbooContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<CloudContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CloudDb")));

            services.AddScoped<PD_ManAgeRangeSite_Repository>();
            services.AddScoped<PD_ManContractSite_Repository>();
            services.AddScoped<PD_ManGenderSite_Repository>();
            services.AddScoped<PD_ManDeptSite_Repository>();
            services.AddScoped<PD_TimeLateComLps_Repository>();
            services.AddScoped<PD_TimeLateLps_Repository>();
            services.AddScoped<PD_TimeLostComLps_Repository>();
            services.AddScoped<PD_TimeLostLps_Repository>();
            services.AddScoped<PD_TimeLeaveOtherComLps_Repository>();
            services.AddScoped<PD_TimeLeaveOtherLps_Repository>();
            services.AddScoped<PD_TimeLeaveVacationComLps_Repository>();
            services.AddScoped<PD_TimeLeaveVacationLps_Repository>();
            services.AddScoped<PD_TimeLeaveSickComLps_Repository>();
            services.AddScoped<PD_TimeLeaveSickLps_Repository>();
            services.AddScoped<PD_TimeLeavePersComLps_Repository>();
            services.AddScoped<PD_TimeLeavePersLps_Repository>();
            services.AddScoped<PD_TimeListYearLps_Repository>();
            services.AddScoped<PD_TimeListYearComLps_Repository>();
            services.AddScoped<PD_TimeList30DayLps_Repository>();
            services.AddScoped<PD_TimeList30DayComLps_Repository>();
            services.AddScoped<PD_TimeDeptList_Repository>();
            services.AddScoped<PD_TimeDeptListOfCom_Repository>();
            services.AddScoped<PD_TimeOverAllComTodayLps_Repository>();
            services.AddScoped<PD_TimeOverAllTodayLps_Repository>();
            services.AddScoped<PD_ManTodaySite_ValuesRepository>();
            services.AddScoped<PD_ManGenderSite_ValuesRepository>();
            services.AddScoped<PD_ManListMonthSite_ValuesRepository>();
            services.AddScoped<PD_ManListCusSite_ValuesRepository>();
            services.AddScoped<PD_ManListSite_ValuesRepository>();
            services.AddScoped<PD_ManListDeptLps_ValuesRepository>();
            services.AddScoped<PD_ManListMonthLps_ValuesRepository>();
            services.AddScoped<PD_ManGenderLps_ValuesRepository>();
            services.AddScoped<PD_ManTodayLps_ValuesRepository>();
            services.AddScoped<PD_TimeSiteList_ValuesRepository>();
            services.AddScoped<PD_TimeLeavePers_ValuesRepository>();
            services.AddScoped<PD_TimeLeaveSick_ValuesRepository>();
            services.AddScoped<PD_TimeLeaveVacation_ValuesRepository>();
            services.AddScoped<PD_TimeLeaveOther_ValuesRepository>();

            services.AddScoped<PD_TimeAutoBmw_ValuesRepository>();
            services.AddScoped<PD_TimeLost_ValuesRepository>();
            services.AddScoped<PD_TimeLate_ValuesRepository>();
            services.AddScoped<PD_TimeAllListMonthBmw_ValuesRepository>();
            services.AddScoped<PD_TimeAll30DayBmw_ValuesRepository>();
            services.AddScoped<PD_TimeDeptListDayBmw_ValuesRepository>();
            services.AddScoped<PD_TimeAllPercentBmw_ValuesRepository>();
            services.AddScoped<PD_siteDept_ValuesRepository>();
            services.AddScoped<PD_ListMonthinfoDetail_ValuesRepository>();
            services.AddScoped<PD_GenderDetail_ValuesRepository>();
            services.AddScoped<PD_ListDept_ValuesRepository>();
            services.AddScoped<PD_Gender_ValuesRepository>();
            services.AddScoped<PD_TargetDetail_ValuesRepository>();
            services.AddScoped<PD_BarList_ValuesRepository>();
            services.AddScoped<PD_BarTodday_ValuesRepository>();
            services.AddScoped<PD_EmpList_ValuesRepository>();
            services.AddScoped<PD_AttByDept_ValuesRepository>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Intro}/{action=Login}/{id?}");
            });
        }
    }
}
