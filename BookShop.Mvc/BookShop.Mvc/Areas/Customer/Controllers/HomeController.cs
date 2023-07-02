using BookShop.DataAccess.MediatRPattern.Queries.ProductQuery;
using BookShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShop.Mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMediator mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var data = await mediator.Send(new GetAllProductQuery());
            return View(data);
        }
        public async Task<IActionResult> DetailsAsync(int id)
        {
			var productData = await mediator.Send(new GetByIdProductQuery() { Id = id });
            return View(productData);
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