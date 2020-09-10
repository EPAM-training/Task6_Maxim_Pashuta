using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using System.Linq;

namespace EPAM_Task6.DatabaseWork
{
    /// <summary>
    /// Class for setting relationships between tables into a database.
    /// </summary>
    public static class DatabaseRelations
    {
        /// <summary>
        /// The emthod sets relationship between Session Object and Group Object.
        /// </summary>
        /// <param name="session">Session object</param>
        /// <param name="groups">Group collection</param>
        public static void LoadRelationSessionGroup(Session session, CustomDbSet<Group> groups)
        {
            session.Group = groups.First(obj => obj.ID == session.GroupID);
        }

        /// <summary>
        /// The emthod sets relationship between Group Object and Student Objects.
        /// </summary>
        /// <param name="group">Group object</param>
        /// <param name="students">Student collection</param>
        public static void LoadRelationGroupStudent(Group group, CustomDbSet<Student> students)
        {
            group.Students = students.Where(obj => obj.GroupID == group.ID).ToList();
        }

        /// <summary>
        /// The emthod sets relationship between Student Object and ExamResult Objects.
        /// </summary>
        /// <param name="student">Student object</param>
        /// <param name="examResults">ExamResult collection</param>
        public static void LoadRelationStudentExamResult(Student student, CustomDbSet<ExamResult> examResults)
        {
            student.ExamResults = examResults.Where(obj => obj.StudentID == student.ID).ToList();
        }

        /// <summary>
        /// The emthod sets relationship between Student Object and Group Object.
        /// </summary>
        /// <param name="student">Student object</param>
        /// <param name="groups">Group collection</param>
        public static void LoadRelationStudentGroup(Student student, CustomDbSet<Group> groups)
        {
            student.Group = groups.First(obj => obj.ID == student.GroupID);
        }

        /// <summary>
        /// The emthod sets relationship between ExamResult Object and Exam Object.
        /// </summary>
        /// <param name="examResult">ExamResult object</param>
        /// <param name="exams">Exam collection</param>
        public static void LoadRelationExamResultExam(ExamResult examResult, CustomDbSet<Exam> exams)
        {
            examResult.Exam = exams.First(obj => obj.ID == examResult.ExamID);
        }
    }
}
