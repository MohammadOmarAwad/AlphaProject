namespace DateProvider
{
    public interface IDateProvider
    {
        /// <summary>
        /// Returns the current date.
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentDate();

        /// <summary>
        /// Returns the current date as Germany Formate.
        /// </summary>
        /// <returns></returns>
        String? GetCurrentDateGermanyFormate();
    }
}