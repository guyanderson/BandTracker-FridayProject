using Nancy;
using System.Collections.Generic;
using System;
using Nancy.ViewEngines.Razor;
using Venue_Object;
using Band_Object;

namespace BandTracker_Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/bands"] = _ => {
        List<Band> AllBands = Band.GetAll();
        return View["bands.cshtml", AllBands];
      };

      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };

      Get["/bands/new"] = _ => {
        return View["band_form.cshtml"];
      };

      Post["/bands/new"] = _ => {
        string testIfEmpty = Request.Form["band-name"];
        if (testIfEmpty != "")
        {
          Band newBand = new Band(Request.Form["band-name"]);
          newBand.Save();
          return View["success.cshtml"];
        }
        else {
          return View["oops.cshtml"];
        }
      };

      Get["/venues/new"] = _ => {
        return View["venue_form.cshtml"];
      };

      Post["/venues/new"] = _ => {
        string testIfEmpty = Request.Form["venue-name"];
        if (testIfEmpty != "")
        {
          Venue newVenue = new Venue(Request.Form["venue-name"]);
          newVenue.Save();
          return View["success.cshtml"];
        }
        else {
          return View["oops.cshtml"];
        }
      };

    }
  }
}
