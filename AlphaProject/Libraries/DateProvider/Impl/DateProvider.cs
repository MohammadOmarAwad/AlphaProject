namespace DateProvider.Impl
{
    public class DateProvider : IDateProvider
    {
        /// <inheritdoc />
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
