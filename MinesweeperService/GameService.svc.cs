using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business;
using Newtonsoft.Json;

namespace MinesweeperService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GameService : IGameService
    {
        GameModel game = new GameModel();

        public DTO GetGameModel(string id)
        {
            GameBusinessService service = new GameBusinessService();
            int gameId = Int32.Parse(id);

]            DTO dto = new DTO(0, "OK", service.GetGameModel(gameId));

            return dto;
        }
    }
}