using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper_Web_App.Models
{
    [DataContract]
    public class GameModel
    {
        //[DataMember]
        //public int id{ get; set; }
        [DataMember]
        public Board board = new Board(12);
        [DataMember]
        public int winLose { get; set; }
        [DataMember]
        public int difficulty{ get; set; }
        [DataMember]
        public Stopwatch timer{ get; set; }

        //constructor 1
        public GameModel(Board board)
        {
            this.board = board;
        }

        //constructor 2
        public GameModel()
        {
            timer = new Stopwatch();
            difficulty = 1;
            winLose = 0;
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


        public void createGameBoard(Board myBoard, int difficulty)
        {
            for (int i = 0; i < myBoard.size; i++)
            {
                for (int j = 0; j < myBoard.size; j++)
                {
                    myBoard.theGrid[i, j].isLive = false;
                    myBoard.theGrid[i, j].isVisited = false;
                    myBoard.theGrid[i, j].isFlagged = false;
                    timer.Restart();
                    //myBoard.theGrid[i, j].liveNeighbors = 0;
                    
                }
            }
            if (difficulty == 1)
            {
                board.setUpBombs("Easy");
            }
            else if (difficulty == 2)
            {
                board.setUpBombs("Medium");
            }
            else if (difficulty == 3)
            {
                board.setUpBombs("Hard");
            }
            else if (difficulty == 4)
            {
                board.setUpBombs("Impossible");
            }
            board.calculateLiveNeighbors();
        }
    }
}