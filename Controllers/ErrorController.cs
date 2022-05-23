using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RosreestDocks.Contexts;
using RosreestDocks.Helpers;
using RosreestDocks.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RosreestDocks.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataBaseContext db;

        public ErrorController(ILogger<HomeController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            db = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
            {
                originalPath = HttpContext.Items["originalPath"] as string;
            }
            return View();
        }

    }
}
