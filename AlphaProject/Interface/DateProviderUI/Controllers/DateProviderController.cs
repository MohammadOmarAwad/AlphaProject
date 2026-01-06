using DateProvider;
using Microsoft.AspNetCore.Mvc;

namespace DateProviderUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateProviderController : ControllerBase
    {
        private readonly ILogger<DateProviderController> Logger;
        private readonly IDateProvider DateProvider;

        public DateProviderController(
            ILogger<DateProviderController> logger,
            IDateProvider dateProvider)
        {
            Logger = logger;
            DateProvider = dateProvider;
        }

        [HttpGet(Name = "GetCurrentDate")]
        public DateTime GetCurrentDate()
        {
            return DateProvider.GetCurrentDate();
        }
    }
}
