using System.Data.SqlClient;
using System.Configuration;


namespace buy_ticket.util
{
    internal class DBConfiguration
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["dbticket"].ConnectionString;

        private static SqlConnection instance;
        public SqlConnection GetConnection()
        {
            return instance == null ? new SqlConnection(connectionString) : instance;
        }
    }
}
