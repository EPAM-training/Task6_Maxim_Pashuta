using EPAM_Task6.CRUD;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace EPAM_Task6_Test.CRUDTest
{
    /// <summary>
    /// Class for testing class Crud.
    /// </summary>
    public class CrudTest
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
        /// The method tests the method Insert when object id is not exists.
        /// </summary>
        [Test]
        public void Insert_WhenObjectIdIsNotExists_AddObject()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 7,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 06, 06),
                GroupID = 1
            };

            crud.Insert(student);

            Student result = crud.Read(student.ID);
            crud.Delete(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Insert.
        /// </summary>
        [TestCase(1, 1, TestName = "Insert_WhenObjectIdExists_ThrowSqlException")]
        [TestCase(8, 3, TestName = "Insert_WhenObjectIdForeignKeyNotExist_ThrowSqlException")]
        public void Test_Insert(int id, int foreignKey)
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = id,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = foreignKey
            };

            Assert.That(() => crud.Insert(student), Throws.Exception);
        }

        /// <summary>
        /// The method tests the method Update.
        /// </summary>
        [Test]
        public void Test_Update()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 3,
                FullName = "Dfsdf dfdfa Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            crud.Update(student.ID, student);

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Delete when object exists.
        /// </summary>
        [Test]
        public void Delete_WhenObjectExists_DeleteObject()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 7,
                FullName = "Avseeva Eva Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2001, 4, 18),
                GroupID = 1
            };

            crud.Insert(student);

            crud.Delete(student.ID);

            Student result = crud.Read(student.ID);

            Assert.IsNull(result);
        }

        /// <summary>
        /// The method tests the method Read when object exists.
        /// </summary>
        [Test]
        public void Read_WhenObjectExists_GetObject()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 1,
                FullName = "Famov Maxim Gennadievich",
                Gender = "Male",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Read when object does not exists.
        /// </summary>
        /// <param name="id">Id</param>
        [TestCase(-1)]
        [TestCase(15)]
        public void Read_WhenObjectNotExists_GetNull(int id)
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);

            Student result = crud.Read(id);

            Assert.IsNull(result);
        }
    }
}
