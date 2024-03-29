﻿using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Unity;
using Unity.Injection;

namespace Minesweeper_Web_App.Controllers
{
    public class GameController : Controller
    {
        //initialize game
        static GameModel newGame = new GameModel();

        GameBusinessService service = new GameBusinessService();

        //initialize dependency injection container
        UnityContainer container = new UnityContainer();

        // GET: Game
        //Custom Attribute to ensure that the user is logged in
        [CustomAuthorization]
        public ActionResult BuildGame(string difficulty)
        {
            if (difficulty != null)
            {
                newGame.difficulty = Int32.Parse(difficulty);
            }
            newGame.createGameBoard(newGame.board, newGame.difficulty);
            newGame.timer.Start();
            newGame.winLose = 0;
            return View("BuildGame", newGame);
        }

        [CustomAuthorization]
        public ActionResult DifficultySelect()
        {
            return View("DifficultySelect");
        }

        [HttpPost]
        public ActionResult HandleButtonClick(string mine)
        {
            //split the coordinate string submitted by the button
            string[] coordinates = mine.Split(',');
            int i = Int32.Parse(coordinates[0]);
            int j = Int32.Parse(coordinates[1]);
            
            if(!newGame.board.theGrid[i, j].isFlagged)
            {
                //mark the cell as visited
                newGame.board.theGrid[i, j].isVisited = true;

                //check for other unvisited cells
                newGame.board.floodfill(i, j);
            }

            if (newGame.endGameWin(newGame.board) == true)
            {
                newGame.printBoardWin(newGame.board);
                newGame.winLose = 1;
            }
            else if (newGame.board.theGrid[i, j].isLive == true)
            {
                newGame.printBoardLose(newGame.board);
                newGame.winLose = 2;
            }
            return PartialView("~/Views/Shared/_MinesweeperContainer.cshtml", newGame);
        }

        /*
         * This method serializes a GameModel object, passes the string in JSON format to GameDAO.saveGame(), 
         * where it is saved to the database
         */
        [HttpPost]
        public ActionResult HandleSaveClick()
        {
            //declare logger type, then intialize
            container.RegisterType<ILogger, Logger>();
            var logger = container.Resolve<ILogger>();
            logger = LogManager.GetLogger("minesweeperLogRules");

            try
            {
                //call SaveGame in GameBusinessService, pass gameJSON
                bool save = service.SaveGame(newGame);
                logger.Info("Successful save");
                //return BuildGame view
                return View("BuildGame", newGame);
            }
            catch (Exception e)
            {
                logger.Error("Failed to save: " + e.Message);
                return Content(e.Message);
            }
        }

        [HttpPost]
        public ActionResult HandleLoadClick()
        {
            container.RegisterType<ILogger, Logger>();
            var logger = container.Resolve<ILogger>();
            logger = LogManager.GetLogger("minesweeperLogRules");

            try
            {
                //call LoadGame from GameBusinessService
                newGame = service.LoadGame();
                logger.Info("Successful Load");
                //return BuildGame view
                return View("BuildGame", newGame);
            }
            catch (Exception e)
            {
                logger.Error("Failed to load: " + e.Message);
                return Content(e.Message);
            }
        }

        public ActionResult HandleRightClick(string mine)
        {
            string[] coordinates = mine.Split(',');
            int i = Int32.Parse(coordinates[0]);
            int j = Int32.Parse(coordinates[1]);

            newGame.board.theGrid[i, j].isFlagged = !newGame.board.theGrid[i, j].isFlagged;
            return View("BuildGame", newGame);
        }
    }
}