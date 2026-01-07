using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using ModleLibrary.Model;
using Newtonsoft.Json;
using System.Net;

namespace FireBaseDB.DB.Impl
{
    /// <inheritdoc />
    public class FireBaseDBContext : IFireBaseDBContext
    {
        IFirebaseClient client;

        /// <inheritdoc />
        public FireBaseDBContext(String? _AuthSecret, String? _BasePath)
        {
            client = new FirebaseClient(new FirebaseConfig()
            {
                AuthSecret = _AuthSecret,
                BasePath = _BasePath
            });
        }

        /// <inheritdoc />
        public String? AddPerson(Person? person)
        {
            try
            {
                if (person is null)
                {
                    throw new InvalidOperationException("Person cannot be null here.");
                }

                person.GuidPerson = Guid.NewGuid().ToString();
                Person? data = person;

                SetResponse setResponse = client.Set("Persons/" + data?.GuidPerson, data);

                if (setResponse.StatusCode == HttpStatusCode.OK)
                {
                    return person?.GuidPerson;
                }
                else
                {
                    return "Something went wrong!!";
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <inheritdoc />
        public List<Person>? GetPersonList()
        {
            List<Person> list = new ();
            try
            {
                FirebaseResponse response = client.Get("Persons");

                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Body))
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<Guid, Person>>(response.Body)  ?? throw new NullReferenceException("Response body was null");

                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            list.Add(item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return list;
        }

        /// <inheritdoc />
        public Person? GetPerson(String? GuidPerson)
        {
            Person data = new();

            try
            {
                FirebaseResponse response = client.Get("Persons/" + GuidPerson);
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Body))
                {
                    data = JsonConvert.DeserializeObject<Person>(response.Body) ?? throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return data;
        }

        /// <inheritdoc />
        public Boolean? UpdatePerson(Person? person)
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
                throw new ArgumentException(ex.Message);
            }

            return true;
        }

        /// <inheritdoc />
        public Boolean? DeletePerson(String? GuidPerson)
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
                throw new ArgumentException(ex.Message);
            }

            return true;
        }
    }
}
