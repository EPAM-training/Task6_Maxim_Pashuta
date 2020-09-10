using EPAM_Task6.DatabaseWork;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EPAM_Task6_Test.DatabaseWorkTest
{
    /// <summary>
    /// Class for testing class TableReader.
    /// </summary>
    public class TableReaderTest
    {
        private SqlConnection _sqlConnection;

        /// <summary>
        /// The method initializes objects for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            string connectionString = @"Data Source=USER-PC\ACCELERATOR;Initial Catalog=Session_DB;Integrated Security=True";
            _sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// The method tests the method ReadTable.
        /// </summary>
        [Test]
        public void Test_ReadTable()
        {
            IEnumerable<Student> result = TableReader<Student>.ReadTable(_sqlConnection);
            Assert.IsNotNull(result);
        }
    }
}
