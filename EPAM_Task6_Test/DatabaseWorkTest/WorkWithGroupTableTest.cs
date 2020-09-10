using EPAM_Task6.DatabaseWork;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System.Linq;

namespace EPAM_Task6_Test.DatabaseWorkTest
{
    /// <summary>
    /// Class for testing class WorkWithGroupTable.
    /// </summary>
    public class WorkWithGroupTableTest
    {
        private CustomORM _orm;

        /// <summary>
        /// The method initializes objects for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _orm = CustomORM.Instance;

            foreach (Session session in _orm.Sessions)
            {
                DatabaseRelations.LoadRelationSessionGroup(session, _orm.Groups);
                DatabaseRelations.LoadRelationGroupStudent(session.Group, _orm.Students);

                foreach (Student student in session.Group.Students)
                {
                    DatabaseRelations.LoadRelationStudentExamResult(student, _orm.ExamResults);

                    foreach (ExamResult examResult in student.ExamResults)
                    {
                        DatabaseRelations.LoadRelationExamResultExam(examResult, _orm.Exams);
                    }
                }
            }
        }

        /// <summary>
        /// The method tests the method GetAverageMarkByGroup.
        /// </summary>
        [Test]
        public void Test_GetAverageMarkForGroup()
        {
            Session session = _orm.Sessions.First();

            double result = WorkWithGroupTable.GetAverageMarkByGroup(session.ID, session.Group);
            double actualResult = 5;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method GetMaxMarkByGroup.
        /// </summary>
        [Test]
        public void Test_GetMaxMarkforGroup()
        {
            Session session = _orm.Sessions.First();

            double result = WorkWithGroupTable.GetMaxMarkByGroup(session.ID, session.Group);
            double actualResult = 8;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method GetMinMarkByGroup.
        /// </summary>
        [Test]
        public void Test_GetMinMarkforGroup()
        {
            Session session = _orm.Sessions.First();

            double result = WorkWithGroupTable.GetMinMarkByGroup(session.ID, session.Group);
            double actualResult = 2;

            Assert.AreEqual(result, actualResult);
        }
    }
}
