using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_Gender_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_Gender_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_ManpowerGender_db> GetById(string getdate,string getsite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerGender", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getdate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getsite));
                    HD_PD_ManpowerGender_db response = null;
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
        private HD_PD_ManpowerGender_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerGender_db()
            {
                sex_man = (int)reader["sex_man"],
                sex_wo = (int)reader["sex_wo"],
                quantity = (int)reader["quantity"]
            };
        }
    }
}