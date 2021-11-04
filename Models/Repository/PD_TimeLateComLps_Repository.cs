using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeLateComLps_Repository
    {
        private readonly string _connectionString;
        public PD_TimeLateComLps_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeLateCom_LPS_db>> GetById(string getDate, string getCompany)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeLateCom_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getCompany", getCompany));
                    var response = new List<HD_PD_TimeLateCom_LPS_db>();
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
        private HD_PD_TimeLateCom_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeLateCom_LPS_db()
            {
                PersonCode = (string)reader["PersonCode"],
                Dept = (string)reader["Dept"],
                CompanyCode = (string)reader["CompanyCode"],
                Fullname = (string)reader["Fullname"],
                LateCount = (int)reader["LateCount"],
                ScanTime = (string)reader["ScanTime"]
            };
        }
    }
}