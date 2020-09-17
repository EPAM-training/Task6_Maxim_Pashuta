using EPAM_Task6.CustomExceptions;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace EPAM_Task6_Test.ORM
{
    public class CustomDbSetTest
    {
        private CustomDbSet<Student> _students;

        [SetUp]
        public void Setup()
        {
            string connectionString = @"Data Source=USER-PC\ACCELERATOR;Initial Catalog=Task6_DB;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            _students = new CustomDbSet<Student>(sqlConnection);
        }

        [Test]
        public void Constructor_WhenSqlConncetionIsNull_ThrowsSqlConnectionNullException()
        {
            SqlConnection sqlConnection = null;

            Assert.That(() => new CustomDbSet<Student>(sqlConnection), Throws.TypeOf<SqlConnectionNullException>());
        }

        [Test]
        public void Test_Add()
        {
            var student = new Student()
            {
                ID = 7,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 06, 06),
                GroupID = 1
            };

            _students.Add(student);

            Student result = _students.Read(student.ID);
            _students.Delete(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Insert.
        /// </summary>
        [TestCase(1, 1, TestName = "Add_WhenObjectIdExists_ThrowSqlException")]
        [TestCase(8, 3, TestName = "Add_WhenObjectIdForeignKeyNotExist_ThrowSqlException")]
        public void Test_Add(int id, int foreignKey)
        {
            var student = new Student()
            {
                ID = id,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = foreignKey
            };

            Assert.That(() => _students.Add(student), Throws.Exception);
        }

        [Test]
        public void Test_Delete()
        {
            var student = new Student()
            {
                ID = 7,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 06, 06),
                GroupID = 1
            };

            _students.Add(student);

            _students.Delete(student.ID);

            Student result = _students.Read(student.ID);

            Assert.IsNull(result);
        }

        [Test]
        public void Test_Update()
        {
            var student = new Student()
            {
                ID = 3,
                FullName = "Dfsdf dfdfa Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            _students.Update(student.ID, student);

            Student result = _students.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        [Test]
        public void Read_WhenObjectExists_GetObject()
        {
            var student = new Student()
            {
                ID = 1,
                FullName = "Famov Maxim Gennadievich",
                Gender = "Male",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            Student result = _students.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        [TestCase(-1)]
        [TestCase(15)]
        public void Read_WhenObjectNotExists_GetNull(int id)
        {
            Student result = _students.Read(id);

            Assert.IsNull(result);
        }
    }
}
