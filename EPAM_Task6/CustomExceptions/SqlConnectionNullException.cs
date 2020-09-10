using System;

namespace EPAM_Task6.CustomExceptions
{
    public class SqlConnectionNullException : Exception
    {
        public SqlConnectionNullException()
        {
        }

        public SqlConnectionNullException(string message)
            : base(message)
        {
        }
    }
}
