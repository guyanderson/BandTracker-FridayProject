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
      int result = Venue.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Equals_TrueForSameName_True()
    {
      Venue Venue1 = new Venue("Mom's Garage");
      Venue Venue2 = new Venue("Mom's Garage");

      Assert.Equal(Venue1, Venue2);
    }

    [Fact]
    public void Save_SavesVenuesToDatabase_True()
    {
      Venue Venue1 = new Venue("Mom's Garage");
      Venue1.Save();

      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{Venue1};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Save_AssignsIdToVenue_True()
    {
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();

      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Find_FindsVenueInDatabase_True()
    {
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();

      Venue result = Venue.Find(testVenue.GetId());

      Assert.Equal(testVenue, result);
    }

    [Fact]
    public void GetBandsByVenueId_ReturnsAllBands_True()
    {
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();
      Band testBand1 = new Band("Banjo Hero");
      testBand1.Save();
      Band testBand2 = new Band("Guitar Hero");
      testBand2.Save();

      testVenue.AddBand(testBand1);
      testVenue.AddBand(testBand2);
      List<Band> savedBands = testVenue.GetBandsByVenueId();
      List<Band> testList = new List<Band> {testBand1, testBand2};

      Assert.Equal(testList, savedBands);
    }

    [Fact]
    public void Update_UpdatesVenueInDatabase_True_5()
    {
      string name = "Mom's Garage";
      Venue testVenue = new Venue(name);
      testVenue.Save();
      string newName = "Dad's Garage";
      testVenue.Update(newName);

      string result = testVenue.GetName();
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Delete_DeletesVenueFromVenues_True()
    {
      string name1 = "Mom's Garage";
      Venue testVenue1 = new Venue(name1);
      testVenue1.Save();

      string name2 = "Dad's Garage";
      Venue testVenue2 = new Venue(name2);
      testVenue2.Save();

      testVenue1.Delete();
      List<Venue> resultVenues = Venue.GetAll();
      List<Venue> testVenueList = new List<Venue> {testVenue2};

      Assert.Equal(testVenueList, resultVenues);
    }

    [Fact]
    public void Delete_DeletesVenueAssociationsFromTours_True()
    {
      Band testBand = new Band("Guitar Hero");
      testBand.Save();
      Venue testVenue = new Venue("Mom's Garage");
      testVenue.Save();

      testVenue.AddBand(testBand);
      testVenue.Delete();
      List<Venue> resultBandVenues = testBand.GetVenuesByBandId();
      List<Venue> testBandVenues = new List<Venue> {};

      Assert.Equal(testBandVenues, resultBandVenues);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }

  }
}
