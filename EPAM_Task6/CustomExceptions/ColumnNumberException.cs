using System;

namespace EPAM_Task6.CustomExceptions
{
    /// <summary>
    /// Class for working custom Exception.
    /// </summary>
    public class ColumnNumberException : Exception
    {
        public ColumnNumberException()
        {
        }

        public ColumnNumberException(string message)
            : base(message)
        {
        }
    }
}
