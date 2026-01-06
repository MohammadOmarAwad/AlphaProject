namespace DateProvider.Test
{
    [TestClass]
    public sealed class DateProviderToday
    {
        /// <summary>
        /// Tests that the DateProvider returns today's date.
        /// </summary>
        [TestMethod]
        public void DateProviderTodayTest()
        {
            // Arrange
            var dateProvider = new Impl.DateProvider();

            // Act
            var currentDate = dateProvider.GetCurrentDate();

            // Assert
            Assert.AreEqual(DateTime.Now.Date, currentDate.Date);
        }

        /// <summary>
        /// Tests that the DateProvider returns the correct day.
        /// </summary>
        [TestMethod]
        public void DateProviderDayTest()
        {
            // Arrange
            var dateProvider = new Impl.DateProvider();

            // Act
            var currentDate = dateProvider.GetCurrentDate();

            // Assert
            Assert.AreEqual(DateTime.Now.Date.Day, currentDate.Date.Day);
        }

        /// <summary>
        /// tests that the DateProvider returns the correct month.
        /// </summary>
        [TestMethod]
        public void DateProviderMonthTest()
        {
            // Arrange
            var dateProvider = new Impl.DateProvider();

            // Act
            var currentDate = dateProvider.GetCurrentDate();

            // Assert
            Assert.AreEqual(DateTime.Now.Date.Month, currentDate.Date.Month);
        }

        /// <summary>
        /// tests that the DateProvider returns the correct year.
        /// </summary>
        [TestMethod]
        public void DateProviderYearTest()
        {
            // Arrange
            var dateProvider = new Impl.DateProvider();

            // Act
            var currentDate = dateProvider.GetCurrentDate();

            // Assert
            Assert.AreEqual(DateTime.Now.Date.Year, currentDate.Date.Year);
        }
    }
}
