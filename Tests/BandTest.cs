using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BandTracker;
using Band_Object;
using Venue_Object;


namespace Band_Test
{
  [Collection("Tracker_Test")]
  public class BandTest : IDisposable
  {
    public BandTest()
    {
     DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_True()
    {
      //Arrange, Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_TrueForSameName_True()
    {
      //Arrange, Act
      Band Band1 = new Band("Guitar Hero");
      Band Band2 = new Band("Guitar Hero");

      //Assert
      Assert.Equal(Band1, Band2);
    }

    [Fact]
    public void Save_SavesBandsToDatabase_True()
    {
      //Arrange
      Band Band1 = new Band("Guitar Hero");
      Band1.Save();

      //Act
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{Band1};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Save_AssignsIdToBand_True()
    {
      //Arrange
      Band testBand = new Band("Guitar Hero");
      testBand.Save();

      //Act
      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = testBand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Find_FindsBandInDatabase_True()
    {
      //Arrange
      Band testBand = new Band("Guitar Hero");
      testBand.Save();

      //Act
      Band result = Band.Find(testBand.GetId());

      //Assert
      Assert.Equal(testBand, result);
    }

    [Fact]
    public void GetVenues_ReturnsAllBands_True()
    {

      Band testBand = new Band("Guitar Hero");
      testBand.Save();
      Venue testVenue1 = new Venue("Mom's Garage");
      testVenue1.Save();
      Venue testVenue2 = new Venue("Dad's Garage");
      testVenue2.Save();

      testBand.AddVenue(testVenue1);
      testBand.AddVenue(testVenue2);
      List<Venue> savedVenues = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1, testVenue2};

      Assert.Equal(testList, savedVenues);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }

  }
}
