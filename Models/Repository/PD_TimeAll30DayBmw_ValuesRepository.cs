using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeAll30DayBmw_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeAll30DayBmw_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeAll30DayBmw_db>> GetById(string getDate,int getshift)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeAll30Day_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getshift));
                    var response = new List<HD_PD_TimeAll30DayBmw_db>();
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
        private HD_PD_TimeAll30DayBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeAll30DayBmw_db()
            {
                getdate = (string)reader["getdate"],
                info = (int)reader["info"],
                sTime = (int)reader["sTime"],
                lost = (int)reader["lost"],
                leave = (int)reader["leave"],
                time_late = (int)reader["time_late"]
            };
        }
    }
}