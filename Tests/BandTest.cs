using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BandTracker;
using Band_Object;


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

    public void Dispose()
    {
      Band.DeleteAll();
    }

  }
}
