using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Models;
using WebApplicationGlobalSystemTeste.Services;

namespace WebApplicationGlobalSystemTeste.Controllers
{
    public class FighterController : Controller
    {
        #region Properties
        public FighterService Service { get; set; }
        public StringValues GetIds { get; set; }
        #endregion

        #region Constructor

        public FighterController()
        {
        }

        #endregion

        #region Methods

        public async Task<ActionResult> Index()
        {
            Service = new FighterService();
            return View(await Service.FindAllAsync());
        }

        public async Task<ActionResult> GetResult()
        {
            GetIds = HttpContext.Request.Query["ids"];
            Service = new FighterService();
            var response = await Service.FindSelectAsync(GetIds);
            ViewBag.Wednesdays = Service.WednesdaysAsync(response);
            ViewBag.SemiFinal = Service.SemiFinalAsync(ViewBag.Wednesdays);
            ViewBag.Final = Service.FinalAsync(ViewBag.SemiFinal);
            ViewBag.Champion = Service.ChampionAsync(ViewBag.Final);
            return View(response);
        }

        #endregion
    }
}
