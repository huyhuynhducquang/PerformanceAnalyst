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
        public async Task<IActionResult> GenerateCircles(int minValue, int maxValue)
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
                if (await isPrime(num))
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

        private Task<bool> isPrime(int number)
        {
            Task.Delay(5000);
            if (number <= 1)
            {
                return Task.FromResult(false);
            }

            if (number <= 3)
            {
                return Task.FromResult(true);
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return Task.FromResult(false);
            }

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return Task.FromResult(false);
                }
            }

            return Task.FromResult(true);
        }
    }
}
