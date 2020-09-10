using EPAM_Task6.CustomExceptions;
using EPAM_Task6.DatabaseWork;
using EPAM_Task6.Enums;
using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using ExcelLibrary.SpreadSheet;
using System.Collections.Generic;
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
            int leftBoard = 0;
            int rightBoard = 2;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            CustomORM orm = CustomORM.Instance;
            List<Session> sessions = orm.Sessions.Where(obj => obj.SemesterNumber == sessionNumber).ToList();

            // Load relations:  Session_Group,  Group_Student,  Student_ExamResults
            foreach (Session session in sessions)
            {
                DatabaseRelations.LoadRelationSessionGroup(session, orm.Groups);
                DatabaseRelations.LoadRelationGroupStudent(session.Group, orm.Students);

                foreach (Student student in session.Group.Students)
                {
                    DatabaseRelations.LoadRelationStudentExamResult(student, orm.ExamResults);

                    foreach (ExamResult examResult in student.ExamResults)
                    {
                        DatabaseRelations.LoadRelationExamResultExam(examResult, orm.Exams);
                    }
                }
            }

            // Filling the XLSX file with data
            Workbook workBook = new Workbook();
            Worksheet workSheet = new Worksheet("SessionReport");

            workSheet.Cells[0, 0] = new Cell(nameof(Session));
            workSheet.Cells[0, 1] = new Cell(nameof(Group));
            workSheet.Cells[0, 2] = new Cell("Average Mark");

            int rowNumber = 1;

            foreach (Session session in sessions)
            {
                workSheet.Cells[rowNumber, 0] = new Cell(session.SemesterNumber);
                workSheet.Cells[rowNumber, 1] = new Cell(session.Group.Name);
                workSheet.Cells[rowNumber, 2] = new Cell(WorkWithGroupTable.GetAverageMarkByGroup(session.ID, session.Group));

                rowNumber++;
            }

            // Selects the sort type and sorts
            if (typeSort == TypeSort.Ascending)
            {
                workSheet = SortTable.SortByAscending(workSheet, columnToSort);
            }
            else
            {
                workSheet = SortTable.SortByDescending(workSheet, columnToSort);
            }

            workBook.Worksheets.Add(workSheet);
            workBook.Save(filePath);
        }

        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with all session results and sorts it.
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateAllSessionReports(string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 0;
            int rightBoard = 4;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);
            CustomORM orm = CustomORM.Instance;

            // Load relations:  Session_Group,  Group_Student,  Student_ExamResults
            foreach (Session session in orm.Sessions)
            {
                DatabaseRelations.LoadRelationSessionGroup(session, orm.Groups);
                DatabaseRelations.LoadRelationGroupStudent(session.Group, orm.Students);

                foreach (Student student in session.Group.Students)
                {
                    DatabaseRelations.LoadRelationStudentExamResult(student, orm.ExamResults);

                    foreach (ExamResult examResult in student.ExamResults)
                    {
                        DatabaseRelations.LoadRelationExamResultExam(examResult, orm.Exams);
                    }
                }
            }

            // Filling the XLSX file with data
            Workbook workBook = new Workbook();
            Worksheet workSheet = new Worksheet("SessionReport");

            workSheet.Cells[0, 0] = new Cell(nameof(Session));
            workSheet.Cells[0, 1] = new Cell(nameof(Group));
            workSheet.Cells[0, 2] = new Cell("Average Mark");
            workSheet.Cells[0, 3] = new Cell("Max Mark");
            workSheet.Cells[0, 4] = new Cell("Min Mark");

            int rowNumber = 1;

            foreach (Session session in orm.Sessions)
            {
                workSheet.Cells[rowNumber, 0] = new Cell(session.SemesterNumber);
                workSheet.Cells[rowNumber, 1] = new Cell(session.Group.Name);
                workSheet.Cells[rowNumber, 2] = new Cell(WorkWithGroupTable.GetAverageMarkByGroup(session.ID, session.Group));
                workSheet.Cells[rowNumber, 3] = new Cell(WorkWithGroupTable.GetMaxMarkByGroup(session.ID, session.Group));
                workSheet.Cells[rowNumber, 4] = new Cell(WorkWithGroupTable.GetMinMarkByGroup(session.ID, session.Group));

                rowNumber++;
            }

            // Selects the sort type and sorts
            if (typeSort == TypeSort.Ascending)
            {
                workSheet = SortTable.SortByAscending(workSheet, columnToSort);
            }
            else
            {
                workSheet = SortTable.SortByDescending(workSheet, columnToSort);
            }

            workBook.Worksheets.Add(workSheet);
            workBook.Save(filePath);
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
            int leftBoard = 0;
            int rightBoard = 1;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            CustomORM orm = CustomORM.Instance;
            Group group = orm.Groups.First(obj => obj.Name == groupName);

            // Load relations:  Group_Student,  Student_ExamResults
            DatabaseRelations.LoadRelationGroupStudent(group, orm.Students);

            foreach (Student student in group.Students)
            {
                DatabaseRelations.LoadRelationStudentExamResult(student, orm.ExamResults);
                DatabaseRelations.LoadRelationStudentGroup(student, orm.Groups);
            }

            List<Student> badStudentList =  WorkWithStudentTable.GetBadStudentList(group.Students);

            // Filling the XLSX file with data
            Workbook workBook = new Workbook();
            Worksheet workSheet = new Worksheet("SessionReport");

            workSheet.Cells[0, 0] = new Cell(nameof(Group));
            workSheet.Cells[0, 1] = new Cell(nameof(Student));

            int rowNumber = 1;

            foreach (Student student in badStudentList)
            {
                workSheet.Cells[rowNumber, 0] = new Cell(student.Group.Name);
                workSheet.Cells[rowNumber, 1] = new Cell(student.FullName);

                rowNumber++;
            }

            // Selects the sort type and sorts
            if (typeSort == TypeSort.Ascending)
            {
                workSheet = SortTable.SortByAscending(workSheet, columnToSort);
            }
            else
            {
                workSheet = SortTable.SortByDescending(workSheet, columnToSort);
            }

            workBook.Worksheets.Add(workSheet);
            workBook.Save(filePath);
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
    }
}
