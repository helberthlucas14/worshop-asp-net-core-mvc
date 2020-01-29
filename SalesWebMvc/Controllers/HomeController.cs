using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SellerService _sellerService;
        private readonly SalesRecordService _salesRecordService;
        private readonly DepartmentService _departmentService;

        public HomeController(ILogger<HomeController> logger, SellerService sellerService, SalesRecordService salesRecordService, DepartmentService departmentService)
        {
            _logger = logger;
            _sellerService = sellerService;
            _salesRecordService = salesRecordService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var d  = await _departmentService.DeparmentCountAsync();
            var sr = await _salesRecordService.SalesRecodsCountAsync();
            var se = await _sellerService.SellerCountAsync();
            ViewData["department"] = d;
            ViewData["salesRecords"] = sr;
            ViewData["sellers"] = se;
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
