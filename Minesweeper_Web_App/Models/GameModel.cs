using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    public class GameModel
    {
        public static Board gb = new Board(12);
        public static List<Cell> b = new List<Cell>();

        public GameModel(Board gameBoard, List<Cell> board)
        {
            gb = gameBoard;
            b = board;
        }

        public void populateGrid()
        {
            
        }


        //public void test()
        //{
        //    board.setUpBombs("Easy");

        //    board.calculateLiveNeighbors();

        //    //board.floodfill();
        //}
    }
}