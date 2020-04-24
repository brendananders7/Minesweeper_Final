using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business.Data;
using Newtonsoft.Json;
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
        public bool SaveGame(GameModel game)
        {
            //new GameDAO
            GameDAO service = new GameDAO();

            //serialize object, store in string
            string gameJSON = JsonConvert.SerializeObject(game);
            
            //create new row in db
            bool success = service.create(gameJSON);

            //return fail or success
            return success;
        }

        /*
         * This function instantiates a new GameDAO and calls read() method to load a game from the database
         */
        public GameModel LoadGame()
        {
            //new GameDAO
            GameDAO service = new GameDAO();

            //read row from db
            string gameJSON = service.read();

            //deserialize the string, store in GameModel
            GameModel game = JsonConvert.DeserializeObject<GameModel>(gameJSON);
            
            //return game model
            return game;
        }

        /*
         * Tis function finds a specific game by its id in the db.
         */
        public string GetById(string id)
        {
            //new GameDAO
            GameDAO service = new GameDAO();

            //parse id(string) to int
            int gameId = Int32.Parse(id);

            //store game found in string
            string gameJSON = service.readById(gameId);

            if(gameJSON == "")
            {
                //new DTO with no data
                DTO dto = new DTO(-1, "Game Not Found", gameJSON);

                string dtoJSON = JsonConvert.SerializeObject(dto);

                return dtoJSON;
            }
            else
            {
                //new DTO with data
                DTO dto = new DTO(0, "OK", gameJSON);

                string dtoJSON = JsonConvert.SerializeObject(dto);

                return dtoJSON;
            }
        }
    }
}