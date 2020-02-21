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

        public void printBoardLose(Board myBoard)
        {
            for (int r = 0; r < myBoard.size; r++)
            {
                for (int c = 0; c < myBoard.size; c++)
                {
                    //All live cells(buttons) will display a bomb
                    myBoard.theGrid[r, c].isVisited = true;

                }
            }
        }

        public void printBoardWin(Board myBoard)
        {
            for (int r = 0; r < myBoard.size; r++)
            {
                for (int c = 0; c < myBoard.size; c++)
                {
                    Cell cell = myBoard.theGrid[r, c];
                    //All live cells(buttons) must be flagged to show the user they have won
                    myBoard.theGrid[r, c].isVisited = true;
                    if (myBoard.theGrid[r, c].isLive == true)
                    {
                        myBoard.theGrid[r, c].isFlagged = true;
                    }
                }
            }
        }

        public bool endGameWin(Board myBoard)
        {
            bool check = true;
            for (int r = 0; r < myBoard.size; r++)
            {
                for (int c = 0; c < myBoard.size; c++)
                {
                    if (myBoard.theGrid[r,c].isVisited == false && myBoard.theGrid[r, c].isLive == false)
                    {
                        check = false;
                    }
                }
            }
            return check;
        }


        public void createGameBoard()
        {
            board.setUpBombs("Medium");
            board.calculateLiveNeighbors();
        }
    }
}