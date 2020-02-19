using Minesweeper_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Minesweeper_Web_App.Controllers
{
    public class GameController : Controller
    {
        static List<Cell> board = new List<Cell>();
        //static GameModel game = new GameModel(new Board(12));
        //static Button[,] btnGrid = new Button[game.board.size, game.board.size];
        // GET: Game
        public ActionResult BuildGame()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.Add(new Cell(i, j));
                }
            }
            //for (int i = 0; i < game.board.size; i++)
            //{
            //    for (int j = 0; j < game.board.size; j++)
            //    {
            //        btnGrid[i, j] = new Button();

            //        btnGrid[i, j].Height = 50;
            //        btnGrid[i, j].Width = 50;
            //    }
            //}
            return View("BuildGame", board);
        }

        public ActionResult HandleButtonClick()
        {
            return View("BuildGame");
        }
    }
}