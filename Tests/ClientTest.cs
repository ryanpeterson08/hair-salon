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

    [Fact]
    public void Test_SaveTo_Database()
    {
      Client testClient = new Client("Conrad", 1);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(result, testList);
    }

    [Fact]
    public void Test_Client_Given_Id()
    {
      Client testClient = new Client("Conrad", 1);
      testClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(result, testId);
    }

    [Fact]
    public void Test_ToFind_Client_InDatabase()
    {
      Client testClient = new Client("Conrad", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(foundClient, testClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
