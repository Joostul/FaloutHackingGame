using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FalloutHacking.ViewModels;
using FalloutHacking.GameLogic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace FalloutHacking.Controllers
{
    public class GameController : Controller
    {
        private HackingGameViewModel _game;
        private string _guess;
        public readonly string key = "joost";

        // GET: /<controller>/
        public IActionResult Index()
        {
            var str = HttpContext.Session.GetString(key);
            _game = JsonConvert.DeserializeObject<HackingGameViewModel>(str);

            return View(_game);
        }

        [HttpPost]
        public IActionResult Index(string wordGuess)
        {
            var str = HttpContext.Session.GetString(key);
            _game = JsonConvert.DeserializeObject<HackingGameViewModel>(str);

            _guess = wordGuess.ToUpper();

            if(_game.WinningWord == _guess)
            {
                return RedirectToAction("Won");
            } else
            {
                _game.GuessesLeft -= 1;
                str = JsonConvert.SerializeObject(_game);
                HttpContext.Session.SetString(key, str);


                if (_game.GuessesLeft > 0)
                {
                    return View(_game);
                } else
                {
                    return RedirectToAction("Lost");
                }
            }
        }

        public IActionResult Won()
        {
            return View();
        }

        public IActionResult Lost()
        {
            return View();
        }
    }
}
