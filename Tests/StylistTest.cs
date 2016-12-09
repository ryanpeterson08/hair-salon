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

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
