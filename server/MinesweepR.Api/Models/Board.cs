using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Board
    {
        public string Height { get; set; }

        public string Weight { get; set; }

        public string MinePositions { get; set; }
    }
}