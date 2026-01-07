
using System.Globalization;

namespace DateProvider.Impl
{
    public class DateProvider : IDateProvider
    {
        /// <inheritdoc />
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        /// <inheritdoc />
        public String? GetCurrentDateGermanyFormate()
        {
            return DateFormat(DateTime.Now);
        }

        /// <summary>
        /// Applay Germany Formate
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private String? DateFormat(DateTime? dateTime)
        {
            var output=String.Empty;

            output = dateTime?.ToString("d", CultureInfo.GetCultureInfo("de"));

            return output;
        }
    }
}
