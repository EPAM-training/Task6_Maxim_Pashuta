using EPAM_Task6.Tables;
using System;
using System.Reflection;

namespace EPAM_Task6.Creators
{
    /// <summary>
    /// Class for creating any objects.
    /// </summary>
    public static class ModelFactory
    {
        /// <summary>
        /// Method creates an object that inherits the class BaseModel.
        /// </summary>
        /// <typeparam name="T">Class that inherits the class BaseModel</typeparam>
        /// <returns></returns>
        public static BaseModel CreateModel<T>() where T : BaseModel
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Method creates an object whose name is passed to the method.
        /// </summary>
        /// <param name="modelFullName">Class path</param>
        /// <returns></returns>
        public static BaseModel CreateModel(string modelFullName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(modelFullName).FullName;
            return (BaseModel)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
