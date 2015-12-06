using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Board
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public int[] MineCoordinates { get; set; }


    }
}