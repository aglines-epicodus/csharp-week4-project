using Xunit;
using BandTracker.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  [Collection("BandTracker")]

  public class BandTest : IDisposable
  {
    public BandTest()
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
    public void Band_DatabaseIsEmpty_True()
    {
      //Arrange:  manual data
      List<Band> expectedList = new List<Band>{};
      //Act : the method we're testing
      List<Band> resultList = Band.GetAll();
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
    public void Band_Save_SavesBandToDb()
    {
      Band newBand = new Band("Arcade Fire Hazard");

      newBand.Save();
      Band savedBand = Band.GetAll()[0];

      Assert.Equal(newBand, savedBand);
    }
  }
}
