using System;
using System.Collections.Generic;

namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table Student.
    /// </summary>
    public class Student : BaseModel
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public int GroupID { get; set; }

        public Group Group { get; set; }

        public List<CreditResult> CreditResults { get; set; }

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

            var student = (Student)obj;

            return ((student.ID == ID) &&
                    (student.FullName == FullName) &&
                    (student.Gender == Gender) &&
                    (student.Birthdate.Equals(Birthdate)) &&
                    (student.GroupID == GroupID));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ FullName.GetHashCode() ^ Gender.GetHashCode() ^ Birthdate.GetHashCode() ^ GroupID);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"FullName: {FullName}\n" +
                                                   $"Gender: {Gender}\n" +
                                                   $"Birthdate: {Birthdate:dd.MM.yyyy}\n" +
                                                   $"GroupID: {GroupID}");
        }
    }
}
