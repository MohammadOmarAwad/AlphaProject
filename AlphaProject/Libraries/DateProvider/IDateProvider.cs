namespace DateProvider
{
    public interface IDateProvider
    {
        /// <summary>
        /// Returns the current date.
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentDate();
    }
}