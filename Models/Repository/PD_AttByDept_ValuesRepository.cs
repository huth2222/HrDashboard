using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_AttByDept_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_AttByDept_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<HD_PD_AttDept>> GetById(string getDate)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_AttDept", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    var response = new List<HD_PD_AttDept>();
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
        private HD_PD_AttDept MapToValue(SqlDataReader reader)
        {
            return new HD_PD_AttDept()
            {
                DeptGroup = (string)reader["DeptGroup"],     
                AttHoliday = (int)reader["AttHoliday"],
                AttIn = (int)reader["AttIn"],
                AttLost = (int)reader["AttLost"],
                AttLate = (int)reader["AttLate"],
                AttLeave = (int)reader["AttLeave"]
            };
        }
    }
}