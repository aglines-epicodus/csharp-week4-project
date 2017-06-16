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

////////////////////////////////////////////////////////////
    [Fact]
    public void Band_Equals_TrueForIdenticalObjects()
    {
      Band firstBand = new Band("T.Rex");
      Band secondBand = new Band("T.Rex");
      Assert.Equal(firstBand, secondBand);
    }
////////////////////////////////////////////////////////////
    [Fact]
    public void Venue_Save_SavesVenueToDb()
    {
      Venue newVenue = new Venue("Arcade Fire Hazard");
      newVenue.Save();
      Venue savedVenue = Venue.GetAll()[0];
      Assert.Equal(newVenue, savedVenue);
    }


  }
}
