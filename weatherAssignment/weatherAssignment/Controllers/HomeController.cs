using Microsoft.AspNetCore.Mvc;
using weatherAssignment.model;

namespace weatherAssignment.Controllers
{
    public class HomeController : Controller
    {
        // Private method to generate hardcoded data
        private List<CityWeather> GetWeatherData()
        {
            return new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndtime = new DateTime(2030, 01, 01, 8, 00, 00), Temperature = 33 },
                new CityWeather { CityUniqueCode = "NYC", CityName = "New York", DateAndtime = new DateTime(2030, 01, 01, 3, 00, 00), Temperature = 60 },
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndtime = new DateTime(2030, 01, 01, 9, 00, 00), Temperature = 82 }
            };
        }

        [Route("/")]
        public IActionResult Index()
        {
            var data = GetWeatherData();
            return View(data);
        }

        [Route("/city/{cityUniqueCode}")]
        public IActionResult City(string cityUniqueCode)
        {
            var data = GetWeatherData();
            var cityWeather = data.FirstOrDefault(c => c.CityUniqueCode.Equals(cityUniqueCode, StringComparison.OrdinalIgnoreCase));

            if (cityWeather == null)
            {
                return RedirectToAction("NotValid");
            }

            ViewBag.Title = cityWeather.CityName;
            return View(cityWeather);
        }
        [Route("/city")]
        public IActionResult NotValid()
        {
            return View();
        }
    }
}

