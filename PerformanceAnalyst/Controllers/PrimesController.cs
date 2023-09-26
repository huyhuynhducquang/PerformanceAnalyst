using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Controllers
{
    public class PrimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateCircles(GenerateCirclesModel generateCirclesModel)
        {
            return View(generateCirclesModel);
        }

        [HttpPost]
        public IActionResult GenerateCircles(int minValue, int maxValue)
        {
            var circles = new List<Circle>();

            for (int num = minValue; num <= maxValue; num++)
            {
                var circle = new Circle()
                {
                    Radius = "10px",
                    Tooltip = num.ToString(),
                    Color = new Color(128, 128, 128).ToRgbCssString()
                };
                if (isPrime(num))
                    circle.Color = new Color(256, 256, 0).ToRgbCssString();

                circles.Add(circle);
            }

            return View(new GenerateCirclesModel
            {
                Circles = circles, 
                MaxValue = maxValue,
                MinValue = minValue
            });
        }

        private bool isPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number <= 3)
            {
                return true;
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
