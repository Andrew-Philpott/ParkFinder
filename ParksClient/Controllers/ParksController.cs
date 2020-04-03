using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParksClient.Models;
using ParksClient.Services;

namespace ParksClient.Controllers
{
  public class ParksController : Controller
  {
    public ParksController()
    {
    }

    public IActionResult Index()
    {
      List<SelectListItem> statesList = new List<SelectListItem>();
      List<SelectListItem> regions = new List<SelectListItem>();
      List<SelectListItem> isNationalPark = new List<SelectListItem>();
      isNationalPark.Insert(0, new SelectListItem { Text = "", Value = "" });
      isNationalPark.Insert(1, new SelectListItem { Text = "State", Value = "false" });
      isNationalPark.Insert(2, new SelectListItem { Text = "National", Value = "true" });
      ViewBag.IsNationalPark = isNationalPark;
      IEnumerable<Park> parks = Park.GetAll();
      IQueryable<State> states = Park.GetAllStates().AsQueryable();

      statesList.AddRange(states.Select(a =>
      new SelectListItem
      {
        Value = a.StateId.ToString(),
        Text = a.Name
      }
      ).OrderBy(n => n.Text));


      statesList.Insert(0, new SelectListItem { Text = "", Value = "" });
      ViewBag.States = statesList;

      regions.AddRange(states.Select(a =>
     new SelectListItem
     {
       Value = a.StateId.ToString(),
       Text = a.Region
     }
     ).OrderBy(n => n.Text));


      regions.Insert(0, new SelectListItem { Text = "", Value = "" });
      ViewBag.Regions = regions;

      return View(parks);
    }
    public IActionResult Query(string parkName, string stateName, string isNational, string region)
    {
      var parks = Park.GetParks(parkName, stateName, isNational, region);
      return View("Search", parks);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Park Park)
    {
      Park.Post(Park);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var park = Park.Get(id);
      return View(park);
    }

    [HttpPost]
    public IActionResult Edit(Park Park)
    {
      Park.Put(Park);
      return RedirectToAction("Details", new { id = Park.ParkId });
    }
    public IActionResult Delete(int id)
    {
      var park = Park.Get(id);
      return View(park);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Park.Delete(id);
      return RedirectToAction("Index");
    }
  }
}