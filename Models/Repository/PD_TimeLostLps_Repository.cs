using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeLostLps_Repository
    {
        private readonly string _connectionString;
        public PD_TimeLostLps_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeLost_LPS_db>> GetById(string getDate)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeLost_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    var response = new List<HD_PD_TimeLost_LPS_db>();
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
        private HD_PD_TimeLost_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeLost_LPS_db()
            {
                Dept = (string)reader["Dept"],
                PersonCode = (string)reader["PersonCode"],
                Fullname = (string)reader["Fullname"]
            };
        }
    }
}