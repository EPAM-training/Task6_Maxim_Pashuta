﻿namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table ExamResult.
    /// </summary>
    public class ExamResult : BaseModel
    {
        public int StudentID { get; set; }

        public int ExamID { get; set; }

        public int Result { get; set; }

        public Exam Exam { get; set; }

        public Student Student { get; set; }

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

            var examResult = (ExamResult)obj;

            return ((examResult.ID == ID) &&
                    (examResult.StudentID == StudentID) &&
                    (examResult.ExamID == ExamID) &&
                    (examResult.Result == Result));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ StudentID ^ ExamID ^ Result);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"StudentID: {StudentID}\n" +
                                                   $"ExamID: {ExamID}\n" +
                                                   $"Result: {Result}");
        }
    }
}
