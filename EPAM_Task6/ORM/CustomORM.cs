using EPAM_Task6.Tables;

namespace EPAM_Task6.ORM
{
    /// <summary>
    /// Class for storing database table.
    /// </summary>
    public class CustomORM : CustomDbContext
    {
        private static CustomORM _instance;

        public CustomDbSet<Student> Students { get; set; }

        public CustomDbSet<Group> Groups { get; set; }

        public CustomDbSet<Session> Sessions { get; set; }

        public CustomDbSet<Exam> Exams { get; set; }

        public CustomDbSet<Credit> Credits { get; set; }

        public CustomDbSet<Discipline> Disciplines { get; set; }

        public CustomDbSet<ExamResult> ExamResults { get; set; }

        public CustomDbSet<CreditResult> CreditResults { get; set; }

        /// <summary>
        /// Constructor initializes tables.
        /// </summary>
        private CustomORM() :
            base()
        {
            Students = new CustomDbSet<Student>(_sqlConnection);
            Groups = new CustomDbSet<Group>(_sqlConnection);
            Sessions = new CustomDbSet<Session>(_sqlConnection);
            Exams = new CustomDbSet<Exam>(_sqlConnection);
            Credits = new CustomDbSet<Credit>(_sqlConnection);
            Disciplines = new CustomDbSet<Discipline>(_sqlConnection);
            ExamResults = new CustomDbSet<ExamResult>(_sqlConnection);
            CreditResults = new CustomDbSet<CreditResult>(_sqlConnection);

            LoadRelations();
        }

        public static CustomORM Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomORM();
                }

                return _instance;
            }
        }

        /// <summary>
        /// The method loads all relationships between tables.
        /// </summary>
        private void LoadRelations()
        {
            DatabaseRelations.LoadCreditRelations(Credits, CreditResults, Sessions, Disciplines);
            DatabaseRelations.LoadCreditResultRelations(CreditResults, Credits, Students);
            DatabaseRelations.LoadDisciplineRelations(Disciplines, Exams, Credits);
            DatabaseRelations.LoadExamRelations(Exams, ExamResults, Sessions, Disciplines);
            DatabaseRelations.LoadExamResultRelations(ExamResults, Exams, Students);
            DatabaseRelations.LoadGroupRelations(Groups, Students, Sessions);
            DatabaseRelations.LoadSessionRelations(Sessions, Groups, Exams, Credits);
            DatabaseRelations.LoadStudentRelations(Students, ExamResults, CreditResults, Groups);
        }
    }
}
