using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;

namespace msUtilities_452_test
{
  [TestClass]
  public class msConversionTest
  {
    [TestMethod]
    public void TestMinutesToDateTime()
    {
      int minutes = 480;

      DateTime converted = msConversion.minutesToDateTime(minutes);

      Assert.AreEqual(8, converted.Hour);
      Assert.AreEqual(0, converted.Minute);
    }
  }
}
