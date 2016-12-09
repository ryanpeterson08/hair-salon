using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>{
        return View["index.cshtml"];
      };
      Get["/stylists"]= _ =>{
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ =>{
        return View["stylists_add.cshtml"];
      };
      Get["/clients/new"]= _ =>{
        return View["clients_add.cshtml"];
      };
      Post["/stylists/new"]= _ =>{
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
    }
  }
}
