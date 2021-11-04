using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_BarList_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_BarList_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_ManpowerMonthList_db>> GetById(string getDate,string getsite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerMonthList", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getsite));
                    var response = new List<HD_PD_ManpowerMonthList_db>();
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
        private HD_PD_ManpowerMonthList_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerMonthList_db()
            {
                months = (string)reader["months"],
                target = (int)reader["target"],
                info = (int)reader["info"],
                lost = (int)reader["lost"]
            };
        }
    }
}