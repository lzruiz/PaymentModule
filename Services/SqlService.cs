using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;


namespace PaymentModule.Services
{
    public class SqlService : ISqlService
    {
        private readonly IConfiguration _configuration;

        public SqlService(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public DataTable Query(string sql)
        {
            try
            {
                var sqlString = _configuration.GetConnectionString("connString");
                using (SqlConnection connection = new SqlConnection(sqlString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using(SqlDataAdapter adapter= new SqlDataAdapter(command))
                        {
                            DataTable dTable = new DataTable();
                            adapter.Fill(dTable);
                            connection.Close();
                            return dTable;
                        }
                    }
                }   
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    public interface ISqlService
    {
        DataTable Query(string sql);
    }
}
