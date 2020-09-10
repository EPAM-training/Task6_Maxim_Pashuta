using System.Collections.Generic;

namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table Discipline.
    /// </summary>
    public class Discipline : BaseModel
    {
        public string Name { get; set; }

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

            var discipline = (Discipline)obj;

            return ((discipline.ID == ID) &&
                    (discipline.Name == Name));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ Name.GetHashCode());
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"Name: {Name}");
        }
    }
}
