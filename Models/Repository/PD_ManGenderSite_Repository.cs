using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ManGenderSite_Repository
    {
        private readonly string _connectionString;
        public PD_ManGenderSite_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_ManGender_Site_db> GetById(string getSite, string getDate, string parts, int shift_id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManGender_Site", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getSite", getSite));
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@parts", parts));
                    cmd.Parameters.Add(new SqlParameter("@shift_id", shift_id));
                    HD_PD_ManGender_Site_db response = null;
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
        private HD_PD_ManGender_Site_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManGender_Site_db()
            {
                shift_id = (int)reader["shift_id"],
                males = (int)reader["males"],
                females = (int)reader["females"],
                parts = (string)reader["parts"],
                infos = (int)reader["infos"]
            };
        }
    }
}