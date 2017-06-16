using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker.Objects
{
  public class Band
  {
    private int _id;
    private string _name;

    public Band(string Name, int Id = 0)
    {
      _name = Name;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
///////////////////////////////////////////////
    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool nameEquality = this.GetName() == newBand.GetName();
        bool idEquality = this.GetId() == newBand.GetId();

        return (nameEquality && idEquality);
      }
    }
///////////////////////////////////////////////
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
///////////////////////////////////////////////
    public static List<Band> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM bands", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Band> allBands = new List<Band>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Band newBand = new Band(name, id);
        allBands.Add(newBand);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allBands;
    }
///////////////////////////////////////////////
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO bands (name) OUTPUT INSERTED.id VALUES (@Name)", conn);
      SqlParameter nameParam = new SqlParameter("@Name", this.GetName());
      cmd.Parameters.Add(nameParam);
      SqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

///////////////////////////////////////////////
    public void AddVenue(Venue newVenue)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO join_bands_venues (id_bands, id_venues) VALUES (@BandId, @VenueId)", conn);

      SqlParameter VenueIdParam = new SqlParameter();
      VenueIdParam.ParameterName = "@VenueId";
      VenueIdParam.Value = newVenue.GetId();

      SqlParameter BandIdParam = new SqlParameter();
      BandIdParam.ParameterName = "@BandId";
      BandIdParam.Value = this.GetId();
      cmd.Parameters.Add(VenueIdParam);
      cmd.Parameters.Add(BandIdParam);

      cmd.ExecuteNonQuery();
      if(conn!=null)
      {
        conn.Close();
      }
    }

///////////////////////////////////////////////
    public List<Venue> GetVenues()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN join_bands_venues ON (bands.id = join_bands_venues.id_bands) JOIN venues ON (venues.id = join_bands_venues.id_venues) WHERE bands.id = @BandId", conn);

      SqlParameter BandIdParam = new SqlParameter();
      BandIdParam.ParameterName = "@BandId";
      BandIdParam.Value = this.GetId().ToString();

      cmd.Parameters.Add(BandIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Venue> allVenues = new List<Venue>{};

      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);

        Venue newVenue = new Venue(bandName, bandId);
        allVenues.Add(newVenue);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allVenues;
    }


///////////////////////////////////////////////
    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE bands SET name = @NewName OUTPUT INSERTED.name WHERE id = @BandId", conn);

      SqlParameter newNameParam = new SqlParameter();
      newNameParam.ParameterName = "@NewName";
      newNameParam.Value = newName;

      SqlParameter bandIdParam = new SqlParameter();
      bandIdParam.ParameterName = "@BandId";
      bandIdParam.Value = this.GetId();

      cmd.Parameters.Add(newNameParam);
      cmd.Parameters.Add(bandIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

// ///////////////////////////////////////////////
//     public void DeleteOneBandAndAllJoinedVenues()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @BandId; DELETE FROM join_bands_venues WHERE id_venues = @BandId", conn);
//
//       SqlParameter venueIdParam = new SqlParameter();
//       venueIdParam.ParameterName = "@BandId";
//       venueIdParam.Value = this.GetId();
//
//       cmd.Parameters.Add(venueIdParam);
//       cmd.ExecuteNonQuery();
//
//       if (conn != null)
//       {
//         conn.Close();
//       }
//     }










  }
}
