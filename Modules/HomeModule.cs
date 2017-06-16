using Nancy;
using System.Collections.Generic;
using System;
using Nancy.ViewEngines.Razor;


namespace BandTracker_Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => {
        return View["index.cshtml"];
      };

    }
  }
}
