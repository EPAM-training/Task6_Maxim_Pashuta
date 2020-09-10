namespace EPAM_Task6.Tables
{
    /// <summary>
    /// Class for working with table.
    /// </summary>
    public abstract class BaseModel
    {
        public int ID { get; set; }

        //public ModelState State { get; set; }

        public override string ToString()
        {
            return string.Format($"Id: {this.ID}\n");
        }
    }
}
