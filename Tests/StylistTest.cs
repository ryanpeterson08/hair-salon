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

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
