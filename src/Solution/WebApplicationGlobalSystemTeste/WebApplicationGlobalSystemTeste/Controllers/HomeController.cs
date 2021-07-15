using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Models;
using WebApplicationGlobalSystemTeste.Repository;

namespace WebApplicationGlobalSystemTeste.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var repository = new FighterRepository();
            var fighterTask = repository.GetFightersAsync();
            List<FighterModel> list = new List<FighterModel>();
            await fighterTask.ContinueWith(task =>
            {
                var fighters = task.Result;
                foreach (var fighter in fighters)
                {
                    var newFighter = new FighterModel()
                    {
                        Id = fighter.Id,
                        Name = fighter.Name,
                        Age = fighter.Age,
                        MartialArts = fighter.MartialArts,
                        Fights = fighter.Fights,
                        Defeats = fighter.Defeats,
                        Victories = fighter.Victories
                    };
                    list.Add(newFighter);
                }
                ViewBag.Fighter = list;
            },
                TaskContinuationOptions.OnlyOnRanToCompletion
            );

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
