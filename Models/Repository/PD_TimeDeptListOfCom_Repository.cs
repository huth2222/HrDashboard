using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeDeptListOfCom_Repository
    {
        private readonly string _connectionString;
        public PD_TimeDeptListOfCom_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_TimeDeptListOfComToday_db>> GetById(string getDate, string getCom)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeDeptListCom_LPS", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getCompany", getCom));
                    var response = new List<HD_PD_TimeDeptListOfComToday_db>();
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
        private HD_PD_TimeDeptListOfComToday_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeDeptListOfComToday_db()
            {
                DeptName = (string)reader["DeptName"],
                info = (int)reader["info"],
                timeIn = (int)reader["timeIn"],
                timeLate = (int)reader["timeLate"],
                losts = (int)reader["losts"],
                leaves = (int)reader["leaves"]
            };
        }
    }
}