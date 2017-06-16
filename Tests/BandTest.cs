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
  }
}
