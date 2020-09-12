using System;
using System.Collections.Generic;

namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table Exam
    /// </summary>
    public class Exam : BaseModel
    {
        public int SessionID { get; set; }

        public int DisciplineID { get; set; }

        public DateTime Date { get; set; }

        public Session Session { get; set; }

        public Discipline Discipline { get; set; }

        public List<ExamResult> ExamResults { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
            {
                return false;
            }

            var exam = (Exam)obj;

            return ((exam.ID == ID) &&
                    (exam.SessionID == SessionID) &&
                    (exam.DisciplineID == DisciplineID) &&
                    (exam.Date.Equals(Date)));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ SessionID ^ DisciplineID ^ Date.GetHashCode());
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"SessionId: {SessionID}\n" +
                                                   $"DisciplineId: {DisciplineID}\n" +
                                                   $"Date: {Date:dd.MM.yyyy}");
        }
    }
}
