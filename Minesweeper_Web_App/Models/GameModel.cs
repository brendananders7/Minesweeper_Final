using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    public class GameModel
    {
        public Board board = new Board(12);
        

        public GameModel(Board board)
        {
            this.board = board;
        }


        //public void test()
        //{
        //    board.setUpBombs("Easy");

        //    board.calculateLiveNeighbors();

        //    //board.floodfill();
        //}
    }
}