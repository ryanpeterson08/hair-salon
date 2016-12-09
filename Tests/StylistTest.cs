using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Equal_ReturnsTrue_ForSameName()
    {
      Stylist stylistOne = new Stylist("Ryan Peterson");
      Stylist stylistTwo = new Stylist("Ryan Peterson");

      Assert.Equal(stylistOne, stylistTwo);
    }

    [Fact]
    public void Test_SavesStylist_To_Database()
    {
      Stylist testStylist = new Stylist("George Washington");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
