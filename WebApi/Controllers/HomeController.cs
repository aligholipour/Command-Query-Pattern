using Library.Command;
using Library.Query;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Application.Command;
using WebApi.Application.Query;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        public HomeController(ILogger<HomeController> logger, ICommandBus commandBus, IQueryBus queryBus)
        {
            _logger = logger;
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public IActionResult Index()
        {
            var productCommand = new ProductCommand
            {
                Id = 1,
                Name = "Laptop;"
            };

            _commandBus.Dispatch(productCommand);

            var productQueryRequest = new ProductQueryRequest
            {
                Id = 1
            };

            _queryBus.Dispatch<ProductQueryRequest, ProductQueryResponse>(productQueryRequest);

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