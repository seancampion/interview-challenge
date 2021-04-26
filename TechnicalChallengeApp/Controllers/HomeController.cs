using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TechnicalChallengeApp.BusinessLogic.Session;
using TechnicalChallengeApp.Models;

namespace TechnicalChallengeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionManagement _sessionManagement;

        public HomeController(ILogger<HomeController> logger, ISessionManagement sessionManagement)
        {
            _logger = logger;
            _sessionManagement = sessionManagement;
        }

        /// <summary>
        /// Initial landing page, which will trigger a session id generation
        /// </summary>
        /// <returns>A redirect to the same page with the session identifier associated</returns>
        public async Task<IActionResult> Index()
        {
            var sessionGenerationResult = await _sessionManagement.GenerateSessionGuidAsync();
            if (sessionGenerationResult.IsSuccess)
            {
                return RedirectToAction("Calculator", new
                {
                    id = sessionGenerationResult.Data
                });
            }

            return BadRequest();
        }

        /// <summary>
        /// The calculator interface
        /// </summary>
        /// <param name="id">The user's session identifier</param>
        /// <returns>The calculator interface</returns>
        public IActionResult Calculator(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.SessionId = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
