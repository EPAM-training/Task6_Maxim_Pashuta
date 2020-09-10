using EPAM_Task6.Tables;
using System.Linq;

namespace EPAM_Task6.DatabaseWork
{
    /// <summary>
    /// Class for working table Group.
    /// </summary>
    public static class WorkWithGroupTable
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
    }
}
