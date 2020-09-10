using EPAM_Task6.Creators;
using EPAM_Task6.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace EPAM_Task6.DatabaseWork
{
    /// <summary>
    /// Class for reading a database tables.
    /// </summary>
    /// <typeparam name="T">Class that inherits the class BaseModel</typeparam>
    public static class TableReader<T> where T : BaseModel
    {
        /// <summary>
        /// The method reads a table from a database.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public static IEnumerable<T> ReadTable(SqlConnection sqlConnection)
        {
            sqlConnection.Open();

            var sqlSelectCommand = $"SELECT * FROM [{typeof(T).Name}]";
            var sqlCommand = new SqlCommand(sqlSelectCommand, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var list = new List<T>();
            var obj = ModelFactory.CreateModel<T>();

            int columnsNumber = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (var i = 0; i < columnsNumber; i++)
                    {
                        string fieldName = reader.GetName(i);
                        PropertyInfo propInfo = obj.GetType().GetProperty(fieldName);

                        if (!(reader.GetValue(i) is DBNull))
                        {
                            propInfo?.SetValue(obj, reader.GetValue(i));
                        }
                    }

                    list.Add((T)obj);
                    obj = ModelFactory.CreateModel(typeof(T).FullName);
                }
            }

            sqlConnection.Close();

            return list;
        }
    }
}
