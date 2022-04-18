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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataBaseContext db;
        private readonly DocksService _docks;
        private MainVars MainVars;
        private DictionaryCreator dicCreator;
        public ErrorController(ILogger<HomeController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, DocksService docks, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            db = context;
            _docks = docks;
            MainVars = new(db);
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            dicCreator = new(db);

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
