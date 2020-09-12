using EPAM_Task6.Tables;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task6.Reports
{
    /// <summary>
    /// Class for working Report data.
    /// </summary>
    public static class ReportData
    {
        /// <summary>
        /// The method returns average mark by group.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="group"></param>
        /// <returns>Average mark</returns>
        public static double GetAverageMarkByGroup(int sessionId, Group group)
        {
            double averageMark = 0;

            foreach (Student student in group.Students)
            {
                averageMark += student.ExamResults.Where(obj => obj.Exam.SessionID == sessionId)
                                                  .Select(obj => obj.Result)
                                                  .Average();
            }

            return (averageMark / group.Students.Count);
        }

        /// <summary>
        /// The method returns max mark by group.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="group"></param>
        /// <returns>Max mark</returns>
        public static int GetMaxMarkByGroup(int sessionId, Group group)
        {
            int maxMark = 0;

            foreach (Student student in group.Students)
            {
                int maxcurrentStudentMark = student.ExamResults.Where(obj => obj.Exam.SessionID == sessionId)
                                                               .Select(obj => obj.Result)
                                                               .Max();

                if (maxcurrentStudentMark > maxMark)
                {
                    maxMark = maxcurrentStudentMark;
                }
            }

            return maxMark;
        }

        /// <summary>
        /// The method returns min mark by group.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="group"></param>
        /// <returns>Min mark</returns>
        public static int GetMinMarkByGroup(int sessionId, Group group)
        {
            int minMark = 10;

            foreach (Student student in group.Students)
            {
                int mincurrentStudentMark = student.ExamResults.Where(obj => obj.Exam.SessionID == sessionId)
                                                               .Select(obj => obj.Result)
                                                               .Min();

                if (mincurrentStudentMark < minMark)
                {
                    minMark = mincurrentStudentMark;
                }
            }

            return minMark;
        }

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
