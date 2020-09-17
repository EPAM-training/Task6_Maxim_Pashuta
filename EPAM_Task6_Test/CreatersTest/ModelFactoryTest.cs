using EPAM_Task6.Creators;
using EPAM_Task6.Tables;
using NUnit.Framework;

namespace EPAM_Task6_Test.CreatersTest
{
    /// <summary>
    /// Class for testing class ModelFactory.
    /// </summary>
    public class ModelFactoryTest
    {
        /// <summary>
        /// The method tests the method CreateModel when type is not abstract.
        /// </summary>
        [Test]
        public void CreateModel_WhenTypeIsNotAbstract_GetObject()
        {
            Student result = (Student)ModelFactory.CreateModel<Student>();
            Student actualResult = new Student();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method CreateModel when type is abstract.
        /// </summary>
        [Test]
        public void CreateModel_WhenTypeIsAbstract_ThrowsException()
        {
            Assert.That(() => ModelFactory.CreateModel<BaseModel>(), Throws.Exception);
        }

        /// <summary>
        /// The method tests the method CreateModel when model in this assembly.
        /// </summary>
        [Test]
        public void CreateModel_WhenModelInThisAssembly_GetObject()
        {
            string modelName = typeof(Student).FullName;
            BaseModel result = ModelFactory.CreateModel(modelName);
            BaseModel actualResult = new Student();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method CreateModel.
        /// </summary>
        /// <param name="modelFullName">Model full name</param>
        [TestCase("Student", TestName = "CreateModel_WhenModelIsNotFullName_ThrowsException")]
        [TestCase("Hdghdh", TestName = "CreateModel_WhenModelIsNotInThisAssembly_ThrowsException")]
        public void Test_CreateModel(string modelFullName)
        {
            Assert.That(() => ModelFactory.CreateModel(modelFullName), Throws.Exception);
        }
    }
}