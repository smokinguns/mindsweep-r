using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class GameBoardPosition
    {
        public bool HasMine 
        {
            get;
            set;
        }
        public int NumberOfSurroundingMines 
        {
            get;
            set;
        }
        public int PositionX
        {
            get;
            set;
        }
        public int PositionY
        {
            get;
            set;
        }
        public bool Clicked
        {
            get;
            set;
        }
    }
}