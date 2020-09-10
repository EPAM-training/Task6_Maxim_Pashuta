using EPAM_Task6.Tables;

namespace EPAM_Task6.CRUD.Interfaces
{
    /// <summary>
    /// Interface sets methods that should be realizate.
    /// </summary>
    /// <typeparam name="T">Class that inherits the class BaseModel</typeparam>
    public interface ICrud<T> where T : BaseModel
    {
        void Insert(T obj);
        void Update(int id, T obj);
        void Delete(int id);
        T Read(int id);
    }
}
