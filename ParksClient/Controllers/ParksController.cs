using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParksClient.Models;
using System.Security.Claims;

namespace ParksClient.Controllers
{
  public class ParksController : Controller
  {
    public ParksController()
    {
    }

    [HttpGet("parks")]
    public IActionResult Index()
    {
      List<SelectListItem> statesList = new List<SelectListItem>();
      List<SelectListItem> regionsList = new List<SelectListItem>();
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
        Value = a.Name,
        Text = a.Name
      }
      ).OrderBy(n => n.Text));


      statesList.Insert(0, new SelectListItem { Text = "", Value = "" });
      ViewBag.States = statesList;

      IQueryable<string> regions = states.Select(x => x.Region).Distinct();
      regionsList.AddRange(regions.Select(x =>
      new SelectListItem
      {
        Value = x,
        Text = x
      }
      ).OrderBy(n => n.Text));


      regionsList.Insert(0, new SelectListItem { Text = "", Value = "" });
      ViewBag.Regions = regionsList;

      return View(parks);
    }
    public IActionResult Query(string parkName, string stateName, string isNational, string region)
    {
      var parks = Park.GetParks(parkName, stateName, isNational, region);
      return View("Search", parks);
    }

    [HttpGet("parks/create")]
    public IActionResult Create()
    {
      var user = this.User.FindFirst(ClaimTypes.Name)?.Value;

      List<SelectListItem> statesList = new List<SelectListItem>();
      List<SelectListItem> regionsList = new List<SelectListItem>();
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

      IQueryable<string> regions = states.Select(x => x.Region).Distinct();
      regionsList.AddRange(regions.Select(x =>
      new SelectListItem
      {
        Value = x,
        Text = x
      }
      ).OrderBy(n => n.Text));


      regionsList.Insert(0, new SelectListItem { Text = "", Value = "" });
      ViewBag.Regions = regionsList;
      return View();
    }

    [HttpPost]
    public IActionResult Create(Park Park)
    {
      Park.Post(Park);
      return RedirectToAction("Index");
    }

    [HttpGet("parks/{id}")]
    public IActionResult Details(int id)
    {
      var thisPark = Park.Get(id);
      return View(thisPark);
    }

    [HttpGet("parks/edit/{id}")]
    public IActionResult Edit(int id)
    {
      List<SelectListItem> statesList = new List<SelectListItem>();
      IQueryable<State> states = Park.GetAllStates().AsQueryable();
      statesList.AddRange(states.Select(a =>
      new SelectListItem
      {
        Value = a.StateId.ToString(),
        Text = a.Name
      }
      ).OrderBy(n => n.Text));
      ViewBag.StateId = statesList;
      var park = Park.Get(id);
      return View(park);
    }

    [HttpPost]
    public IActionResult Edit(Park Park)
    {
      Park.Put(Park);
      return RedirectToAction("Index");
    }

    [HttpGet("parks/delete/{id}")]
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