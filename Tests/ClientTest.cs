using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_ReturnsTrue_ForSame_Name()
    {
      Client clientOne = new Client("Conrad", 1);
      Client clienTwo = new Client("Conrad", 1);

      Assert.Equal(clientOne, clienTwo);
    }

    public void Dispose()
    {
      
    }
  }
}
