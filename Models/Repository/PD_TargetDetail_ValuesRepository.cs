using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TargetDetail_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TargetDetail_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TargetDetail_db>> GetById(string getDate,string getsite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TargetDetail", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getsite));
                    var response = new List<HD_PD_TargetDetail_db>();
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
        private HD_PD_TargetDetail_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TargetDetail_db()
            {
                company_Code = (string)reader["company_Code"],
                sex_man = (int)reader["sex_man"],
                sex_wo = (int)reader["sex_wo"],
                quantity = (int)reader["quantity"]
            };
        }
    }
}