using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business
{
    public class GameBusinessService
    {
        /*
         * This function instantiates a new GameDAO and calls create() method to save a game to the database
         */
        public bool SaveGame(string gameJSON)
        {
            GameDAO service = new GameDAO();
            return service.create(gameJSON);
        }

        /*
         * This function instantiates a new GameDAO and calls read() method to load a game from the database
         */
        public string LoadGame()
        {
            GameDAO service = new GameDAO();
            return service.read();
        }

        public string GetGameModel(int id)
        {
            GameDAO service = new GameDAO();
            return service.readById(id);
        }
    }
}