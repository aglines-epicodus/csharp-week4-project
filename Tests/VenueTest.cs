using Xunit;
using BandTracker.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  [Collection("BandTracker")]

  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
    DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

////////////////////////////////////////////////////////////
    [Fact]
    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }

////////////////////////////////////////////////////////////
    [Fact]
    public void Venue_DatabaseIsEmpty_True()
    {
      //Arrange:  manual data
      List<Venue> expectedList = new List<Venue>{};
      //Act : the method we're testing
      List<Venue> resultList = Venue.GetAll();
      // Assert
      Assert.Equal(expectedList, resultList);
    }
  }
}
