using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ManTodaySite_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_ManTodaySite_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_ManpowerToday_LPS_db> GetById(string getDate,string getCompany,string getZone)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManpowerToday_Site", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@Company", getCompany));
                    cmd.Parameters.Add(new SqlParameter("@GetZone", getZone));
                    HD_PD_ManpowerToday_LPS_db response = null;
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
        private HD_PD_ManpowerToday_LPS_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManpowerToday_LPS_db()
            {
                target = (int)reader["target"],
                employee = (int)reader["employee"],
                vacency = (int)reader["vacency"]
            };
        }
    }
}