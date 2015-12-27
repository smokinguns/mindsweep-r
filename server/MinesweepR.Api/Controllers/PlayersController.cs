using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MinesweepR.Api.Service;
using MinesweepR.Api.Models;
namespace MinesweepR.Api.Controllers
{
    public class PlayersController : ApiController
    {
        PlayerService _PlayerService;
        public PlayersController(PlayerService playerService)
        {
            _PlayerService = playerService;
        }

        public IEnumerable<Player> Get()
        {
           return _PlayerService.Get();
        }
    }
}
