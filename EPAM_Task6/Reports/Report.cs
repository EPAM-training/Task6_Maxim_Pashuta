using EPAM_Task6.CustomExceptions;
using EPAM_Task6.Enums;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EPAM_Task6.Reports
{
    /// <summary>
    /// Class for generating report.
    /// </summary>
    public static class Report
    {
        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with session results and sorts it.
        /// </summary>
        /// <param name="sessionNumber">Session number</param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateSessionReport(int sessionNumber, string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 1;
            int rightBoard = 3;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            CustomORM orm = CustomORM.Instance;
            List<Session> sessions = orm.Sessions.Where(obj => obj.SemesterNumber == sessionNumber).ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {   
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with data
                foreach (Session session in sessions)
                {
                    worksheet.Cells[rowNumber, 1].Value = session.SemesterNumber;
                    worksheet.Cells[rowNumber, 2].Value = session.Group.Name;
                    worksheet.Cells[rowNumber, 3].Value = ReportData.GetAverageMarkByGroup(session.ID, session.Group);

                    rowNumber++;
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = nameof(Session);
                worksheet.Cells[1, 2].Value = nameof(Group);
                worksheet.Cells[1, 3].Value = "Average Mark";

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with all session results and sorts it.
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateAllSessionReports(string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 1;
            int rightBoard = 5;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);
            CustomORM orm = CustomORM.Instance;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with data
                foreach (Session session in orm.Sessions)
                {
                    worksheet.Cells[rowNumber, 1].Value = session.SemesterNumber;
                    worksheet.Cells[rowNumber, 2].Value = session.Group.Name;
                    worksheet.Cells[rowNumber, 3].Value = ReportData.GetAverageMarkByGroup(session.ID, session.Group);
                    worksheet.Cells[rowNumber, 4].Value = ReportData.GetMaxMarkByGroup(session.ID, session.Group);
                    worksheet.Cells[rowNumber, 5].Value = ReportData.GetMinMarkByGroup(session.ID, session.Group);

                    rowNumber++;
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = nameof(Session);
                worksheet.Cells[1, 2].Value = nameof(Group);
                worksheet.Cells[1, 3].Value = "Average Mark";
                worksheet.Cells[1, 4].Value = "Max Mark";
                worksheet.Cells[1, 5].Value = "Min Mark";

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with bad students list and sorts it.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateBadStudentsListByGroup(string groupName, string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 1;
            int rightBoard = 2;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            CustomORM orm = CustomORM.Instance;
            Group group = orm.Groups.Where(obj => obj.Name == groupName).First();

            List<Student> badStudentList = ReportData.GetBadStudentList(group.Students);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with data
                foreach (Student student in badStudentList)
                {
                    worksheet.Cells[rowNumber, 1].Value = student.Group.Name;
                    worksheet.Cells[rowNumber, 2].Value = student.FullName;

                    rowNumber++;
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = nameof(Group);
                worksheet.Cells[1, 2].Value = nameof(Student);

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method checks for column existence.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="leftBoard"></param>
        /// <param name="rightBoard"></param>
        private static void IsExistColumn(int columnNumber, int leftBoard, int rightBoard)
        {
            if ((columnNumber < leftBoard) || (columnNumber > rightBoard))
            {
                throw new ColumnNumberException("This column is not exist.");
            }
        }

        /// <summary>
        /// The method shifts the rows in the table one row down.
        /// </summary>
        /// <param name="worksheet">Table</param>
        private static void MoveRowsDown(ExcelWorksheet worksheet)
        {
            for (int i = worksheet.Dimension.Rows; i > 0; i--)
            {
                for (int j = 1; j <= worksheet.Dimension.Columns; j++)
                {
                    worksheet.Cells[i + 1, j].Value = worksheet.Cells[i, j].Value;
                }
            }
        }
    }
}
