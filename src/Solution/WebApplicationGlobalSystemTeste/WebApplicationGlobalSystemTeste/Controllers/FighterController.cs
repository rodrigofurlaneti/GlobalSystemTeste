using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationGlobalSystemTeste.Services;

namespace WebApplicationGlobalSystemTeste.Controllers
{
    public class FighterController : Controller
    {
        #region Properties
        public FighterService fighterService { get; set; }
        #endregion

        #region Constructor

        public FighterController()
        {
        }

        #endregion

        #region Methods

        public async Task<ActionResult> Index()
        {
            fighterService = new FighterService();
            return View(await fighterService.FindAllAsync());
        }

        public IActionResult Result()
        {
            return View();
        }

        #endregion
    }
}
