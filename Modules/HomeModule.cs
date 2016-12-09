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
        List<Stylist> allStylists = Stylist.GetAll();
        return View["clients_add.cshtml", allStylists];
      };
      Get["/stylist/{id}"]= parameters =>{
        var SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist.cshtml", SelectedStylist];
      };
      Post["/stylists/new"]= _ =>{
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
      Post["/clients/new"]= _ =>{
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };
    }
  }
}
