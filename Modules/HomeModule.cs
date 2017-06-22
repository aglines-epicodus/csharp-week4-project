using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using BandTracker.Objects;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };

      Get["/venues"] = _ => {
          List<Venue> AllVenues = Venue.GetAll();
          return View["venues.cshtml", AllVenues];
      };

      Get["/venues/new"] = _ => {
      return View["venue_form.cshtml"];
      };

      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["venue/edit/{id}"] = parameters => {
        Venue SelectedVenues = Venue.Find(parameters.id);
        return View["venue_edit.cshtml", SelectedVenues];
      };

      Patch["venue/edit/{id}"] = parameters => {
        Venue SelectedVenues = Venue.Find(parameters.id);
        SelectedVenues.Update(Request.Form["venue-name"]);
        return View["success.cshtml"];
      };
      Get["venue/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        return View["venue_delete.cshtml", SelectedVenue];
      };
      Delete["venue/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        SelectedVenue.DeleteOneVenueAndAllJoinedBands();
        return View["success.cshtml"];
      };

      // Get["/venues/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var SelectedVenue = Venue.Find(parameters.id);
      //   var VenueBands = SelectedVenue.GetBands();
      //   model.Add("venue", SelectedVenue);
      //   model.Add("bands", VenueBands);
      //   return View["venue.cshtml", model];
      // };

      Get["/venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue SelectedVenue = Venue.Find(parameters.id);
        List<Band> VenueBands = SelectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", SelectedVenue);
        model.Add("venueBands", VenueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };

      Get["/bands/new"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["bands_form.cshtml", AllVenues];
      };

      Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"], Request.Form["venue-id"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Get["/bands"] = _ => {
        List<Band> AllBands = Band.GetAll();
        return View["bands.cshtml", AllBands];
      };

      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };

      Get["/band/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band SelectedBand = Band.Find(parameters.id);
        List<Venue> BandsVenues = SelectedBand.GetVenues();
        List<Venue> AllVenues = Venue.GetAll();
        model.Add("band", SelectedBand);
        model.Add("bandVenues", BandsVenues);
        model.Add("allVenues", AllVenues);
        return View["band.cshtml", model];
        // return View["band.cshtml"];
      };

      // Get["/band/{id}"] = _ => {
      //   return View["band.cshtml"];
      // };


      Post["band/add_venue"] = _ => {
        Venue newVenue = Venue.Find(Request.Form["venue-id"]);
        Band newBand = Band.Find(Request.Form["band-id"]);
        newBand.AddVenue(newVenue);
        return View["success.cshtml"];
      };

      Post["venue/add_band"] = _ => {
        Band newBand = Band.Find(Request.Form["band-id"]);
        Venue newVenue = Venue.Find(Request.Form["venue-id"]);
        newVenue.AddBand(newBand);
        return View["success.cshtml"];
      };


    }
  }
}
