﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinesweepR.Api.Models
{
    public class Game
    {
        public Player Player1
        {
            get;
            set;
        }
        public Player Player2
        {
            get;
            set;
        }
        public string GameId 
        {
            get; 
            set; 
        }
        public int numberOfMines 
        { 
            get; 
            set; 
        }
        public int boardHeight 
        { 
            get; 
            set; 
        }
        public int boardWidth 
        { 
            get; 
            set; 
        }
        public GameBoardPosition[,] GameBoard 
        { 
            get; 
            set; 
        }
    }
}