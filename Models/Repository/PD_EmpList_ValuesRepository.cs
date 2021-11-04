using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_EmpList_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_EmpList_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<HD_PD_AttEmpList>> GetById(string getDate)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_AttEmpList", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    var response = new List<HD_PD_AttEmpList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private HD_PD_AttEmpList MapToValue(SqlDataReader reader)
        {
            return new HD_PD_AttEmpList()
            {
                WorkDate = (string)reader["WorkDate"],
                FullAttStatus = (string)reader["FullAttStatus"],
                LeaveFull = (string)reader["LeaveFull"],
                YearLost = (int)reader["YearLost"],
                YearLate = (int)reader["YearLate"],
                YearLeave = (int)reader["YearLeave"],
                YearPLeave = (int)reader["YearPLeave"],
                YearSLeave = (int)reader["YearSLeave"],
                YearALeave = (int)reader["YearALeave"],
                YearOLeave = (int)reader["YearOLeave"],
                MonthLost = (int)reader["MonthLost"],
                MonthLate = (int)reader["MonthLate"],
                MonthLeave = (int)reader["MonthLeave"],
                MonthPLeave = (int)reader["MonthPLeave"],
                MonthSLeave = (int)reader["MonthSLeave"],
                MonthALeave = (int)reader["MonthALeave"],
                MonthOLeave = (int)reader["MonthOLeave"],
                Late = (string)reader["Late"],
                PersonCode = (string)reader["PersonCode"],
                PersonCardID = (string)reader["PersonCardID"],
                Fullname = (string)reader["Fullname"],
                DeptGroup = (string)reader["DeptGroup"]
            };
        }
    }
}