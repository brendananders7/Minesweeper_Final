using Minesweeper_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper_Web_App.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult BuildGame()
        {
            //Board board = new Board(12);
            //GameModel game = new GameModel(board);


            return View("BuildGame");
        }
    }
}