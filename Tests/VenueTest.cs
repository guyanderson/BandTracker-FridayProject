using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BandTracker;
using Band_Object;
using Venue_Object;

namespace Venue_Test
{
  [Collection("Tracker_Test")]
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_True()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_TrueForSameName_True()
    {
      //Arrange, Act
      Venue Venue1 = new Venue("Mom's Garage");
      Venue Venue2 = new Venue("Mom's Garage");

      //Assert
      Assert.Equal(Venue1, Venue2);
    }

    [Fact]
    public void Save_SavesVenuesToDatabase_True()
    {
      //Arrange
      Venue Venue1 = new Venue("Mom's Garage");
      Venue1.Save();

      //Act
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{Venue1};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Save_AssignsIdToVenue_True()
    {
      //Arrange
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();

      //Act
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Find_FindsVenueInDatabase_True()
    {
      //Arrange
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();

      //Act
      Venue result = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, result);
    }

    [Fact]
    public void GetBands_ReturnsAllVenues_True()
    {
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();
      Band testBand1 = new Band("Banjo Hero");
      testBand1.Save();
      Band testBand2 = new Band("Guitar Hero");
      testBand2.Save();

      testVenue.AddBand(testBand1);
      testVenue.AddBand(testBand2);

      List<Band> savedBands = testVenue.GetBands();
      List<Band> testList = new List<Band> {testBand1, testBand2};
      //CONSOLE LOGGING LIST ITEMS (GETTING IDs)
      Console.WriteLine("savedBands list id = {0}, {1}", savedBands[0].GetName(), savedBands[1].GetId());
      Console.WriteLine("testList list id = {0}, {1}", testList[0].GetName(), testList[1].GetId());

      Assert.Equal(testList, savedBands);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }

  }
}
