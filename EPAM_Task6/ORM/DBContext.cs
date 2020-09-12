using System.Data.SqlClient;

namespace EPAM_Task6.ORM
{
    /// <summary>
    /// Class for setting connection to database.
    /// </summary>
    public abstract class CustomDbContext
    {
        private string _connectionString;
        protected SqlConnection _sqlConnection;

        /// <summary>
        /// Constructor initializes SqlConnection.
        /// </summary>
        public CustomDbContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Task6_DB;Integrated Security=True";
            _sqlConnection = new SqlConnection(_connectionString);
        }
    }
}
