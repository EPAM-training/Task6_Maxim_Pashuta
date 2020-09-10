using EPAM_Task6.DatabaseWork;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System.Linq;

namespace EPAM_Task6_Test.DatabaseWorkTest
{
    /// <summary>
    /// Class for testing class DatabaseRelations.
    /// </summary>
    public class DatabaseRelationsTest
    {
        /// <summary>
        /// The method tests the method LoadRelationSessionGroup.
        /// </summary>
        [Test]
        public void Test_LoadRelationSessionGroup()
        {
            CustomORM orm = CustomORM.Instance;
            Session session = orm.Sessions.First();

            DatabaseRelations.LoadRelationSessionGroup(session, orm.Groups);

            Assert.IsNotNull(session.Group);
        }

        /// <summary>
        /// The method tests the method LoadRelationGroupStudent.
        /// </summary>
        [Test]
        public void Test_LoadRelationGroupStudent()
        {
            CustomORM orm = CustomORM.Instance;
            Group group = orm.Groups.First();

            DatabaseRelations.LoadRelationGroupStudent(group, orm.Students);

            Assert.IsNotNull(group.Students);
        }

        /// <summary>
        /// The method tests the method LoadRelationStudentExamResult.
        /// </summary>
        [Test]
        public void Test_LoadRelationStudentExamResult()
        {
            CustomORM orm = CustomORM.Instance;
            Student student = orm.Students.First();

            DatabaseRelations.LoadRelationStudentExamResult(student, orm.ExamResults);

            Assert.IsNotNull(student.ExamResults);
        }

        /// <summary>
        /// The method tests the method LoadRelationStudentGroup.
        /// </summary>
        [Test]
        public void Test_LoadRelationStudentGroup()
        {
            CustomORM orm = CustomORM.Instance;
            Student student = orm.Students.First();

            DatabaseRelations.LoadRelationStudentGroup(student, orm.Groups);

            Assert.IsNotNull(student.Group);
        }

        /// <summary>
        /// The method tests the method LoadRelationExamResultExam.
        /// </summary>
        [Test]
        public void Test_LoadRelationExamResultExam()
        {
            CustomORM orm = CustomORM.Instance;
            ExamResult examResult = orm.ExamResults.First();

            DatabaseRelations.LoadRelationExamResultExam(examResult, orm.Exams);

            Assert.IsNotNull(examResult.Exam);
        }
    }
}
