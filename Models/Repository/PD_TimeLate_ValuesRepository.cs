using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeLate_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeLate_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeLateDayBmw_db>> GetById(string getDate,int getShit)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeLate_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getShit));
                    var response = new List<HD_PD_TimeLateDayBmw_db>();
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
        private HD_PD_TimeLateDayBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeLateDayBmw_db()
            {
                dept_name = (string)reader["dept_name"],
                emp_id = (string)reader["emp_id"],
                fullname = (string)reader["fullname"],
                time_late = (string)reader["time_late"]
            };
        }
    }
}