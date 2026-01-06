using ModleLibrary.Model;

namespace FireBaseDB.Test
{
    public class TestDataFactory
    {
        /// <summary>
        /// Creates a new Person instance with the specified first and last names.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Person CreatePerson(string firstName, string lastName)
        {
            return new Person
            {
                GuidPerson = "Any Guid",
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
