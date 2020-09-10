using System.Collections.Generic;

namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table Session.
    /// </summary>
    public class Session : BaseModel
    {
        public int GroupID { get; set; }

        public int SemesterNumber { get; set; }

        public Group Group { get; set; }

        public List<Exam> Exams { get; set; }

        public List<Credit> Credits { get; set; }

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

            var session = (Session)obj;

            return ((session.ID == ID) &&
                    (session.GroupID == GroupID) &&
                    (session.SemesterNumber == SemesterNumber));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ GroupID ^ SemesterNumber);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"GroupID: {GroupID}\n" +
                                                   $"SemesterNumber: {SemesterNumber}\n");
        }
    }
}
