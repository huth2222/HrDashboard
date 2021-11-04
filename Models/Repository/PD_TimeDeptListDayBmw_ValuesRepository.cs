using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeDeptListDayBmw_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeDeptListDayBmw_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeDeptListDayBmw_db>> GetById(string getDate,int getShift)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeDeptListDay_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getShift));
                    var response = new List<HD_PD_TimeDeptListDayBmw_db>();
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
        private HD_PD_TimeDeptListDayBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeDeptListDayBmw_db()
            {
                dept_name = (string)reader["dept_name"],
                info = (int)reader["info"],
                timein = (int)reader["timein"],
                time_late = (int)reader["time_late"],
                lost = (int)reader["lost"],
                leave = (int)reader["leave"]
            };
        }
    }
}