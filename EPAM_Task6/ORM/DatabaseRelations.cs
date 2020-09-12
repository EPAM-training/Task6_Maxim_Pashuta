using EPAM_Task6.ORM;
using EPAM_Task6.Tables;
using System.Linq;

namespace EPAM_Task6
{
    /// <summary>
    /// Class for setting relationships between tables into a database.
    /// </summary>
    public static class DatabaseRelations
    {
        /// <summary>
        /// The method sets relationships for Session.
        /// </summary>
        /// <param name="session">Session object</param>
        /// <param name="groups">Group collection</param>
        /// <param name="exams">Exam collection</param>
        /// <param name="credits">Credit collection</param>
        public static void LoadSessionRelations(CustomDbSet<Session> sessions, CustomDbSet<Group> groups, CustomDbSet<Exam> exams, CustomDbSet<Credit> credits)
        {
            foreach (Session session in sessions)
            {
                session.Group = groups.First(obj => obj.ID == session.GroupID);
                session.Exams = exams.Where(obj => obj.SessionID == session.ID).ToList();
                session.Credits = credits.Where(obj => obj.SessionID == session.ID).ToList();
            }
        }

        /// <summary>
        /// The method sets relationship for Group.
        /// </summary>
        /// <param name="group">Group object</param>
        /// <param name="students">Student collection</param>
        public static void LoadGroupRelations(CustomDbSet<Group> groups, CustomDbSet<Student> students, CustomDbSet<Session> sessions)
        {
            foreach (Group group in groups)
            {
                group.Students = students.Where(obj => obj.GroupID == group.ID).ToList();
                group.Sessions = sessions.Where(obj => obj.GroupID == group.ID).ToList();
            }
        }

        /// <summary>
        /// The method sets relationship between Student Object and ExamResult Objects.
        /// </summary>
        /// <param name="student">Student object</param>
        /// <param name="examResults">ExamResult collection</param>
        public static void LoadStudentRelations(CustomDbSet<Student> students, CustomDbSet<ExamResult> examResults, CustomDbSet<CreditResult> creditResults, CustomDbSet<Group> groups)
        {
            foreach (Student student in students)
            {
                student.ExamResults = examResults.Where(obj => obj.StudentID == student.ID).ToList();
                student.CreditResults = creditResults.Where(obj => obj.StudentID == student.ID).ToList();
                student.Group = groups.First(obj => obj.ID == student.GroupID);
            }
        }

        /// <summary>
        /// The method sets relationships for ExamResult table.
        /// </summary>
        /// <param name="examResult">ExamResult object</param>
        /// <param name="exams">Exam collection</param>
        /// <param name="students">Student collection</param>
        public static void LoadExamResultRelations(CustomDbSet<ExamResult> examResults, CustomDbSet<Exam> exams, CustomDbSet<Student> students)
        {
            foreach (ExamResult examResult in examResults)
            {
                examResult.Exam = exams.First(obj => obj.ID == examResult.ExamID);
                examResult.Student = students.First(obj => obj.ID == examResult.StudentID);
            }
        }

        /// <summary>
        /// The method sets relationships for CreditResult.
        /// </summary>
        /// <param name="creditResults">CreditResult collection</param>
        /// <param name="credits">Credit collection</param>
        /// <param name="students">Student Collection</param>
        public static void LoadCreditResultRelations(CustomDbSet<CreditResult> creditResults, CustomDbSet<Credit> credits, CustomDbSet<Student> students)
        {
            foreach (CreditResult creditResult in creditResults)
            {
                creditResult.Credit = credits.First(obj => obj.ID == creditResult.CreditID);
                creditResult.Student = students.First(obj => obj.ID == creditResult.StudentID);
            }
        }

        /// <summary>
        /// The method sets relationships for Exam.
        /// </summary>
        /// <param name="exams">Exam collection</param>
        /// <param name="examResults">ExamResult collection</param>
        /// <param name="sessions">Session collection</param>
        /// <param name="disciplines">Discipline collection</param>
        public static void LoadExamRelations(CustomDbSet<Exam> exams, CustomDbSet<ExamResult> examResults, CustomDbSet<Session> sessions, CustomDbSet<Discipline> disciplines)
        {
            foreach (Exam exam in exams)
            {
                exam.ExamResults = examResults.Where(obj => obj.ExamID == exam.ID).ToList();
                exam.Session = sessions.First(obj => obj.ID == exam.SessionID);
                exam.Discipline = disciplines.First(obj => obj.ID == exam.DisciplineID);
            }
        }

        /// <summary>
        /// The method sets relationships for Credit.
        /// </summary>
        /// <param name="credits">Credit collection</param>
        /// <param name="creditResults">CreditResult collection</param>
        /// <param name="sessions">Session collection</param>
        /// <param name="disciplines">Discipline collection</param>
        public static void LoadCreditRelations(CustomDbSet<Credit> credits, CustomDbSet<CreditResult> creditResults, CustomDbSet<Session> sessions, CustomDbSet<Discipline> disciplines)
        {
            foreach (Credit credit in credits)
            {
                credit.CreditResults = creditResults.Where(obj => obj.CreditID == credit.ID).ToList();
                credit.Session = sessions.First(obj => obj.ID == credit.SessionID);
                credit.Discipline = disciplines.First(obj => obj.ID == credit.DisciplineID);
            }
        }

        /// <summary>
        /// The method sets relationships for Discipline.
        /// </summary>
        /// <param name="disciplines">Discipline collection</param>
        /// <param name="exams">Exam collection</param>
        /// <param name="credits">Credit collection</param>
        public static void LoadDisciplineRelations(CustomDbSet<Discipline> disciplines, CustomDbSet<Exam> exams, CustomDbSet<Credit> credits)
        {
            foreach (Discipline discipline in disciplines)
            {
                discipline.Exams = exams.Where(obj => obj.DisciplineID == discipline.ID).ToList();
                discipline.Credits = credits.Where(obj => obj.DisciplineID == discipline.ID).ToList();
            }
        }
    }
}
