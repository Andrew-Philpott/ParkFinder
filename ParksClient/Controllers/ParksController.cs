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