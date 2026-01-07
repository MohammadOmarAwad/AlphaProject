using System.Reflection;

namespace FireBaseDB.Test.Base
{
    public abstract class TestBase
    {
        /// <summary>
        /// Loads an embedded resource as string content.
        /// </summary>
        /// <param name="ressourcePath">Fully qualified resource path within the executing assembly.</param>
        /// <returns>Content of the embedded resource as a string.</returns>
        protected String LoadInputData(String ressourcePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            String result;

            using (Stream stream = assembly.GetManifestResourceStream(ressourcePath) ?? throw new InvalidOperationException($"Embedded resource not found: {ressourcePath}"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
