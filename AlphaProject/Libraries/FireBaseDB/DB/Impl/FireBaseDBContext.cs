using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using ModleLibrary.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

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

                if (setResponse.StatusCode == HttpStatusCode.OK)
                {
                    return person.GuidPerson;
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
            List<Person> list = new List<Person>();
            try
            {
                FirebaseResponse response = client.Get("Persons");

                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Body))
                {
                    dynamic data = JsonConvert.DeserializeObject<dynamic>(value: response.Body);

                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            list.Add(JsonConvert.DeserializeObject<Person>(((JProperty)item).Value.ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        /// <inheritdoc />
        public Person? GetPerson(string GuidPerson)
        {
            Person data=new Person();

            try
            {
                FirebaseResponse response = client.Get("Persons/" + GuidPerson);
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Body))
                {
                    data = JsonConvert.DeserializeObject<Person>(response.Body);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }

        /// <inheritdoc />
        public Boolean? UpdatePerson(Person person)
        {
            try
            {
                if (person == null || string.IsNullOrWhiteSpace(person.GuidPerson))
                {
                    throw new ArgumentException("Person or GuidPerson cannot be null or empty.");
                }

                SetResponse response = client.Set("Persons/" + person.GuidPerson, person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        /// <inheritdoc />
        public Boolean? DeletePerson(string GuidPerson)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(GuidPerson))
                {
                    throw new ArgumentException("GuidPerson cannot be null or empty.");
                }

                FirebaseResponse response = client.Delete("Persons/" + GuidPerson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
    }
}
