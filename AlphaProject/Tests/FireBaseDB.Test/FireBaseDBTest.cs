using FireBaseDB.DB;
using FireBaseDB.DB.Impl;
using ModleLibrary.Model;

namespace FireBaseDB.Test
{
    [TestClass]
    public sealed class FireBaseDBTest
    {
        private IFireBaseDBContext? fireBaseDBContext;

        [TestInitialize]
        public void TestInitialize()
        {
            fireBaseDBContext = new FireBaseDBContext("1234u", "https://fir-db-470aa-default-rtdb.firebaseio.com");
        }

        /// <summary>
        /// Adds the person test.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        [TestMethod]
        [DataRow("name1", "LastName1")]
        [DataRow("name2", "LastName2")]
        [DataRow("name3", "LastName3")]
        public void AddPersonTest(string firstName, string lastName)
        {
            // Arrange
            TestDataFactory testDataFactory = new TestDataFactory();
            Person person = testDataFactory.CreatePerson(firstName,lastName);

            // Act
            string guid = fireBaseDBContext.AddPerson(person);
            Person result = fireBaseDBContext.GetPerson(guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, firstName);
            Assert.AreEqual(result.LastName, lastName);
        }

        /// <summary>
        /// Get all persons test.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        [TestMethod]
        public void GetPersonsTest()
        {
            // Arrange
            TestDataFactory testDataFactory = new TestDataFactory();

            // Act
            List<Person> result = fireBaseDBContext.GetPersonList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
        }
    }
}
