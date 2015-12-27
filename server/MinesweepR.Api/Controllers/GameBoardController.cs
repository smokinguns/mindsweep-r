using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MinesweepR.Api.Models;
using MinesweepR.Api.Service;
namespace MinesweepR.Api.Controllers
{
    public class GameBoardController : ApiController
    {
        GameBoardService _GameBoardService;
        public GameBoardController(GameBoardService gameBoardService)
        {
            _GameBoardService = gameBoardService;
        }
        public GameBoardPosition[,] Get([FromUri]int numberOfMines, int boardHeight, int boardWidth)
        {
            return _GameBoardService.GenerateBoard(numberOfMines, boardHeight, boardWidth);
        }          
    }
}
