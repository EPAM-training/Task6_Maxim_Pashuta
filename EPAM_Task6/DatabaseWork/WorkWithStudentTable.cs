using EPAM_Task6.Tables;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task6.DatabaseWork
{
    /// <summary>
    /// Class for working table Student.
    /// </summary>
    public static class WorkWithStudentTable
    {
        /// <summary>
        /// The method returns loser student list.
        /// </summary>
        /// <param name="students">Student collection</param>
        /// <returns>Loser student list</returns>
        public static List<Student> GetBadStudentList(List<Student> students)
        {
            var badStudentList = new List<Student>();

            foreach (Student student in students)
            {
                if (IsBadStudent(student))
                {
                    badStudentList.Add(student);
                }
            }

            return badStudentList;
        }

        /// <summary>
        /// The method checks if the student is a bad student.
        /// </summary>
        /// <param name="student">Stduent</param>
        /// <returns>True or false</returns>
        private static bool IsBadStudent(Student student)
        {
            int minMark = 4;
            var examResults = student.ExamResults.Where(obj => obj.Result < 4).ToList();

            return (examResults.Count >= 3);
        }
    }
}
