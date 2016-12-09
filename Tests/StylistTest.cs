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
    public void Test_Equal_ReturnsTrue_ForSameNameAndId()
    {
      Stylist stylistOne = new Stylist("John French");
      Stylist stylistTwo = new Stylist("John French");

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

    [Fact]
    public void Test_Stylist_Given_Id()
    {
      Stylist newStylist = new Stylist("Douglas Haig");
      newStylist.Save();

      Stylist foundStylist = Stylist.GetAll()[0];

      int result = newStylist.GetId();
      int testId = foundStylist.GetId();

      Assert.Equal(result, testId);
    }

    [Fact]
    public void Test_ToFind_StylistIn_Database()
    {
      Stylist testStylist = new Stylist("Joseph Joffre");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Test_UpdatesStylist_In_Database()
    {
      string name = "Dwight Eisenhower";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();

      string newName = "Douglas MacArthur";
      testStylist.Update(newName);
      string result = testStylist.GetName();

        Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_GetClients_RetrievesAll_Clients_WithStylist()
    {
      Stylist testStylist = new Stylist("Abraham Lincoln");
      testStylist.Save();

      Client firstClient = new Client("Ryan", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Frank", testStylist.GetId());
      secondClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }

    [Fact]
    public void Test_Delete_Deletes_Stylist_FromDatabase()
    {
      //Arrange
      string name1 = "George";
      Stylist testStylist1 = new Stylist(name1);
      testStylist1.Save();

      string name2 = "Justin";
      Stylist testStylist2 = new Stylist(name2);
      testStylist2.Save();

      Client testClient1 = new Client("Dinese", testStylist1.GetId());
      testClient1.Save();
      Client testClient2 = new Client("Damian", testStylist2.GetId());
      testClient2.Save();

      //Act
      testStylist1.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist2};

      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};

      //Assert
      Assert.Equal(testStylistList, resultStylists);
      Assert.Equal(testClientList, resultClients);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
