using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practical.Models;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Practical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PracticalContext _context;

        public HomeController(ILogger<HomeController> logger, PracticalContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchProducts(int? categoryId)
        {
            var viewModel = new ProductSearchViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList(),
                Products = _context.Products
                    .Where(p => !categoryId.HasValue || p.CategoryId == categoryId)
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult SearchByName(string productName = "")
        {
            var viewModel = new ProductSearchViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList(),
                Products = _context.Products
                    .Where(p => string.IsNullOrEmpty(productName) || p.Name.Contains(productName))
                    .ToList()
            };

            ViewBag.ProductName = productName ?? string.Empty;

            return View("SearchByName", viewModel);
        }
    }
}
