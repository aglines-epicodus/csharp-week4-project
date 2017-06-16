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






    // Get["/bands/new"] = _ => {
    //   List<Venues> AllCategories = Venues.GetAll();
    //   return View["bands_form.cshtml", AllCategories];
    // };
    // Post["/bands/new"] = _ => {
    //   Band newBand = new Band(Request.Form["band-name"], Request.Form["venue-id"]);
    //   newBand.Save();
    //   return View["success.cshtml"];
    // };




    //
    //   Get["/bands"] = _ => {
    //     List<Band> AllBands = Band.GetAll();
    //     return View["bands.cshtml", AllBands];
    //   };
    //
    //   Get["/venues"] = _ => {
    //     List<Venues> AllCategories = Venues.GetAll();
    //     return View["venues.cshtml", AllCategories];
    //   };
    //
    //
    // Get["/venues/{id}"] = parameters => {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   var SelectedVenues = Venues.Find(parameters.id);
    //   var VenuesBands = SelectedVenues.GetBands();
    //   model.Add("venue", SelectedVenues);
    //   model.Add("bands", VenuesBands);
    //   return View["venue.cshtml", model];
    // };
    //
    //

    }
  }
}
