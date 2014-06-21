#region Usings

using System.Web.Mvc;
using Domain;
using Web.Models;

#endregion

namespace Web.Controllers {
    public class HomeController : Controller {
        private readonly Player player = new Player();

        public ActionResult Index() {
            return View();
        }

        public ActionResult Play() {
            return View();
        }

        [HttpPost]
        public ActionResult Play(RollDiceGameViewModel viewModel) {
            var game = new RollDiceGame {Player = player};
            player.BuyChips(100);
            player.Bet(viewModel.Chips, viewModel.Score);
            game.Play();

            ViewBag.Chips = player.Chips;
            return View(viewModel);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}