using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;

namespace msUtilities_452_test
{
  [TestClass]
  public class msConnectionStringTest
  {
    [TestMethod]
    public void TestConnectionStringGenerationFirebird()
    {
      msConnectionString conn = new msConnectionString(
        msConnectionString.DatabaseType.dtFirebird,
        "user",
        "password",
        "host",
        "database"
        );

      string test = String.Format("User={0};Password={1};Database={2};DataSource={3};", "user", "password", "database", "host");
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }

    [TestMethod]
    public void TestConnectionStringGenerationSqlServer()
    {
      msConnectionString conn = new msConnectionString(
        msConnectionString.DatabaseType.dtSqlServer,
        "user",
        "password",
        "host",
        "database"
        );

      string test = String.Format("User Id={0};Password={1};Database={2};Server={3};", "user", "password", "database", "host");
      string result = conn.getConnectionString();

      Assert.AreEqual(test, result);
    }
  }
}
