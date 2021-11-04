using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_Dept_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_Dept_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<PD_Dept_db>> GetById(string getdate)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PD_Dept", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getdate));
                    var response = new List<PD_Dept_db>();
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
        private PD_Dept_db MapToValue(SqlDataReader reader)
        {
            return new PD_Dept_db()
            {
                dept = (string)reader["dept"],
                all_emp = (int)reader["all_emp"],
                checkin = (int)reader["checkin"],
                lost = (int)reader["lost"]
            };
        }
    }
}