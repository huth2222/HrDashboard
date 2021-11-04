using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeAllListMonthBmw_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeAllListMonthBmw_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeAllListMonthBmw_db>> GetById(string getDate,int getshift)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeAllListMonth_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getshift));
                    var response = new List<HD_PD_TimeAllListMonthBmw_db>();
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
        private HD_PD_TimeAllListMonthBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeAllListMonthBmw_db()
            {
                getmonth = (string)reader["getmonth"],
                info = (int)reader["info"],
                sTime = (int)reader["sTime"],
                time_late = (int)reader["time_late"],
                leave = (int)reader["leave"],
                absence = (int)reader["absence"],
                lost = (int)reader["lost"]               
            };
        }
    }
}