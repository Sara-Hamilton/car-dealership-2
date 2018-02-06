using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
  public class CarsController : Controller
  {
    // [HttpGet("/cars")]
    // public ActionResult Index()
    // {
    //     return View();
    // }

    [HttpGet("/cars/new")]
    public ActionResult CreateForm()
    {
        return View();
    }
    [HttpPost("/cars")]
    public ActionResult Create()
    {
      Car newCar = new Car (Request.Form["new-make-model"], Request.Form["new-price"], Request.Form["new-miles"], Request.Form["new-details"]);
      newCar.Save();
      return View("Index", newCar);
    }

    [HttpGet("/cars")]
    public ActionResult Index()
    {
        List<Car> allCars = Car.GetAll();
        return View(allCars);
    }

    [HttpPost("/cars/delete")]
    public ActionResult DeleteAll()
    {
        Car.ClearAll();
        return View();
    }

  }
}
