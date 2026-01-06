namespace FireBaseDB.Model
{
    /// <summary>
    /// Represents a person record stored in the Firebase database.
    /// Contains the unique identifier and name components used by the application.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// This typically maps to the Firebase key or a GUID used to identify the person record.
        /// </summary>
        public string? GuidPerson { get; set; }

        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>
        public string? LastName { get; set; }
    }
}
