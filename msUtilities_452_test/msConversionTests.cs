using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace msUtilities.Tests
{
    [TestClass()]
    public class MsConversionTests
    {
        [TestMethod()]
        public void StringToIntTest()
        {
            var actual = "12".StringToInt(0);
            const int expected = 12;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinutesToDateTimeTest()
        {
            const int minutes = 480;

            var actual = MsConversion.MinutesToDateTime(minutes);

            Assert.AreEqual(8, actual.Hour);
            Assert.AreEqual(0, actual.Minute);
        }

        [TestMethod()]
        public void StringToFloatTest()
        {
            var actual = "12.1".StringToFloat(0);
            const double expected = 12.1;

            Assert.AreEqual(expected, actual, 0.01);
        }
    }
}