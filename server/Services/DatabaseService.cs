using MySql.Data.MySqlClient;

namespace server.Services
{
    public class DatabaseService
    {
        public string ConnectionString { get; set; }

        public DatabaseService(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}