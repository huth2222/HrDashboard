using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ListDept_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_ListDept_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_ListDept_db>> GetById(string getdate,string getsite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ListDept", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getdate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getsite));
                    var response = new List<HD_PD_ListDept_db>();
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
        private HD_PD_ListDept_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ListDept_db()
            {

                Company_Code = (string)reader["Company_Code"],
                info = (int)reader["info"],
                adds = (int)reader["adds"],
                lost = (int)reader["lost"]
            };
        }
    }
}