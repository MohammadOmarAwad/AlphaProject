
using ModleLibrary.Model;

namespace FireBaseDB.DB
{
    /// <summary>
    /// Defines CRUD operations for storing and retrieving <see cref="Person"/> entities in a Firebase-backed data store.
    /// </summary>
    /// <remarks>
    /// Implementations are responsible for mapping <see cref="Person.Id"/> to the underlying Firebase record key,
    /// handling serialization, network errors and authentication, and returning appropriate success/failure results.
    /// Solid (https://medium.com/@jeslurrahman/understanding-solid-principles-in-net-c-a-practical-guide-with-code-examples-2e759010974e)
    /// Generate an 'Interface' from an existing class (https://stackoverflow.com/questions/9277011/generate-an-interface-from-an-existing-class)
    /// How to use Firebase RealTime Database with C#? (https://medium.com/@ab.suleymanoglu/how-to-use-firebase-realtime-database-with-c-e54cd832e11c)
    /// </remarks>
    public interface IFireBaseDBContext
    {
        /// <summary>
        /// Adds a new person record to the database.
        /// </summary>
        /// <param name="person">The person to add. The <see cref="Person.Id"/> may be ignored by implementations that generate an id.</param>
        /// <returns>
        /// The generated identifier for the newly created person record.
        /// Returns an empty string or null only if creation failed (implementation-defined). Consumers should verify the result.
        /// </returns>
        String? AddPerson(Person? person);

        /// <summary>
        /// Deletes the person with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier of the person to delete.</param>
        /// <returns>
        /// True if the record was found and deleted; false if the record did not exist or deletion failed.
        /// </returns>
        Boolean? DeletePerson(String? id);

        /// <summary>
        /// Retrieves a person record by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the person to retrieve.</param>
        /// <returns>
        /// The <see cref="Person"/> with the specified id if found; otherwise null.
        /// </returns>
        Person? GetPerson(String? id);

        /// <summary>
        /// Retrieves all person records from the database.
        /// </summary>
        /// <returns>
        /// A list containing all <see cref="Person"/> records. The returned list will be empty if no records exist.
        /// </returns>
        List<Person>? GetPersonList();

        /// <summary>
        /// Updates an existing person record in the database.
        /// </summary>
        /// <param name="person">The person entity containing the updated values. The <see cref="Person.Id"/> must identify the record to update.</param>
        /// <returns>
        /// True if the update succeeded; false if the record was not found or the update failed.
        /// </returns>
        Boolean? UpdatePerson(Person? person);
    }
}