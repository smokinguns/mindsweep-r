using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Game
    {
        public string ConnectionId { get; set; }

        public string GroupName { get; set; }

        public Board Board { get; set; }
    }
}