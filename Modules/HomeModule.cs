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
      // root -> list all bands
      // Get["/"] = _ => {
      //   List<Band> allBands = Band.GetAll();
      //   return View["index.cshtml", allBands];
      // };
      //
      // // thing add
      // Get["/THINGS/add"] = _ => {
      //   Post[""]
      // };

    }
  }
}
