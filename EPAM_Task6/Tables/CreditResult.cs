namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table CreditResult.
    /// </summary>
    public class CreditResult : BaseModel
    {
        public int StudentID { get; set; }

        public int CreditID { get; set; }

        public bool Result { get; set; }

        public Credit Credit { get; set; }

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

            var creditResult = (CreditResult)obj;

            return ((creditResult.ID == ID) &&
                    (creditResult.StudentID == StudentID) &&
                    (creditResult.CreditID == CreditID) &&
                    (creditResult.Result == Result));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (ID ^ StudentID ^ CreditID ^ Result.GetHashCode());
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"StudentID: {StudentID}\n" +
                                                   $"CreditID: {CreditID}\n" +
                                                   $"Result: {Result}");
        }
    }
}
