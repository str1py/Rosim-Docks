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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataBaseContext db;
        private readonly DocksService _docks;
        private MainVars MainVars;
        private DictionaryCreator dicCreator;
        public HomeController(ILogger<HomeController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, DocksService docks, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            db = context;
            _docks = docks;
            MainVars = new(db);
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            dicCreator = new(db);

        }

        public ActionResult ChangeTheme(bool ischecked)
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["theme"];
            if (cookieValueFromContext == "light")
                SetCookie("theme", "dark");
            else SetCookie("theme", "light");

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["theme"];
            if (cookieValueFromContext == null)
                SetCookie("theme", "light");

            return View();
        }
        private void SetCookie(string key, string value)
        {     
            Response.Cookies.Append(key, value);
        }
        private void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
