using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace msUtilities.Tests
{
  [TestClass()]
  public class msConversionTests
  {
    [TestMethod()]
    public void stringToIntTest()
    {
      var actual = msConversion.stringToInt("12", 0);
      var expected = 12;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod()]
    public void minutesToDateTimeTest()
    {
      int minutes = 480;

      DateTime actual = msConversion.minutesToDateTime(minutes);

      Assert.AreEqual(8, actual.Hour);
      Assert.AreEqual(0, actual.Minute);
    }

    [TestMethod()]
    public void stringToFloatTest()
    {
      var actual = msConversion.stringToFloat("12.1", 0);
      var expected = 12.1;

      Assert.AreEqual(expected, actual, 0.01);
    }
  }
}