using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeOverAllComTodayLps_Repository
    {
        private readonly string _connectionString;
        public PD_TimeOverAllComTodayLps_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_TimeOverAllComToday_LPS_db> GetById(string getDate, string getCom)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeOverAllComToday_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getCompany", getCom));
                    HD_PD_TimeOverAllComToday_LPS_db response = null;
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
        private HD_PD_TimeOverAllComToday_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeOverAllComToday_LPS_db()
            {
                info = (int)reader["info"],
                timeIn = (int)reader["timeIn"],
                timeLate = (int)reader["timeLate"],
                leaves = (int)reader["leaves"],
                losts = (int)reader["losts"]
            };
        }
    }
}