using System.Diagnostics;
using Hangfire.Models;
using Microsoft.AspNetCore.Mvc;
using Hangfire.Services;

namespace Hangfire.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            // enqueuing 
            BackgroundJob.Enqueue(() => DataService.SayHello("this is the immediately executed functioon"));
            // scheduling
            BackgroundJob.Schedule(() => DataService.SayHello("Hello this the message of scheduled function"), TimeSpan.FromMinutes(1));

            return Ok(new { name ="Muhammad elsayed elqassa"});
        }

        [HttpGet("recurringJobs")]
        public IActionResult RecurringJobs()
        {
            RecurringJob.AddOrUpdate(() => DataService.SayHello("This is the recurring method"), Cron.Minutely);
            return Ok("recurring jobs have started to work");
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
