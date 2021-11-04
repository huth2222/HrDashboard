using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeAllPercentBmw_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeAllPercentBmw_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeAllPercentBmw_db>> GetById(string getDate, int getShit)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeAllPercent_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getShit));
                    var response = new List<HD_PD_TimeAllPercentBmw_db>();
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

        private HD_PD_TimeAllPercentBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeAllPercentBmw_db()
            {
                shifts = (string)reader["shifts"],
                infos = (int)reader["infos"],
                timeins = (int)reader["timeins"],
                leaves = (int)reader["leaves"],
                losts = (int)reader["losts"],
                time_lates = (int)reader["time_lates"]                
            };
        }
    }
}