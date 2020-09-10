using EPAM_Task6.DatabaseWork;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task6_Test.DatabaseWorkTest
{
    /// <summary>
    /// Class for testing class WorkWithStudentTable.
    /// </summary>
    public class WorkWithStudentTableTest
    {
        private CustomORM _orm;
        private Group _group;

        /// <summary>
        /// The method initializes objects for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _orm = CustomORM.Instance;
            _group = _orm.Groups.First();

            DatabaseRelations.LoadRelationGroupStudent(_group, _orm.Students);

            foreach (Student student in _group.Students)
            {
                DatabaseRelations.LoadRelationStudentExamResult(student, _orm.ExamResults);
                DatabaseRelations.LoadRelationStudentGroup(student, _orm.Groups);
            }
        }

        /// <summary>
        /// The method tests the method GetBadStudentList.
        /// </summary>
        [Test]
        public void Test_GetLoserStudentList()
        {
            List<Student> result = WorkWithStudentTable.GetBadStudentList(_group.Students);

            CollectionAssert.IsNotEmpty(result);
        }
    }
}
