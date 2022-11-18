using Library.Command;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Application.Command;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommandBus _bus;
        public HomeController(ILogger<HomeController> logger, ICommandBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public IActionResult Index()
        {
            var productCommand = new ProductCommand
            {
                Id = 1,
                Name = "Laptop;"
            };

            _bus.Dispatch(productCommand);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}