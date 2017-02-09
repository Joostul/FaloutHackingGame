using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FalloutHacking.GameLogic;
using FalloutHacking.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace FalloutHacking.Controllers
{
    public class HomeController : Controller
    {
        private HackingGame _game;
        public readonly string key = "joost";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int difficulty)
        {
            _game = new HackingGame();
            _game.SetWordsWithDifficulty(difficulty);
            var str = JsonConvert.SerializeObject(_game);
            HttpContext.Session.SetString(key, str);

            return RedirectToAction("Index", "Game");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
