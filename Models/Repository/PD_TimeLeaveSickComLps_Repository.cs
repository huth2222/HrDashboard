using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeLeaveSickComLps_Repository
    {
        private readonly string _connectionString;
        public PD_TimeLeaveSickComLps_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeSickLeaveComLps_db>> GetById(string getDate, string getCompany)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeSickLeaveComLps", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getCompany", getCompany));
                    var response = new List<HD_PD_TimeSickLeaveComLps_db>();
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
        private HD_PD_TimeSickLeaveComLps_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeSickLeaveComLps_db()
            {
                Dept = (string)reader["Dept"],
                PersonCode = (string)reader["PersonCode"],
                Fullname = (string)reader["Fullname"],
                LeaveGroupName = (string)reader["LeaveGroupName"]
            };
        }
    }
}