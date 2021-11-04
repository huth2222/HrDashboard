using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeLeaveOther_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeLeaveOther_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeOtherLeave_db>> GetById(string getDate,int getShit)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeOtherLeave", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getShit));
                    var response = new List<HD_PD_TimeOtherLeave_db>();
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
        private HD_PD_TimeOtherLeave_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeOtherLeave_db()
            {
                dept_name = (string)reader["dept_name"],
                emp_id = (string)reader["emp_id"],
                fullname = (string)reader["fullname"],
                leave_name_th = (string)reader["leave_name_th"],
                leave_name_en = (string)reader["leave_name_en"]
            };
        }
    }
}