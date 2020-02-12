using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_Web_App
{
    public class Cell
    {
        //row/col, location of cell on grid
        public int rowNumber { get; set; }
        public int columnNumber { get; set; }

        //T/F is the cell visited?
        public bool isVisited { get; set; }

        //T/F is the cell a "live bomb" cell?
        public bool isLive { get; set; }

        //How many neighboring cells are live? 
        public int liveNeighbors { get; set; }

        public bool isFlagged { get; set; }

        //constructor
        public Cell(int r, int c)
        {
            rowNumber = r;
            columnNumber = c;
            isFlagged = false;
            isVisited = false;
            isLive = false;
        }
    }
}
