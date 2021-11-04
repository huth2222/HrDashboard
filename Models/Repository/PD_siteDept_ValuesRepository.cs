using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_siteDept_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_siteDept_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_ListDeptSite_db>> GetById(string getDate,string getSite)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ListDeptSite", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getsite", getSite));
                    var response = new List<HD_PD_ListDeptSite_db>();
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
        private HD_PD_ListDeptSite_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ListDeptSite_db()
            {
                months = (string)reader["months"],
                dept_name = (string)reader["dept_name"],
                target = (int)reader["target"],
                info = (int)reader["info"],
                adds = (int)reader["adds"],
                lost = (int)reader["lost"]
            };
        }
    }
}