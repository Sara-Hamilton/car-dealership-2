using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;
using System.Collections.Generic;

namespace CarDealership.Controllers
{
  public class CarsController : Controller
  {

    [HttpGet("/cars")]
    public ActionResult Index()
    {
        List<Car> allCars = Car.GetAll();
        return View(allCars);
    }

    [HttpGet("/cars/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    [HttpPost("/cars")]
    public ActionResult Create()
    {
      Car newCar = new Car(); newCar.SetMakeModel(Request.Form["new-make-model"]);
      newCar.SetPrice(int.Parse(Request.Form["new-price"]));
      newCar.SetMiles(int.Parse(Request.Form["new-miles"]));
      newCar.SetDetails(Request.Form["new-details"]);
      newCar.Save();
      List<Car> allCars = Car.GetAll();
      return View("Index", allCars);
    }

    [HttpPost("/cars/delete")]
    public ActionResult DeleteAll()
    {
        Car.ClearAll();
        return View();
    }

  }
}
