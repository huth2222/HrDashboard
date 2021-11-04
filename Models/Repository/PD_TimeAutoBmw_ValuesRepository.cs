using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_TimeAutoBmw_ValuesRepository
    {
        private readonly string _connectionString;
        public PD_TimeAutoBmw_ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<HD_PD_TimeAutoValueBmw_db> GetById(string getDate,int getShift)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_TimeAutoValue_BMW", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getdate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@getshift", getShift));
                    //HD_PD_TimeAutoValueBmw_db response = null;
                    HD_PD_TimeAutoValueBmw_db response = null;
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
        private HD_PD_TimeAutoValueBmw_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_TimeAutoValueBmw_db()
            {
                ids = (int)reader["ids"],
                timeins = (int)reader["timeins"],
                losts = (int)reader["losts"],
                leaves = (int)reader["leaves"],
                time_lates = (int)reader["time_lates"]
            };
        }
    }
}