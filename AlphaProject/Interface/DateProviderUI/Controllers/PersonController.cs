using FireBaseDB.DB;
using FireBaseDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace DateProviderUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        public readonly IFireBaseDBContext FireBaseDB;

        public PersonController(ILogger<PersonController> logger,
            IFireBaseDBContext fireBaseDB)
        {
            _logger = logger;
            FireBaseDB = fireBaseDB;
        }

        /// <summary>
        /// Gets the person list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPersonList")]
        public List<Person> GetPersonList()
        {
            return FireBaseDB.GetPersonList();
        }

        /// <summary>
        /// Gets the person by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPerson")]
        public Person? GetPerson_FireBase(string id)
        {
            return FireBaseDB.GetPerson(id);
        }

        /// <summary>
        /// Add person to database.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPerson")]
        public string AddPerson_FireBase(Person person)
        {
            return FireBaseDB.AddPerson(person);
        }

        /// <summary>
        /// update person in database.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePerson")]
        public bool UpdatePerson_FireBase(Person person)
        {
            return FireBaseDB.UpdatePerson(person);
        }

        /// <summary>
        /// Delete person from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeletePerson")]
        public bool DeletePerson_FireBase(string id)
        {
            return FireBaseDB.DeletePerson(id);
        }
    }
}
