using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ManGenderLps_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_ManGenderLps_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_ManpowerGender_LPS_db> GetById(string getDate,string getCompany)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerGender_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@Company", getCompany));
                    HD_PD_ManpowerGender_LPS_db response = null;
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
        private HD_PD_ManpowerGender_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerGender_LPS_db()
            {
                getdate = (string)reader["getdate"],
                sex_man = (int)reader["sex_man"],
                sex_wo = (int)reader["sex_wo"]
            };
        }
    }
}