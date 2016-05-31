using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace msUtilities.Tests
{
  [TestClass()]
  public class msComparisonTests
  {
    [TestMethod()]
    public void BetweenTestDateTime()
    {
      var value = DateTime.Today;
      var lower = DateTime.Today.AddDays(-10);
      var upper = DateTime.Today.AddDays(10).Date;
      var actual = msComparison.Between(value, lower, upper);
      Assert.AreEqual(true, actual);

      value = DateTime.Today.AddDays(-20);
      actual = msComparison.Between(value, lower, upper);
      Assert.AreEqual(false, actual);
    }

    [TestMethod()]
    public void BetweenTestInt()
    {
      var value = 10;
      var lower = 0;
      var upper = 20;
      var actual = msComparison.Between(value, lower, upper);
      Assert.AreEqual(true, actual);

      value = -10;
      actual = msComparison.Between(value, lower, upper);
      Assert.AreEqual(false, actual);
    }
  }
}
