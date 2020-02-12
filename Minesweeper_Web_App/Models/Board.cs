using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_Web_App.Models
{
    public class Board
    {
        //Board is square, size 12
        public int size { get; set; }

        //Percentage of cells that will be set to live
        public double difficultyPercentage { get; set; }

        //number of bombs that will be spawned
        public int numberOfNewBombs { get; set; }

        //Used to make sure that the correct amount of bombs will be spawned
        public int numberOfBombsPlaced { get; set; }

        //2d array of cell objects
        public Cell[,] theGrid;

        //Used to spawn the bombs at random cells
        Random random = new Random();

        //constructor
        public Board(int s)
        {
            //Initialize size of board
            size = s;
            //Initialize array to avoid null exception errors
            theGrid = new Cell[size, size];
            for(int r = 0; r < size; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    theGrid[r, c] = new Cell(r, c);
                }
            }
        }

        //Randomly generates live cells across the board, according to the property 'percentDifficulty'
        public void setUpBombs(string difficulty)
        {
            numberOfBombsPlaced = 0;
            switch (difficulty)
            {
                case "Easy":
                    difficultyPercentage = .5;
                    numberOfNewBombs = (int)(difficultyPercentage * size);
                    random = new Random();

                    //While loop makes sure that the correct number of bombs are spawned
                    while(numberOfBombsPlaced < numberOfNewBombs)
                    {
                        int rnd1 = random.Next(0, size);
                        int rnd2 = random.Next(0, size);
                        if (theGrid[rnd1, rnd2].isLive == true)
                        {

                        }
                        else
                        {
                            theGrid[rnd1, rnd2].isLive = true;
                            numberOfBombsPlaced++;
                        }
                    }
                    break;

                case "Medium":
                    difficultyPercentage = .99;
                    numberOfNewBombs = (int)(difficultyPercentage * size);
                    random = new Random();

                    while (numberOfBombsPlaced < numberOfNewBombs)
                    {
                        int rnd1 = random.Next(0, size);
                        int rnd2 = random.Next(0, size);
                        if (theGrid[rnd1, rnd2].isLive == true)
                        {

                        }
                        else
                        {
                            theGrid[rnd1, rnd2].isLive = true;
                            numberOfBombsPlaced++;
                        }
                    }
                    break;

                case "Hard":
                    difficultyPercentage = 2.00;
                    numberOfNewBombs = (int)(difficultyPercentage * size);
                    random = new Random();

                    while (numberOfBombsPlaced < numberOfNewBombs)
                    {
                        int rnd1 = random.Next(0, size);
                        int rnd2 = random.Next(0, size);
                        if (theGrid[rnd1, rnd2].isLive == true)
                        {

                        }
                        else
                        {
                            theGrid[rnd1, rnd2].isLive = true;
                            numberOfBombsPlaced++;
                        }
                    }
                    break;

                case "Impossible":
                    difficultyPercentage = 4.00;
                    numberOfNewBombs = (int)(difficultyPercentage * size);
                    random = new Random();

                    while (numberOfBombsPlaced < numberOfNewBombs)
                    {
                        int rnd1 = random.Next(0, size);
                        int rnd2 = random.Next(0, size);
                        if (theGrid[rnd1, rnd2].isLive == true)
                        {

                        }
                        else
                        {
                            theGrid[rnd1, rnd2].isLive = true;
                            numberOfBombsPlaced++;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        //Checks how many live neighbors a cell has, a cell can have 0-8 live neighbors. If a cell itself is live, then
        //the number can be 9.
        public void calculateLiveNeighbors()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cell liveCell = theGrid[i, j];
                    liveCell.liveNeighbors = 0;
                    if (isSafe(liveCell.rowNumber - 1, liveCell.columnNumber - 1) && theGrid[liveCell.rowNumber - 1, liveCell.columnNumber - 1].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber - 1, liveCell.columnNumber + 1) && theGrid[liveCell.rowNumber - 1, liveCell.columnNumber + 1].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber + 1, liveCell.columnNumber + 1) && theGrid[liveCell.rowNumber + 1, liveCell.columnNumber + 1].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber + 1, liveCell.columnNumber - 1) && theGrid[liveCell.rowNumber + 1, liveCell.columnNumber - 1].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber + 1, liveCell.columnNumber) && theGrid[liveCell.rowNumber + 1, liveCell.columnNumber].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber, liveCell.columnNumber + 1) && theGrid[liveCell.rowNumber, liveCell.columnNumber + 1].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber - 1, liveCell.columnNumber) && theGrid[liveCell.rowNumber - 1, liveCell.columnNumber].isLive)
                        liveCell.liveNeighbors += 1;
                    if (isSafe(liveCell.rowNumber, liveCell.columnNumber - 1) && theGrid[liveCell.rowNumber, liveCell.columnNumber - 1].isLive)
                        liveCell.liveNeighbors += 1;
                }
            }
        }

        //Floodfill is used in minesweeper to take out a big chunk of the grid, but only if the cells are not live
        public void floodfill(int r, int c)
        {
            theGrid[r, c].isVisited = true;
            //apply to the cell to the south(r + 1)
            if (isSafe(r + 1, c) && theGrid[r + 1, c].isVisited == false && theGrid[r , c].liveNeighbors == 0)
            { 
                floodfill(r + 1, c);
            }
            //apply to the cell to the east(c + 1)
            if (isSafe(r, c + 1) && theGrid[r, c + 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            { 
                floodfill(r, c + 1);
            }
            //apply to the cell to west(c - 1)
            if (isSafe(r, c - 1) && theGrid[r, c - 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            { 
                floodfill(r, c - 1);
            }
            //apply to the cell to the north(r - 1)
            if (isSafe(r - 1, c ) && theGrid[r - 1, c].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            { 
                floodfill(r - 1, c);
            }
            //apply to the cell to the southeast
            if (isSafe(r + 1, c + 1) && theGrid[r + 1, c + 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            {
                floodfill(r + 1, c + 1);
            }
            //apply to the cell to the northwest
            if (isSafe(r - 1, c - 1) && theGrid[r - 1, c - 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            {
                floodfill(r - 1, c - 1);
            }
            //apply to the cell to southwest
            if (isSafe(r + 1, c - 1) && theGrid[r + 1, c - 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            {
                floodfill(r + 1, c - 1);
            }
            //apply to the cell to the northeast
            if (isSafe(r - 1, c + 1) && theGrid[r - 1, c + 1].isVisited == false && theGrid[r, c].liveNeighbors == 0)
            {
                floodfill(r - 1, c + 1);
            }
            
        }

        //prevents out of bounds exceptions
        public bool isSafe(int r, int c)
        {
            bool check = false;
            if (r < 0 || c < 0 || r >= size || c >= size)
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;
        }
    }
}
