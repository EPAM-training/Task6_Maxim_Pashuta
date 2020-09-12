using EPAM_Task6.ORM;
using EPAM_Task6.Reports;
using EPAM_Task6.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task6_Test.ReportTest
{
    public class ReportDataTest
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
        }

        /// <summary>
        /// The method tests the method GetBadStudentList.
        /// </summary>
        [Test]
        public void Test_GetBadStudentList()
        {
            List<Student> result = ReportData.GetBadStudentList(_group.Students);

            CollectionAssert.IsNotEmpty(result);
        }

        /// <summary>
        /// The method tests the method GetAverageMarkByGroup.
        /// </summary>
        [Test]
        public void Test_GetAverageMarkForGroup()
        {
            Session session = _orm.Sessions.First();

            double result = ReportData.GetAverageMarkByGroup(session.ID, session.Group);
            double actualResult = 4.888888;

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests the method GetMaxMarkByGroup.
        /// </summary>
        [Test]
        public void Test_GetMaxMarkforGroup()
        {
            Session session = _orm.Sessions.First();

            double result = ReportData.GetMaxMarkByGroup(session.ID, session.Group);
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

            double result = ReportData.GetMinMarkByGroup(session.ID, session.Group);
            double actualResult = 2;

            Assert.AreEqual(result, actualResult);
        }
    }
}
