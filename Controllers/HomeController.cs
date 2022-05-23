using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RosreestDocks.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace RosreestDocks.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //logger.LogCritical("LogCritical {0}", context.Request.Path);
        //logger.LogDebug("LogDebug {0}", context.Request.Path);
        //logger.LogError("LogError {0}", context.Request.Path);
        //logger.LogInformation("LogInformation {0}", context.Request.Path);
        //logger.LogWarning("LogWarning {0}", context.Request.Path);
        //logger.LogInformation("Processing request {0}", context.Request.Path);
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["theme"];
            if (cookieValueFromContext == null)
                SetCookie("theme", "light");

            return View();
        }

        public void ChangeTheme()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["theme"];
            if (cookieValueFromContext == "dark")
                SetCookie("theme", "light");
            else SetCookie("theme", "dark");


            _logger.LogInformation("Theme now: ", _httpContextAccessor.HttpContext.Request.Cookies["theme"]);
        }
        private void SetCookie(string key, string value)
        {     
            Response.Cookies.Append(key, value);
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
