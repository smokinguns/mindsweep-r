using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MinesweepR.Api.Service;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Service
{
    public class GamesController : ApiController
    {
        GameService _GameService;
        public GamesController(GameService gameService)
        {
            _GameService = gameService;
        }
        public IEnumerable<Game> Get()
        {
            return _GameService.Get();
        }
    }
}
