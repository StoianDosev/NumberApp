using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumbersApp.Models;
using NumbersApp.Mappers;

namespace NumbersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INumbersService _service;

        
        private static IList<int> numbers = new List<int>();
        public HomeController(ILogger<HomeController> logger, INumbersService service)
        {
            _logger = logger;
            _service = service;
           
        }

        public async Task<IActionResult> Index()
        {
            var allNumbers = await _service.GetAllNumbers();
            var dtos = allNumbers.Select(NumberMapper.MapDto);
            return View(dtos);
        }

        [HttpPost, ActionName("Sum")]
        public async Task<IActionResult> Sum([FromBody] IEnumerable<NumberDto> allNumbers)
        {
            var sum = await _service.Sum(allNumbers.Select(NumberMapper.MapModel).ToList());
            return new JsonResult(sum);
        }

        [HttpGet, ActionName("Add")]
        public async Task<IActionResult> AddData()
        {
            var num = await _service.GetNumber();
            return new JsonResult(NumberMapper.MapDto(num));
        }

        [HttpGet, ActionName("Clear")]
        public async  Task<IActionResult> Clear()
        {
            await _service.Clear();
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
