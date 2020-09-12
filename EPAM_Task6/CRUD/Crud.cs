using EPAM_Task6.Creators;
using EPAM_Task6.CRUD.Interfaces;
using EPAM_Task6.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EPAM_Task6.CRUD
{
    /// <summary>
    /// Class for working database.
    /// </summary>
    /// <typeparam name="T">Class that inherits the class BaseModel</typeparam>
    public class Crud<T> : ICrud<T> where T : BaseModel
    {
        private SqlConnection _sqlConnection;

        private List<PropertyInfo> _properties;

        /// <summary>
        /// Constructor initializes SqlConnection and sets class properties.
        /// </summary>
        /// <param name="sqlConnection"></param>
        public Crud(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;

            _properties = typeof(T).GetProperties().ToList();
        }

        /// <summary>
        /// The method inserts an object into a database table.
        /// </summary>
        /// <param name="obj">Object that inherits the class BaseModel</param>
        public void Insert(T obj)
        {
            string sqlInsertCommand = $"INSERT INTO [{typeof(T).Name}] (";

            // Gets properties that are table columns
            List<PropertyInfo> propertyColumns = _properties.Where(property => !property.PropertyType.IsClass || property.PropertyType == typeof(string)).ToList();

            // Forms sql command
            sqlInsertCommand += string.Join(",", propertyColumns.Select(property => $"[{property.Name}]"));

            sqlInsertCommand += ")";
            sqlInsertCommand += "VALUES (";
            sqlInsertCommand += string.Join(",", propertyColumns.Select(property => $"@{property.Name}"));

            sqlInsertCommand += ");";

            var sqlCommand = new SqlCommand(sqlInsertCommand, _sqlConnection);

            //Adds SqlParameters
            foreach (PropertyInfo property in propertyColumns)
            {
                sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{property.GetValue(obj)}");
            }

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        /// <summary>
        /// The method updates an object that locates into a database table.
        /// </summary>
        /// <param name="id">Object id</param>
        /// <param name="obj">Object that inherits the class BaseModel</param>
        public void Update(int id, T obj)
        {
            string sqlUpdateCommand = $"UPDATE [{typeof(T).Name}] SET ";

            // Gets properties that are table columns
            List<PropertyInfo> propertyColumns = _properties.Where(property => (!property.PropertyType.IsClass || (property.PropertyType == typeof(string))) &&
                                                                               (property.Name != nameof(BaseModel.ID))).ToList();

            // Forms sql command
            sqlUpdateCommand += string.Join(",", propertyColumns.Where(prop => (prop.Name != nameof(BaseModel.ID)))
                                                                .Select(property => string.Format($"[{property.Name}] = @{property.Name} ")));

            sqlUpdateCommand += $"WHERE [ID] = @{nameof(id)};";

            SqlCommand sqlCommand = new SqlCommand(sqlUpdateCommand, _sqlConnection);

            //Adds SqlParameters
            foreach (PropertyInfo property in propertyColumns)
            {
                sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{property.GetValue(obj)}");
            }

            sqlCommand.Parameters.AddWithValue($"@{nameof(id)}", $"{id}");

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        /// <summary>
        /// The method deletes an object from a database table.
        /// </summary>
        /// <param name="id">ID</param>
        public void Delete(int id)
        {
            string sqlDeleteCommand = $"DELETE FROM [{typeof(T).Name}] WHERE ID = @ID;";

            SqlCommand sqlCommand = new SqlCommand(sqlDeleteCommand, _sqlConnection);

            //Adds SqlParameter
            sqlCommand.Parameters.AddWithValue("@ID", $"{id}");

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        /// <summary>
        /// The method searches an object from a database table by id.
        /// </summary>
        /// <param name="id">Object id</param>
        /// <returns></returns>
        public T Read(int id)
        {
            _sqlConnection.Open();
            object obj = null;

            string sqlSelectCommand = $"SELECT * FROM [{typeof(T).Name}] WHERE Id = @ID;";
            SqlCommand sqlCommand = new SqlCommand(sqlSelectCommand, _sqlConnection);

            //Adds SqlParameter
            sqlCommand.Parameters.AddWithValue("@ID", $"{id}");

            SqlDataReader reader = sqlCommand.ExecuteReader();

            int count = reader.FieldCount;

            if (reader.HasRows)
            {
                reader.Read();
                obj = ModelFactory.CreateModel<T>();

                for (int i = 0; i < count; i++)
                {
                    var fieldName = reader.GetName(i);
                    var propInfo = typeof(T).GetProperty(fieldName);
                    propInfo?.SetValue(obj, reader.GetValue(i));
                }
            }

            _sqlConnection.Close();

            return (T)obj;
        }
    }
}
