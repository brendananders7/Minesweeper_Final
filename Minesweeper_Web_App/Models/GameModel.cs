using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    public class GameModel
    {
        public Board board = new Board(12);
        
        //constructor 1
        public GameModel(Board board)
        {
            this.board = board;
        }

        //constructor 2
        public GameModel()
        {
            
        }

        public void createGameBoard()
        {
            board.setUpBombs("Medium");
            board.calculateLiveNeighbors();
        }
    }
}