using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business
{
    public class GameService
    {
        /*
         * This function instantiates a new GameDAO and calls create() method to save a game to the database
         */
        public bool SaveGame(string gameJSON)
        {
            GameDAO service = new GameDAO();
            return service.create(gameJSON);
        }
    }
}