using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_BarTodday_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_BarTodday_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_ManpowerToday_db> GetById(string getdate,string getsite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerToday", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getdate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getsite));
                    HD_PD_ManpowerToday_db response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = (MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private HD_PD_ManpowerToday_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerToday_db()
            {
                months = (string)reader["months"],
                target = (int)reader["target"],
                info = (int)reader["info"],
                lost = (int)reader["lost"]
            };
        }
    }
}