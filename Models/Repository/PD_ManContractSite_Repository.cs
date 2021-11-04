using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HrDashboard.Models.Repository
{
    public class PD_ManContractSite_Repository
    {
        private readonly string _connectionString;
        public PD_ManContractSite_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<HD_PD_ManContract_Site_db>> GetById(string getSite, string getDate, string parts, string shift_id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HD_PD_ManContract_Site", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@getSite", getSite));
                    cmd.Parameters.Add(new SqlParameter("@getDate", getDate));
                    cmd.Parameters.Add(new SqlParameter("@parts", parts));
                    cmd.Parameters.Add(new SqlParameter("@shift_id", shift_id));
                    var response = new List<HD_PD_ManContract_Site_db>();
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
        private HD_PD_ManContract_Site_db MapToValue(SqlDataReader reader)
        {
            return new HD_PD_ManContract_Site_db()
            {
                GetMonth = (string)reader["GetMonth"],
                Core = (int)reader["Core"],
                Limited = (int)reader["Limited"],
                ZAK = (int)reader["ZAK"],
                Infos = (int)reader["Infos"]
            };
        }
    }
}