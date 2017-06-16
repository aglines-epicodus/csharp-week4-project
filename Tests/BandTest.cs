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
////////////////////////////////////////////////////////////
    [Fact]
    public void Venue_AddVenuesToOneBand_True()
    {
      //arrange manual data
      Band newBand = new Band("Road Dogs");
      newBand.Save();

      Venue firstVenue = new Venue("Showbox");
      Venue secondVenue = new Venue("The Egyptian");
      firstVenue.Save();
      secondVenue.Save();

      newBand.AddVenue(firstVenue);
      newBand.AddVenue(secondVenue);

      List<Venue> result = newBand.GetVenues();
      List<Venue> expected = new List<Venue>{firstVenue, secondVenue};

    }

  //////////////////////////////////////////////////////////
    [Fact]
    public void GetVenues_ReturnAllVenuesFromOneBand_True()
    {
      Band testBand = new Band("XTerminators");
      testBand.Save();

      Venue firstVenue = new Venue("Showbox");
      Venue secondVenue = new Venue("The Egyptian");
      firstVenue.Save();
      secondVenue.Save();

      testBand.AddVenue(firstVenue);
      testBand.AddVenue(secondVenue);
      List<Venue> expectedVenues = new List<Venue>{firstVenue, secondVenue};
      List<Venue> resultVenues = testBand.GetVenues();

      Assert.Equal(expectedVenues, resultVenues);
    }

  //////////////////////////////////////////////////////////
    [Fact]
    public void Update_UpdatesBandInDb()
    {
      string name = "newBand";
      Band testBand = new Band(name);
      testBand.Save();

      string newName = "no, some other band!";
      testBand.Update(newName);

      string resultName = testBand.GetName();

      Assert.Equal(resultName, newName);
    }

  //////////////////////////////////////////////////////////
  [Fact]
    public void Delete_DeletesBandAssociationsFromDatabase_BandList()
    {
      //Arrange
      Venue testVenue = new Venue("Alberta Rose");
      testVenue.Save();

      string testName = "Neutral Milk Hotel";
      Band testBand = new Band(testName);
      testBand.Save();

      //Act
      testBand.AddVenue(testVenue);
      testBand.DeleteOneBandAndAllJoinedVenues();

      List<Band> resultVenueBands = testVenue.GetBands();
      List<Band> testVenueBands = new List<Band> {};

      //Assert
      Assert.Equal(testVenueBands, resultVenueBands);
    }

  }
}
