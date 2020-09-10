using ExcelLibrary.SpreadSheet;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task6.Reports
{
    /// <summary>
    /// Class for sorting table.
    /// </summary>
    public static class SortTable
    {
        /// <summary>
        /// The method sorts the table in ascending order by a specific column.
        /// </summary>
        /// <param name="worksheet">Table</param>
        /// <param name="columnNumber">Column number</param>
        /// <returns>Sorted table</returns>
        public static Worksheet SortByAscending(Worksheet worksheet, int columnNumber)
        {
            int rowNumber = 0;
            Worksheet newWorkSheet = new Worksheet("SessionReport");
            var listRows = new List<KeyValuePair<int, Row>>();

            listRows.Add(worksheet.Cells.Rows.First(obj => obj.Key == 0));
            listRows.AddRange(worksheet.Cells.Rows.Where(obj => obj.Key != 0)
                                                  .OrderBy(obj => obj.Value.GetCell(columnNumber).Value)
                                                  .ToList());

            foreach (var row in listRows)
            {
                newWorkSheet.Cells[rowNumber, 0] = row.Value.GetCell(0);
                newWorkSheet.Cells[rowNumber, 1] = row.Value.GetCell(1);
                newWorkSheet.Cells[rowNumber, 2] = row.Value.GetCell(2);
                newWorkSheet.Cells[rowNumber, 3] = row.Value.GetCell(3);
                newWorkSheet.Cells[rowNumber, 4] = row.Value.GetCell(4);

                rowNumber++;
            }

            return newWorkSheet;
        }

        /// <summary>
        /// The method sorts the table in descending order by a specific column.
        /// </summary>
        /// <param name="worksheet">Table</param>
        /// <param name="columnNumber">Column number</param>
        /// <returns>Sorted table</returns>
        public static Worksheet SortByDescending(Worksheet worksheet, int columnNumber)
        {
            int rowNumber = 0;
            Worksheet newWorkSheet = new Worksheet("SessionReport");
            var listRows = new List<KeyValuePair<int, Row>>();

            listRows.Add(worksheet.Cells.Rows.First(obj => obj.Key == 0));
            listRows.AddRange(worksheet.Cells.Rows.Where(obj => obj.Key != 0)
                                                  .OrderByDescending(obj => obj.Value.GetCell(columnNumber).Value)
                                                  .ToList());

            foreach (var row in listRows)
            {
                newWorkSheet.Cells[rowNumber, 0] = row.Value.GetCell(0);
                newWorkSheet.Cells[rowNumber, 1] = row.Value.GetCell(1);
                newWorkSheet.Cells[rowNumber, 2] = row.Value.GetCell(2);
                newWorkSheet.Cells[rowNumber, 3] = row.Value.GetCell(3);
                newWorkSheet.Cells[rowNumber, 4] = row.Value.GetCell(4);

                rowNumber++;
            }

            return newWorkSheet;
        }
    }
}
