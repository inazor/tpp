using Study.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Study.Controllers
{
    public class CityController : Controller
    {
        public CityRepository CityRepository = new CityRepository(Config.DataAccess);

        public ActionResult List()
        {
            var cities = CityRepository.GetAll();
            ViewBag.Cities = cities;
            return View();
        }

        public ActionResult Card(int id)
        {
            var city = CityRepository.GetById(id);
            ViewBag.City = city;

            return View();
        }
    }
}