using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ManListDeptLps_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_ManListDeptLps_ValuesRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_ManpowerListDept_LPS_db>> GetById(string getDate, string getCompany)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerListDept_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@Company", getCompany));
                    var response = new List<HD_PD_ManpowerListDept_LPS_db>();
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
        private HD_PD_ManpowerListDept_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerListDept_LPS_db()
            {
                DeptName = (string)reader["DeptName"],
                target = (int)reader["target"],
                employee = (int)reader["employee"],
                empNew = (int)reader["empNew"],
                vacency = (int)reader["vacency"]
            };
        }
    }
}