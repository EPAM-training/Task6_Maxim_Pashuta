using EPAM_Task6.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EPAM_Task6.CRUD;
using EPAM_Task6.CustomExceptions;
using EPAM_Task6.Creators;
using System.Reflection;
using System;

namespace EPAM_Task6.ORM
{
    /// <summary>
    /// Class for storing a table as a collection of objectsю
    /// </summary>
    /// <typeparam name="T">Class that inherits the class BaseModel</typeparam>
    public class CustomDbSet<T> : IEnumerable<T> where T : BaseModel
    {
        private Crud<T> _crud;
        private List<T> _listModel;
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Constructor set up SqlConnection and reads the table into the collection of objects
        /// </summary>
        /// <param name="sqlConnection"></param>
        public CustomDbSet(SqlConnection sqlConnection)
        {   
            if (sqlConnection == null)
            {
                throw new SqlConnectionNullException($"{nameof(SqlConnection)} can't be null.");
            }

            _sqlConnection = sqlConnection;
            _crud = new Crud<T>(_sqlConnection);
            _listModel = ReadTable().ToList();
        }

        /// <summary>
        /// The method adds an object to the objects collection and to the table.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            _crud.Insert(item);
            _listModel.Add(item);
        }

        /// <summary>
        /// The method deletes an object from the objects collection and from the table.
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int id)
        {
            _crud.Delete(id);

            var deletedModel = _listModel.FirstOrDefault(obj => obj.ID == id);
            _listModel.Remove(deletedModel);
        }

        /// <summary>
        /// The method update an object in the objects collection and in the table.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Update(int id, T item)
        {
            _crud.Update(id, item);

            var updatedModel = _listModel.FirstOrDefault(obj => obj.ID == id);
            updatedModel = item;
        }

        /// <summary>
        /// The method reads an object from the objects collection.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Read(int id) =>_listModel.FirstOrDefault(obj => obj.ID == id);

        public IEnumerator<T> GetEnumerator() => _listModel.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// The method reads a table from a database.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadTable()
        {
            _sqlConnection.Open();

            var sqlSelectCommand = $"SELECT * FROM [{typeof(T).Name}]";
            var sqlCommand = new SqlCommand(sqlSelectCommand, _sqlConnection);
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

            _sqlConnection.Close();

            return list;
        }
    }
}
