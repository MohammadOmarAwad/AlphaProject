using DateProvider;
using FireBaseDB.DB;
using FireBaseDB.DB.Impl;
using FireBaseDB.Test.Base;
using ModleLibrary.Base;
using ModleLibrary.Model;
using Newtonsoft.Json;

namespace FireBaseDB.Test
{
    [TestClass]
    public sealed class FireBaseDBTest : TestBase
    {
        private IFireBaseDBContext? fireBaseDBContext;
        private IDateProvider? dateProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            String jsonRequest = LoadInputData("FireBaseDB.Test.local.settings.json");
            LocalSettings localSettings = JsonConvert.DeserializeObject<LocalSettings>(jsonRequest) ?? throw new ArgumentNullException();

            fireBaseDBContext = new FireBaseDBContext(localSettings?.FireBase_AuthSecret, localSettings?.FireBase_BasePath);
            dateProvider = new DateProvider.Impl.DateProvider();
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
        public void AddPersonTest(String firstName, String lastName)
        {
            // Arrange
            TestDataFactory testDataFactory = new TestDataFactory();
            Person? person = testDataFactory.CreatePerson(firstName, lastName);

            if (person != null && dateProvider != null)
            {
                person.CreatedOn = dateProvider.GetCurrentDateGermanyFormate();
            }

            // Act
            String? guid = fireBaseDBContext?.AddPerson(person);
            Person? result = fireBaseDBContext?.GetPerson(guid);

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
            List<Person>? result = fireBaseDBContext?.GetPersonList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count > 0);
        }
    }
}
