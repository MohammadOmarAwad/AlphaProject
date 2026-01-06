using FireBaseDB.Model;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FireBaseDB.DB.Impl
{
    /// <inheritdoc />
    public class FireBaseDBContext : IFireBaseDBContext
    {
        IFirebaseClient client;

        /// <inheritdoc />
        public FireBaseDBContext(String _AuthSecret, String _BasePath)
        {
            client = new FirebaseClient(new FirebaseConfig()
            {
                AuthSecret = _AuthSecret,
                BasePath = _BasePath
            });
        }

        /// <inheritdoc />
        public string AddPerson(Person person)
        {
            try
            {
                person.GuidPerson = Guid.NewGuid().ToString();
                var data = person;
                SetResponse setResponse = client.Set("Persons/" + data.GuidPerson, data);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Added Succesfully";
                }
                else
                {
                    return "Something went wrong!!";
                }
            }
            catch (Exception ex)
            {
                return $"Something went wrong!! {ex.Message}";
            }
        }

        /// <inheritdoc />
        public List<Person> GetPersonList()
        {
            FirebaseResponse response = client.Get("Persons");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Person>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Person>(((JProperty)item).Value.ToString()));
                }
            }

            return list;
        }

        /// <inheritdoc />
        public Person GetPerson(string GuidPerson)
        {
            FirebaseResponse response = client.Get("Persons/" + GuidPerson);
            Person data = JsonConvert.DeserializeObject<Person>(response.Body);

            return data;
        }

        /// <inheritdoc />
        public bool UpdatePerson(Person person)
        {
            SetResponse response = client.Set("Persons/" + person.GuidPerson, person);

            return true;
        }

        /// <inheritdoc />
        public bool DeletePerson(string GuidPerson)
        {
            FirebaseResponse response = client.Delete("Persons/" + GuidPerson);

            return true;
        }
    }
}
