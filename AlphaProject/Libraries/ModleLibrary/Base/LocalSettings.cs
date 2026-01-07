namespace ModleLibrary.Base
{
    public class LocalSettings
    {
        /// <summary>
        /// Gets or sets the Firebase authentication secret.
        /// </summary>
        public String? FireBase_AuthSecret { get; set; }

        /// <summary>
        /// Gets or sets the base path (URL) for the Firebase database.
        /// </summary>
        public String? FireBase_BasePath { get; set; }
    }
}
