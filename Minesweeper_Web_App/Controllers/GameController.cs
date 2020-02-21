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
        //initialize game
        static GameModel newGame = new GameModel();

        // GET: Game
        public ActionResult BuildGame()
        {
            //populate the game board
            newGame.createGameBoard(newGame.board);
            return View("BuildGame", newGame);
        }

        public ActionResult HandleButtonClick(string mine)
        {
            //split the coordinate string submitted by the button
            string[] coordinates = mine.Split(',');
            int i = Int32.Parse(coordinates[0]);
            int j = Int32.Parse(coordinates[1]);
            
            //mark the cell as visited
            newGame.board.theGrid[i, j].isVisited = true;

            if(newGame.endGameWin(newGame.board) == true)
            {
                newGame.printBoardWin(newGame.board);
            }
            else if(newGame.board.theGrid[i, j].isLive == true)
            {
                newGame.printBoardLose(newGame.board);
            }

            //check for other unvisited cells
            newGame.board.floodfill(i, j);



            return View("BuildGame", newGame);
        }
    }
}