using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace msUtilities.Tests
{
    [TestClass()]
    public class MsComparisonTests
    {
        [TestMethod()]
        public void BetweenTestDateTime()
        {
            var value = DateTime.Today;
            var lower = DateTime.Today.AddDays(-10);
            var upper = DateTime.Today.AddDays(10).Date;
            var actual = MsComparison.Between(value, lower, upper);
            Assert.AreEqual(true, actual);

            value = DateTime.Today.AddDays(-20);
            actual = MsComparison.Between(value, lower, upper);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void BetweenTestInt()
        {
            var value = 10;
            const int lower = 0;
            const int upper = 20;
            var actual = MsComparison.Between(value, lower, upper);
            Assert.AreEqual(true, actual);

            value = -10;
            actual = MsComparison.Between(value, lower, upper);
            Assert.AreEqual(false, actual);
        }
    }
}
