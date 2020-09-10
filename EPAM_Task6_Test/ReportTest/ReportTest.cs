using EPAM_Task6.CustomExceptions;
using EPAM_Task6.Enums;
using EPAM_Task6.Reports;
using NUnit.Framework;
using System.IO;

namespace EPAM_Task6_Test.Reports
{
    /// <summary>
    /// Class for testing class Report.
    /// </summary>
    public class ReportTest
    {
        /// <summary>
        /// The method tests the method GenerateSessionReport when column number exists.
        /// </summary>
        [Test]
        public void GenerateSessionReport_WhenColumnNumberExists_WriteSessionResult()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new1.xls";
            int sessionNumber = 1;
            int columnNumber = 2;

            Report.GenerateSessionReport(sessionNumber, filePath, TypeSort.Ascending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateSessionReport when column number not exists.
        /// </summary>
        [Test]
        public void GenerateSessionReport_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new1.xls";
            int sessionNumber = 2;
            int columnNumber = 5;

            Assert.That(() => Report.GenerateSessionReport(sessionNumber, filePath, TypeSort.Ascending, columnNumber), Throws.TypeOf<ColumnNumberException>());
        }

        /// <summary>
        /// The method tests the method GenerateAllSessionReports when column number exists.
        /// </summary>
        [Test]
        public void GenerateAllSessionReports_WhenColumnNumberExists_WriteAllSessionResults()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new2.xls";
            int columnNumber = 2;

            Report.GenerateAllSessionReports(filePath, TypeSort.Descending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateAllSessionReports when column number not exists.
        /// </summary>
        [Test]
        public void GenerateAllSessionReports_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new2.xls";
            int columnNumber = -1;

            Assert.That(() => Report.GenerateAllSessionReports(filePath, TypeSort.Ascending, columnNumber), Throws.TypeOf<ColumnNumberException>());
        }

        /// <summary>
        /// The method tests the method GenerateBadStudentsListByGroup when column number exists.
        /// </summary>
        [Test]
        public void GenerateBadStudentsListByGroup_WhenColumnNumberExists_WriteBadStudentsListByGroup()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new3.xls";
            string groupName = "IP-22";
            int columnNumber = 1;

            Report.GenerateBadStudentsListByGroup(groupName, filePath, TypeSort.Descending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateBadStudentsListByGroup when column number not exists.
        /// </summary>
        [Test]
        public void GenerateBadStudentsListByGroup_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\..\EPAM_Task6\Resources\new1.xls";
            string groupName = "IP-22";
            int columnNumber = 6;

            Assert.That(() => Report.GenerateBadStudentsListByGroup(groupName, filePath, TypeSort.Ascending, columnNumber), Throws.TypeOf<ColumnNumberException>());
        }
    }
}
