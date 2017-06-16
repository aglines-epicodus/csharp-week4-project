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
////////////////////////////////////////////////////////////
    [Fact]
    public void Band_AddBandsToOneVenue_True()
    {
      //arrange manual data
      Venue newVenue = new Venue("Alberta Rose");
      newVenue.Save();

      Band firstBand = new Band("T.Rex");
      Band secondBand = new Band("Band On teh Run");
      firstBand.Save();
      secondBand.Save();

      newVenue.AddBand(firstBand);
      newVenue.AddBand(secondBand);

      List<Band> result = newVenue.GetBands();
      List<Band> expected = new List<Band>{firstBand, secondBand};

    }

////////////////////////////////////////////////////////////
//   [Fact]
//   public void GetBands_ReturnAllBandsFromOneVenue_True()
//   {
//     Venue testVenue = new Venue("hearty");
//     testVenue.Save();
//
//     Band firstBand = new Band("soup", "heat");
//     Band secondBand = new Band("burger", "fry");
//     firstBand.Save();
//     secondBand.Save();
//
//     testVenue.AddBand(firstBand);
//     testVenue.AddBand(secondBand);
//     List<Band> expectedBands = new List<Band>{firstBand, secondBand};
//     List<Band> resultBands = testVenue.GetBands();
//
//     Assert.Equal(expectedBands, resultBands);
//   }
//
// ////////////////////////////////////////////////////////////
//   [Fact]
//   public void Update_UpdatesVenueInDb()
//   {
//     string name = "newVenue, idk, lunch?";
//     Venue testVenue = new Venue(name);
//     testVenue.Save();
//
//     string newName = "no, dinner!";
//     testVenue.Update(newName);
//
//     string resultName = testVenue.GetName();
//
//     Assert.Equal(resultName, newName);
//   }

////////////////////////////////////////////////////////////























  }
}
