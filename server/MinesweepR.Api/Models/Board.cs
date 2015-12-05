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

        public List<String> MineCoordinates { get; set; }

        public string LastPlayedPosition { get; set; }
    }
}