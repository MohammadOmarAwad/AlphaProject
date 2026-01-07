using DateProvider;
using FireBaseDB.DB;
using Microsoft.AspNetCore.Mvc;
using ModleLibrary.Model;

namespace UserUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        public readonly IFireBaseDBContext FireBaseDB;
        private readonly IDateProvider DateProvider;

        public PersonController(
            ILogger<PersonController> logger,
            IFireBaseDBContext fireBaseDB,
            IDateProvider dateProvider
            )
        {
            _logger = logger;
            FireBaseDB = fireBaseDB;
            DateProvider = dateProvider;
        }

        /// <summary>
        /// Gets the person list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPersonList")]
        public List<Person> GetPersonList()
        {
            try
            {
                return FireBaseDB?.GetPersonList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
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
            try
            {
                return FireBaseDB?.GetPerson(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
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
            try
            {
                person.CreatedOn = DateProvider?.GetCurrentDateGermanyFormate();
                return FireBaseDB?.AddPerson(person);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// update person in database.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePerson")]
        public Boolean? UpdatePerson_FireBase(Person person)
        {
            try
            {
                return FireBaseDB?.UpdatePerson(person);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Delete person from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeletePerson")]
        public Boolean? DeletePerson_FireBase(string id)
        {
            try
            {
                return FireBaseDB?.DeletePerson(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
